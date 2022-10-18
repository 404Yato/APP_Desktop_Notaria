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

namespace Notaria_WPF.Formularios
{
    /// <summary>
    /// Lógica de interacción para FormDeclaracionJurada.xaml
    /// </summary>
    public partial class FormDeclaracionJurada : Page
    {
        public FormDeclaracionJurada()
        {
            InitializeComponent();
        }

        //Declaración Variables para Rutas de templates
        string path = @"..\Doc_Notarial\Origen\Declaración Jurada Simple.pdf";
        string path3 = @"..\Doc_Notarial\Destino\Declaración Jurada Simple.pdf";


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == null || txtApellido.Text == null || txtDireccion.Text == null || txtEstado.Text == null || txtRut.Text == null)
            {
                PdfDocument pdf = new PdfDocument(new PdfReader(path), new PdfWriter(path3));
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
                IDictionary<String, PdfFormField> fields = form.GetFormFields();
                PdfFormField toSet;
                fields.TryGetValue("nombre1", out toSet);
                toSet.SetValue(txtNombre.Text + " " + txtApellido.Text);
                fields.TryGetValue("direccion", out toSet);
                toSet.SetValue(txtDireccion.Text);
                fields.TryGetValue("estadoCivil", out toSet);
                toSet.SetValue(txtEstado.Text);
                fields.TryGetValue("Rut", out toSet);
                toSet.SetValue(txtRut.Text);
                form.FlattenFields();
                pdf.Close();
                limpiarCampos();
                MessageBox.Show("Documento creado correctamente", "Éxito");
            }
            else
            {
                MessageBox.Show("Debes llenar todos los campos", "Cuidado");
            }
            
        } 


        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtRut.Text = string.Empty;
        }
    }
}
