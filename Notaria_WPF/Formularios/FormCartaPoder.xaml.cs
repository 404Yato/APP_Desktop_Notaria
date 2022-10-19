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

namespace Notaria_WPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para FormCartaPoder.xaml
    /// </summary>
    public partial class FormCartaPoder : Page
    {
        //Declaración Variables para Rutas de templates
        string path = @"..\Doc_Notarial\Origen\Carta de Poder.pdf";
        string path3 = @"..\Doc_Notarial\Destino\Carta de Poder.pdf";
        public FormCartaPoder()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            PdfDocument pdf = new PdfDocument(new PdfReader(path), new PdfWriter(path3));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
            IDictionary<String, PdfFormField> fields = form.GetFormFields();
            PdfFormField toSet;
            fields.TryGetValue("nombre", out toSet);
            toSet.SetValue(txtNombre.Text + " " + txtApellidoP.Text + " " + txtApellidoM.Text);
            fields.TryGetValue("nombre2", out toSet);
            toSet.SetValue(txtNombre2.Text + " " + txtApellidoP2.Text + " " + txtApellidoM2.Text);
            fields.TryGetValue("dia", out toSet);
            toSet.SetValue(DateTime.Now.ToString("dd"));
            fields.TryGetValue("mes", out toSet);
            toSet.SetValue(DateTime.Now.ToString("MMMM"));
            fields.TryGetValue("anno", out toSet);
            toSet.SetValue(DateTime.Now.ToString("yy"));
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
                rut_cliente_pres = txtRut.Text,
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
            txtNombre.Text = String.Empty;
            txtApellidoP.Text = String.Empty;
            txtApellidoM.Text = String.Empty;
            txtNombre2.Text = String.Empty;
            txtApellidoP2.Text = String.Empty;
            txtApellidoM2.Text = String.Empty;
            txtRut.Text = String.Empty;
        }
    }
}
