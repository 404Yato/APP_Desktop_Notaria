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
using System.Windows.Shapes;
using System.Windows.Threading;
using Biblioteca_de_Clases;
using Notaria.Datos;
using iText.Layout.Borders;
using System.Security.Policy;
using Microsoft.Win32;
using System.IO;
using iText.Kernel.Geom;
using System.Diagnostics;
using Biblioteca_clases;
using NotariaL;
using static iText.Kernel.Pdf.Colorspace.PdfDeviceCs;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Notaria_WPF
{
    /// <summary>
    /// Interaction logic for VistaNotario.xaml
    /// </summary>
    public partial class VistaNotario : Window
    {
        String path;

        public VistaNotario()
        {
            InitializeComponent();
            LlenarGridNotario();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            LlenarGridNotario();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            TxtHora.Text = DateTime.Now.ToString();
        }

        private void LlenarGridNotario()
        {
            Doc_Emitido doc_emitido = new Doc_Emitido();

            DtNotario.ItemsSource = doc_emitido.LlenarGridNotario();
            DtNotario.Items.Refresh();
        }
        Notaria.Datos.PortafolioEntities con = new Notaria.Datos.PortafolioEntities();
        private void BtnAbrirPDF(object sender, RoutedEventArgs e)
        {
            if (DtNotario.SelectedIndex != -1)
            {
                SP_LlenarGridNotario_Result seleccionado = (SP_LlenarGridNotario_Result)DtNotario.SelectedItem;
                Process AbrirPDF = new Process();
                string path2 = @"..\Doc_Notarial\Archivos Temporales\" + seleccionado.cod_documento + ".pdf";
                File.WriteAllBytes(path2, seleccionado.copia_documento);
                AbrirPDF.StartInfo.FileName = @"..\Doc_Notarial\Archivos Temporales\" + seleccionado.cod_documento + ".pdf";
                AbrirPDF.Start();
            }
        }
        private void BtnClickDescarga(object sender, RoutedEventArgs e)
        {
            if (DtNotario.SelectedIndex != -1)
            {
                SP_LlenarGridNotario_Result template = (SP_LlenarGridNotario_Result)DtNotario.SelectedItem;
                SP_LlenarGridNotario_Result seleccionado = (SP_LlenarGridNotario_Result)DtNotario.SelectedItem;

                string path2 = @"C:\Users\0fcru\Downloads\" + seleccionado.nombre_tramite + '-' + seleccionado.Nombre + ".pdf";
                File.WriteAllBytes(path2, seleccionado.copia_documento);
                path = path2;
                //path3 = @"..\Doc_Notarial\Destino\" + seleccionado.copia_documento + ".pdf"; 
                MessageBox.Show("Documento almacenado en: C:\\Descargas");
            }
        }
        private void CerrarSesion(object sender, RoutedEventArgs e)                                     // BOTON CERRAR SESIÓN
        {
            if (MessageBox.Show("Esta seguro que desea cerrar sesión", "¿Está seguro?",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow MW = new MainWindow();
                MW.Show();
                this.Close();
            }
            else { }

        }
        //Notaria.Datos.PortafolioEntities con = new Notaria.Datos.PortafolioEntities();
        private void Button_Click_Actualizar(object sender, RoutedEventArgs e)
        {
            LlenarGridNotario();
        }
    }
}
