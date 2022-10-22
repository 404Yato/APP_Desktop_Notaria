using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteca_de_Clases;

namespace Notaria_WPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para FormCartaRenuncia.xaml
    /// </summary>
    public partial class FormCartaRenuncia : Page
    {
        string path = @"..\Doc_Notarial\Origen\Carta de Renuncia.pdf";
        string path3 = @"..\Doc_Notarial\Destino\Carta de Renuncia.pdf";
        public FormCartaRenuncia()
        {
            InitializeComponent();
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            PdfDocument pdf = new PdfDocument(new PdfReader(path), new PdfWriter(path3));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
            IDictionary<String, PdfFormField> fields = form.GetFormFields();
            PdfFormField toSet;

            //Datos Contratante
            fields.TryGetValue("nombre", out toSet);
            toSet.SetValue(txb_nomContratante.Text);

            //Datos Renunciante
            fields.TryGetValue("profesion", out toSet);
            toSet.SetValue(txb_areaTrabajo.Text);
            fields.TryGetValue("dia", out toSet);
            toSet.SetValue(txb_dia.Text);
            fields.TryGetValue("mes", out toSet);
            toSet.SetValue(txb_mes.Text);

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
                rut_cliente_pres = txb_rut.Text,
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
            txb_nomContratante.Text = String.Empty;
            txb_areaTrabajo.Text = String.Empty;
            txb_mes.Text = String.Empty;
            txb_dia.Text = String.Empty;
            txb_rut.Text = String.Empty;
        }
    }
}
