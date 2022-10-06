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
using System.Windows.Shapes;
using Biblioteca_de_Clases;
using Microsoft.Win32;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para GuardarArchivo.xaml
    /// </summary>
    public partial class GuardarArchivo : Window
    {
        

        public GuardarArchivo()
        {
            InitializeComponent();
        }

        /*
        public delegate void UpdateDelegado(object sender, UpdateEventArgs args);
        public event UpdateDelegado UpdateEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void agregarGrid()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }*/

        public void UploadFile(string fullName)
        {
           
        }

        

        public void subirArchivo_Click(object sender, RoutedEventArgs e)
        {
            string filepath = datoTxt.Text;
            FileStream fStream = File.OpenRead(filepath);
            byte[] contents = new byte[fStream.Length];
            fStream.Read(contents, 0, (int)fStream.Length);
            fStream.Close();

            template_documento template = new template_documento()
            {
                cod_template = idTxt.Text,
                nombre = nombreTxt.Text,
                template = contents,
                fecha_subida = DateTime.Now,

            };

            if (template.Create())
            {

                MessageBox.Show("creado correctamente");

            }
            else
            {
                MessageBox.Show("No se pudo crear el template");
            }


        }

        public void cancelar_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        public void examinar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".pdf"; // Default file extension
            openFileDialog.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension
            openFileDialog.Multiselect = false;

            bool? response = openFileDialog.ShowDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (response == true)
            {
                string filepath = openFileDialog.FileName;
                datoTxt.Text = filepath;
                //UploadFile(filepath);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
