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
            dgReservas.Visibility = Visibility.Collapsed;
            txtRutBuscado.Visibility = Visibility.Collapsed;
            btnBuscar.Visibility = Visibility.Collapsed;
            LlenaDataGrid();
        }

        private void LlenaDataGrid()
        {
            Reserva reserva = new Reserva();
            
            dgReservas.ItemsSource = reserva.ReadAll();
            dgReservas.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            dgReservas.Visibility = Visibility.Visible;
            txtRutBuscado.Visibility = Visibility.Visible;
            btnBuscar.Visibility = Visibility.Visible;
        }

        private void BuscarReserva()
        {
            Reserva reserva = new Reserva();
            if(txtRutBuscado.Text != string.Empty)
            {
                if (txtRutBuscado.IsFocused)
                {
                    dgReservas.ItemsSource = from x in reserva.ReadAll() where (x.usuario_rut.StartsWith(txtRutBuscado.Text)) select new { x.cod_reserva, x.fecha_hora, x.motivo, x.estado, x.usuario_rut, x.cod_tramite };
                    dgReservas.Items.Refresh();
                }
            }
            else
            {
                LlenaDataGrid();
            }
            
        }

        private void txtRutBuscado_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarReserva();
        }
    }
}
