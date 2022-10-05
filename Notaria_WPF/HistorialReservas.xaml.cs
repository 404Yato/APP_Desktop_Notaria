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
    /// Lógica de interacción para HistorialReservas.xaml
    /// </summary>
    public partial class HistorialReservas : Window
    {
        public HistorialReservas()
        {
            InitializeComponent();
            LlenaDataGrid();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LlenaDataGrid()
        {
            
            dgReservas.Visibility = Visibility.Collapsed;
            txtRutBuscado.Visibility = Visibility.Collapsed;
            btnBuscar.Visibility = Visibility.Collapsed;
            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reserva reserva = new Reserva();
            dgReservas.Visibility = Visibility.Visible;
            txtRutBuscado.Visibility = Visibility.Visible;
            btnBuscar.Visibility = Visibility.Visible;
            dgReservas.ItemsSource = reserva.ReadAll();
            dgReservas.Items.Refresh();
        }
    }
}
