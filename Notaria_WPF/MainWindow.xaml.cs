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
using MahApps.Metro.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using Biblioteca_de_Clases;
using System.IO;
using System.ServiceModel.Channels;
using System.Net;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {


        public MainWindow()
        {
            InitializeComponent();
            OcultarElementos();


        }

        private void Button_Click_Perfil(object sender, RoutedEventArgs e)
        {
            
        }


        private void OcultarElementos()
        {
            gridDocumento.Visibility = Visibility.Collapsed;
            actualizarBtn.Visibility = Visibility.Collapsed;
            eliminarBtn.Visibility = Visibility.Collapsed;
            crearBtn.Visibility = Visibility.Collapsed;
        }

        private void eliminarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ventanaGuardarArchivo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void actualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Personal(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Documentos(object sender, RoutedEventArgs e)
        {
            gridDocumento.Visibility = Visibility.Visible;
            actualizarBtn.Visibility = Visibility.Visible;
            eliminarBtn.Visibility = Visibility.Visible;
            crearBtn.Visibility = Visibility.Visible;
        }

        
    }
}
