using Biblioteca_de_Clases;
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

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para HistorialDocumentos.xaml
    /// </summary>
    public partial class HistorialDocumentos : Window
    {
        public HistorialDocumentos()
        {
            InitializeComponent();
            dgDocumentos.Visibility = Visibility.Collapsed;
            txtRutBuscado.Visibility = Visibility.Collapsed;
            btnBuscar.Visibility = Visibility.Collapsed;
            LlenaDataGrid();
        }

        private void btnDocumentos_Click(object sender, RoutedEventArgs e)
        {
            dgDocumentos.Visibility = Visibility.Visible;
            txtRutBuscado.Visibility = Visibility.Visible;
            btnBuscar.Visibility = Visibility.Visible;
        }

        private void LlenaDataGrid()
        {
            Doc_Emitido doc_emitido = new Doc_Emitido();

            dgDocumentos.ItemsSource = doc_emitido.ReadAll();
            dgDocumentos.Items.Refresh();
        }

        private void txtRutBuscado_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doc_Emitido documento = new Doc_Emitido();
            if (txtRutBuscado.Text != String.Empty)
            {
                if (txtRutBuscado.IsFocused)
                {
                    dgDocumentos.ItemsSource = documento.Buscar_Documento(txtRutBuscado.Text);
                    dgDocumentos.Items.Refresh();
                }
            }
            else
            {
                LlenaDataGrid();
            }
        }
    }
}
