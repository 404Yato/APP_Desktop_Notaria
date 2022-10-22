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

namespace Notaria_WPF
{
    /// <summary>
    /// Interaction logic for VistaBienesRaices.xaml
    /// </summary>
    public partial class VistaBienesRaices : Window
    {
        String path;

        public VistaBienesRaices()
        {
            InitializeComponent();
            LlenarGridDocEmitido();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            LlenarGridDocEmitido();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            TxtHora.Text = DateTime.Now.ToString();
        }

        private void LlenarGridDocEmitido()
        {
            Doc_Emitido doc_emitido = new Doc_Emitido();

            DtBRaices.ItemsSource = doc_emitido.LlenarGrid();
            DtBRaices.Items.Refresh();
        }
        Notaria.Datos.PortafolioEntities contexto = new Notaria.Datos.PortafolioEntities();
        private void BtnAbrirPDF(object sender, RoutedEventArgs e)
        {
            if (DtBRaices.SelectedIndex != -1)
            {
                SP_LlenarDGVistasOF_Result seleccionado = (SP_LlenarDGVistasOF_Result)DtBRaices.SelectedItem;
                Process AbrirPDF = new Process();
                string path2 = @"..\Doc_Notarial\Archivos Temporales\" + seleccionado.cod_documento + ".pdf";
                File.WriteAllBytes(path2, seleccionado.copia_documento);
                AbrirPDF.StartInfo.FileName = @"..\Doc_Notarial\Archivos Temporales\" + seleccionado.cod_documento + ".pdf";
                AbrirPDF.Start();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo");
            }
        }
        private void BtnClickDescarga(object sender, RoutedEventArgs e)
        {
            if (DtBRaices.SelectedIndex != -1)
            {
                SP_LlenarDGVistasOF_Result template = (SP_LlenarDGVistasOF_Result)DtBRaices.SelectedItem;
                SP_LlenarDGVistasOF_Result seleccionado = (SP_LlenarDGVistasOF_Result)DtBRaices.SelectedItem;

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
        private void Button_Click_Actualizar(object sender, RoutedEventArgs e)
        {
            LlenarGridDocEmitido();
        }
    }
}
