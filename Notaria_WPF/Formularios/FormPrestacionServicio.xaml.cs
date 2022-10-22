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
using System.IO;
using Biblioteca_de_Clases;
using System.Windows.Media.TextFormatting;

namespace Notaria_WPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para FormPrestacionServicio.xaml
    /// </summary>
    public partial class FormPrestacionServicio : Page
    {
        public FormPrestacionServicio()
        {
            InitializeComponent();
        }

        string path = @"..\Doc_Notarial\Origen\Contrato Prestación de Servicios.pdf";
        string path3 = @"..\Doc_Notarial\Destino\Contrato Prestación de Servicios.pdf";

        private void btnGuardarPrestacion_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreRepresentante.Text != null || txtRutRepresentante.Text != null || txtRangoRepresentante.Text != null || txtNombreEmpresa.Text != null || txtRutEmpresa.Text != null || txtDirEmpresa.Text != null || txtNumEmpresa.Text != null || txtComunaEmpresa.Text != null || txtCiudadEmpresa.Text != null || txtNombreMandatario.Text != null || txtRutMandatario.Text != null || txtNacionalidadMandatario.Text != null || txtOficioMandatario.Text != null || txtDirMandatario.Text != null || txtNumMandatario.Text != null || txtCiudadMandatario.Text != null || txtComunaMandatario.Text != null || txtCompromiso.Text != null || txtNomProyecto.Text != null || txtPago.Text != null)
            {
                PdfDocument pdf = new PdfDocument(new PdfReader(path), new PdfWriter(path3));
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
                IDictionary<String, PdfFormField> fields = form.GetFormFields();
                PdfFormField toSet;
                //Info Representante Empresa
                fields.TryGetValue("dia", out toSet);
                toSet.SetValue(DateTime.Now.ToString("dd"));
                fields.TryGetValue("mes", out toSet);
                toSet.SetValue(DateTime.Now.ToString("MMMM"));
                fields.TryGetValue("anno", out toSet);
                toSet.SetValue(DateTime.Now.ToString("yy"));
                fields.TryGetValue("nombre1", out toSet);
                toSet.SetValue(txtNombreRepresentante.Text);
                fields.TryGetValue("rut", out toSet);
                toSet.SetValue(txtRutRepresentante.Text);
                fields.TryGetValue("rangoEmpresa", out toSet);
                toSet.SetValue(txtRangoRepresentante.Text);

                //Info Empresa
                fields.TryGetValue("nombreEmpresa", out toSet);
                toSet.SetValue(txtNombreEmpresa.Text);
                fields.TryGetValue("rutEmpresa", out toSet);
                toSet.SetValue(txtRutEmpresa.Text);
                fields.TryGetValue("direccion", out toSet);
                toSet.SetValue(txtDirEmpresa.Text);
                fields.TryGetValue("numDireccion", out toSet);
                toSet.SetValue(txtNumEmpresa.Text);
                fields.TryGetValue("comuna", out toSet);
                toSet.SetValue(txtComunaEmpresa.Text);
                fields.TryGetValue("ciudad", out toSet);
                toSet.SetValue(txtCiudadEmpresa.Text);

                //Info Mandante
                fields.TryGetValue("nombre2", out toSet);
                toSet.SetValue(txtNombreMandatario.Text);
                fields.TryGetValue("rut2", out toSet);
                toSet.SetValue(txtRutMandatario.Text);
                fields.TryGetValue("nacionalidad2", out toSet);
                toSet.SetValue(txtNacionalidadMandatario.Text);
                fields.TryGetValue("oficio", out toSet);
                toSet.SetValue(txtOficioMandatario.Text);
                fields.TryGetValue("calle", out toSet);
                toSet.SetValue(txtDirMandatario.Text);
                fields.TryGetValue("numDireccion", out toSet);
                toSet.SetValue(txtNumMandatario.Text);
                fields.TryGetValue("ciudad2", out toSet);
                toSet.SetValue(txtCiudadMandatario.Text);
                fields.TryGetValue("comuna", out toSet);
                toSet.SetValue(txtComunaMandatario.Text);

                //Compromiso
                fields.TryGetValue("diaNacimiento", out toSet);
                toSet.SetValue(FechaNacimientoMandatario.SelectedDate.Value.ToString("dd"));
                fields.TryGetValue("mesNacimiento", out toSet);
                toSet.SetValue(FechaNacimientoMandatario.SelectedDate.Value.ToString("MMMM"));
                fields.TryGetValue("annoNacimiento", out toSet);
                toSet.SetValue(FechaNacimientoMandatario.SelectedDate.Value.ToString("yy"));
                fields.TryGetValue("compromiso", out toSet);
                toSet.SetValue(txtCompromiso.Text);
                fields.TryGetValue("nombreProyecto", out toSet);
                toSet.SetValue(txtNomProyecto.Text);
                fields.TryGetValue("pago", out toSet);
                toSet.SetValue(txtPago.Text);
                fields.TryGetValue("fecha", out toSet);
                toSet.SetValue(DateTime.Now.ToString("dd/MMMM/yyyy"));
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
                    rut_cliente_pres = txtRutEmpresa.Text,
                    cod_tramite = VistaRecepcionista.codTramite,
                    empleado_rut = MainWindow.rutEmpleado
                };

                if (doc.Create())
                {
                    MessageBox.Show("Documento creado correctamente", "Éxito");
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el documento, intentelo nuevamente", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debes llenar todos los campos", "Error");
            }
        }
        private void limpiarCampos()
        {
            txtCiudadEmpresa.Text = string.Empty;
            txtCiudadMandatario.Text = string.Empty;
            txtCompromiso.Text = string.Empty;
            txtComunaEmpresa.Text = string.Empty;
            txtDirEmpresa.Text = string.Empty;
            txtDirMandatario.Text = string.Empty;
            txtNacionalidadMandatario.Text = string.Empty;
            txtNombreEmpresa.Text = string.Empty;
            txtNombreMandatario.Text = string.Empty;
            txtNombreRepresentante.Text = string.Empty;
            txtNomProyecto.Text = string.Empty;
            txtNumEmpresa.Text = string.Empty;
            txtNumMandatario.Text = string.Empty;
            txtComunaMandatario.Text = string.Empty;
            txtOficioMandatario.Text = string.Empty;
            txtPago.Text = string.Empty;
            txtRangoRepresentante.Text = string.Empty;
            txtRutEmpresa.Text = string.Empty;
            txtRutMandatario.Text = string.Empty;
            txtRutRepresentante.Text = string.Empty;
        }
    }
}
