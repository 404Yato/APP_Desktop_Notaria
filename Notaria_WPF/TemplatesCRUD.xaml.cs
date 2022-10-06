using System;
using System.Collections;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using Biblioteca_de_Clases;

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
        }

        DispatcherTimer dispatcher = new DispatcherTimer();

        public void llenadoDocumento()
        {
            template_documento template = new template_documento();
            gridDocumento.ItemsSource = template.ReadAll();
            gridDocumento.Items.Refresh();
            
        }

        public void stopTimer()
        {
            dispatcher.Stop();
        }

        private void ventanaGuardarArchivo_Click(object sender, RoutedEventArgs e)
        {
            GuardarArchivo guardar = new GuardarArchivo();
            guardar.Show();

            //Timer que ejecuta la funcion "llenadoDocumentos" cada medio segundo 
            
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            dispatcher.Tick += (a, b) =>
            {
                llenadoDocumento();
            };

            dispatcher.Start();

            eliminarBtn.Visibility = Visibility.Collapsed;
        }


        private void eliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            template_documento template = (template_documento)gridDocumento.SelectedItem;
            template.Delete();
            llenadoDocumento();
        }

        

        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            stopTimer();
            template_documento template = (template_documento)gridDocumento.SelectedItem;
            ActualizarArchivo actualizarArchivo = new ActualizarArchivo();
            actualizarArchivo.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stopTimer();
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
            stopTimer();
        }
    }
}
