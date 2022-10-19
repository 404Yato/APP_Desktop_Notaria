using Biblioteca_de_Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para ActualizarArchivo.xaml
    /// </summary>
    public partial class ActualizarArchivo : Window
    {
        public ActualizarArchivo()
        {
            InitializeComponent();
        }


        private void cerrarBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void subirArchivo_Click(object sender, RoutedEventArgs e)
        {
            TemplatesCRUD templatesCRUD = new TemplatesCRUD();

            template_documento template_Documento = new template_documento()
            {
                nombre = nombreTxt.Text,
            };

            if (template_Documento.Update())
            {

                MessageBox.Show("Creado correctamente");

            }
            else
            {
                MessageBox.Show("No se pudo crear el template");
            }
        }
    }
}
