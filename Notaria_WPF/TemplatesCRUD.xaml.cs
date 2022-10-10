using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Threading;
using Biblioteca_de_Clases;
using Microsoft.Win32;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para TemplatesCRUD.xaml
    /// </summary>
    public partial class TemplatesCRUD : Window
    {
        public TemplatesCRUD()
        {
            InitializeComponent();
            llenadoDocumento();
            OcultarElementos();
        }


        private void OcultarElementos()
        {
            gridDocumento.Visibility = Visibility.Collapsed;
            actualizarBtn.Visibility = Visibility.Collapsed;
            eliminarBtn.Visibility = Visibility.Collapsed;
            crearBtn.Visibility = Visibility.Collapsed;
            TituloLb.Visibility = Visibility.Collapsed;
            IdLb.Visibility = Visibility.Collapsed;
            idTxt.Visibility = Visibility.Collapsed;
            datoTxt.Visibility = Visibility.Collapsed;
            UrlLb.Visibility = Visibility.Collapsed;
            nombreTxt.Visibility = Visibility.Collapsed;
            nombreLb.Visibility = Visibility.Collapsed;
            ExaminaBtn.Visibility = Visibility.Collapsed;
            SubirBtn.Visibility = Visibility.Collapsed;
            CerrarBtn.Visibility = Visibility.Collapsed;
            BordeBn.Visibility = Visibility.Collapsed;
            NombreActualizarBtn.Visibility = Visibility.Collapsed;
            NombreActualizarLb.Visibility = Visibility.Collapsed;
            ModificarActualizarBtn.Visibility = Visibility.Collapsed;
            CerrarActualziarBtn.Visibility = Visibility.Collapsed;
            BordeActualizarBd.Visibility = Visibility.Collapsed;
            TitulosActualizarLb.Visibility = Visibility.Collapsed;


        }

        private void MostrarActualizar()
        {
            NombreActualizarBtn.Visibility = Visibility.Visible;
            NombreActualizarLb.Visibility = Visibility.Visible;
            ModificarActualizarBtn.Visibility = Visibility.Visible;
            CerrarActualziarBtn.Visibility = Visibility.Visible;
            BordeActualizarBd.Visibility = Visibility.Visible;
            TitulosActualizarLb.Visibility = Visibility.Visible;
        }


        private void MostrarVisible()
        {
            gridDocumento.Visibility = Visibility.Visible;
            actualizarBtn.Visibility = Visibility.Visible;
            eliminarBtn.Visibility = Visibility.Visible;
            crearBtn.Visibility = Visibility.Visible;
        }

        private void MostrarCrear()
        {
            TituloLb.Visibility = Visibility.Visible;
            IdLb.Visibility = Visibility.Visible;
            idTxt.Visibility = Visibility.Visible;
            datoTxt.Visibility = Visibility.Visible;
            UrlLb.Visibility = Visibility.Visible;
            nombreTxt.Visibility = Visibility.Visible;
            nombreLb.Visibility = Visibility.Visible;
            ExaminaBtn.Visibility = Visibility.Visible;
            SubirBtn.Visibility = Visibility.Visible;
            CerrarBtn.Visibility = Visibility.Visible;
        }

        

        private void Button_Click_Documentos(object sender, RoutedEventArgs e)
        {
            
            MostrarVisible();
        }
    

        public void llenadoDocumento()
        {
            template_documento template = new template_documento();
            gridDocumento.ItemsSource = template.ReadAll();
            gridDocumento.Items.Refresh();
            
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

            OcultarElementos();
            llenadoDocumento();
            MostrarVisible();
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


        private void ventanaGuardarArchivo_Click(object sender, RoutedEventArgs e)
        {
            OcultarElementos();
            MostrarCrear();
           
        }


        private void eliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            template_documento template = (template_documento)gridDocumento.SelectedItem;
            template.Delete();
            llenadoDocumento();
        }



        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            OcultarElementos();
            MostrarActualizar();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void gridDocumento_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            llenadoDocumento();
        }



        public void GuardarTemplate()
        {

        }

        private void gridDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void gridDocumento_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void gridDocumento_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click_Personal(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Perfil(object sender, RoutedEventArgs e)
        {

        }

        private void cerrarBtn_Click(object sender, RoutedEventArgs e)
        {
            OcultarElementos();
            llenadoDocumento();
            MostrarVisible();
        }

        private void ModificarArchivo_Click(object sender, RoutedEventArgs e)
        {
            template_documento seleccionado = (template_documento)gridDocumento.SelectedItem;
            template_documento template = new template_documento
            {
                cod_template = seleccionado.cod_template,
                nombre = NombreActualizarBtn.Text,
                template = seleccionado.template,
                fecha_subida = DateTime.Now,
            };

            if (template.Update())
            {

                MessageBox.Show("Actualizado correctamente");

            }
            else
            {
                MessageBox.Show("No se pudo actualizar el template");
            }
        }
    }
}
