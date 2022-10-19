using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteca_de_Clases;
using System.IO;

namespace Notaria_WPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para FormArriendoVehiculo.xaml
    /// </summary>
    public partial class FormArriendoVehiculo : Page
    {
        string path = @"..\Doc_Notarial\Origen\Contrato Arriendo Vehículo.pdf";
        string path3 = @"..\Doc_Notarial\Destino\Contrato Arriendo Vehículo.pdf";
        public FormArriendoVehiculo()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            PdfDocument pdf = new PdfDocument(new PdfReader(path), new PdfWriter(path3));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
            IDictionary<String, PdfFormField> fields = form.GetFormFields();
            PdfFormField toSet;
            
            //Datos Arrendador
            fields.TryGetValue("Nombre1", out toSet);
            toSet.SetValue(txtNombresArrendador.Text + " " + txtApellPArrendador.Text + " " + txtApellMArrendador.Text);
            fields.TryGetValue("dia", out toSet);
            toSet.SetValue(DateTime.Now.ToString("dd"));
            fields.TryGetValue("mes", out toSet);
            toSet.SetValue(DateTime.Now.ToString("MMMM"));
            fields.TryGetValue("anno", out toSet);
            toSet.SetValue(DateTime.Now.ToString("yy"));
            fields.TryGetValue("rut1", out toSet);
            toSet.SetValue(txtrutArrendador.Text);
            fields.TryGetValue("nacionalidad", out toSet);
            toSet.SetValue(txtNacionArrendador.Text);
            fields.TryGetValue("estadoCivil1", out toSet);
            toSet.SetValue(txtEstCivilArr.Text);
            fields.TryGetValue("profesion1", out toSet);
            toSet.SetValue(txtProfArr.Text);
            fields.TryGetValue("direccion1", out toSet);
            toSet.SetValue(txtDirArr.Text);

            //Datos Arrendatario
            fields.TryGetValue("Nombre2", out toSet);
            toSet.SetValue(txtNombres.Text + " " + txtApellidoP.Text + " " + txtApellidoM.Text);
            fields.TryGetValue("rut2", out toSet);
            toSet.SetValue(txtrutArrendatario.Text);
            fields.TryGetValue("nacionalidad2", out toSet);
            toSet.SetValue(txtNacionalidad.Text);
            fields.TryGetValue("estadoCivil2", out toSet);
            toSet.SetValue(txtEstCivil.Text);

            //Datos del Vehículo
            fields.TryGetValue("tipoVehiculo", out toSet);
            toSet.SetValue(txtTipoVehiculo.Text);
            fields.TryGetValue("annoVehiculo", out toSet);
            toSet.SetValue(txtAñoVehiculo.Text);
            fields.TryGetValue("MarcaVehiculo", out toSet);
            toSet.SetValue(txtMarcaVehiculo.Text);
            fields.TryGetValue("ModeloVehiculo", out toSet);
            toSet.SetValue(txtModeloVehiculo.Text);
            fields.TryGetValue("MotorVehiculo", out toSet);
            toSet.SetValue(txtNumeroMotor.Text);
            fields.TryGetValue("ChasisVehiculo", out toSet);
            toSet.SetValue(txtNumeroChasis.Text);
            fields.TryGetValue("ColorVehiculo", out toSet);
            toSet.SetValue(txtColorVehiculo.Text);
            fields.TryGetValue("PatenteVehiculo", out toSet);
            toSet.SetValue(txtPatenteVehiculo.Text);

            //Monto Arriendo
            fields.TryGetValue("MensualVehiculo", out toSet);
            toSet.SetValue(txtMontoArriendo.Text);

            form.FlattenFields();
            pdf.Close();

            //Transformar documento emitido en bytes
            string filepath = path3;
            FileStream fStream = File.OpenRead(filepath);
            byte[] contents = new byte[fStream.Length];
            fStream.Read(contents, 0, (int)fStream.Length);
            fStream.Close();


            Doc_Emitido doc = new Doc_Emitido()
            {
                copia_documento = contents,
                fecha_emision = DateTime.Now,
                precio = VistaRecepcionista.precio,
                estado = "En revisión",
                valido = false,
                presencialidad = true,
                usuario_rut = string.Empty,
                rut_cliente_pres = txtrutArrendador.Text,
                cod_tramite = VistaRecepcionista.codTramite,
                empleado_rut = MainWindow.rutEmpleado
            };

            if (doc.Create())
            {
                MessageBox.Show("Documento creado correctamente", "Éxito");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error", "Error");
            }
        }

        

        private void Limpiar()
        {
            txtrutArrendador.Text = String.Empty;
            txtNombresArrendador.Text = String.Empty;
            txtApellMArrendador.Text = String.Empty;
            txtApellPArrendador.Text = String.Empty;
            txtNacionArrendador.Text = String.Empty;
            txtEstCivilArr.Text = String.Empty;
            txtProfArr.Text = String.Empty;
            txtDirArr.Text = String.Empty;
            txtrutArrendatario.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtApellidoP.Text = String.Empty;
            txtApellidoM.Text = String.Empty;
            txtNacionalidad.Text = String.Empty;
            txtEstCivil.Text = String.Empty;
            txtTipoVehiculo.Text = String.Empty;
            txtAñoVehiculo.Text = String.Empty;
            txtMarcaVehiculo.Text = String.Empty;
            txtModeloVehiculo.Text = String.Empty;
            txtNumeroMotor.Text = String.Empty;
            txtNumeroChasis.Text = String.Empty;
            txtColorVehiculo.Text = String.Empty;
            txtPatenteVehiculo.Text = String.Empty;
            txtMontoArriendo.Text = String.Empty;
        }
    }
}
