using Biblioteca_de_Clases;
using Notaria.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dgReservas.Visibility = Visibility.Collapsed;
            txtRutBuscado.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Collapsed;
            cbEstadoReserva.Visibility = Visibility.Collapsed;
            lbRut.Visibility = Visibility.Collapsed;
            LlenaDataGrid();
            CargarComboBox();
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
            btnModificar.Visibility = Visibility.Visible;
            cbEstadoReserva.Visibility = Visibility.Visible;
            lbRut.Visibility = Visibility.Visible;
        }

        private void BuscarReserva()
        {
            Reserva reserva = new Reserva();
            if(txtRutBuscado.Text != string.Empty)
            {
                    dgReservas.ItemsSource = reserva.BuscarReserva(txtRutBuscado.Text);
                    dgReservas.Items.Refresh();
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if(dgReservas.SelectedItem != null)
            {
                if(cbEstadoReserva.SelectedValue != null)
                {
                    if(txtRutBuscado.Text != "")
                    {
                        Notaria.Datos.buscar_reservas_Result seleccionado = (buscar_reservas_Result)dgReservas.SelectedItem;
                        Reserva reserva = new Reserva()
                        {
                            cod_reserva = seleccionado.cod_reserva,
                            fecha_hora = seleccionado.fecha_hora,
                            motivo = seleccionado.motivo,
                            estado = (string)cbEstadoReserva.SelectedValue,
                            usuario_rut = seleccionado.usuario_rut,
                            cod_tramite = seleccionado.cod_tramite
                        };
                        if (reserva.Update())
                        {
                            MessageBox.Show("Se actualizó el estado de la reserva", "Éxito", MessageBoxButton.OK);
                            BuscarReserva();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo el estado de la reserva", "Error", MessageBoxButton.OK);
                        };
                    }
                    else
                    {
                        Reserva seleccionado = (Reserva)dgReservas.SelectedItem;
                        Reserva reserva = new Reserva()
                        {
                            cod_reserva = seleccionado.cod_reserva,
                            fecha_hora = seleccionado.fecha_hora,
                            motivo = seleccionado.motivo,
                            estado = (string)cbEstadoReserva.SelectedValue,
                            usuario_rut = seleccionado.usuario_rut,
                            cod_tramite = seleccionado.cod_tramite
                        };
                        if (reserva.Update())
                        {
                            MessageBox.Show("Se actualizó el estado de la reserva", "Éxito", MessageBoxButton.OK);
                            LlenaDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo el estado de la reserva", "Error", MessageBoxButton.OK);
                        };
                    }
                }
                else
                {
                    MessageBox.Show("¡Debe seleccionar a que estado desea actualizar la reserva!", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("¡Debe seleccionar la reserva que desea modificar!", "Error", MessageBoxButton.OK);
            }
        }

        private void CargarComboBox()
        {
            //Crear Lista con los estados de las reservas
            List<EstadosReserva> estados = new List<EstadosReserva>();
            estados.Add(new EstadosReserva { IdEstado = 1, Estado = "Reservada" });
            estados.Add(new EstadosReserva { IdEstado = 2, Estado = "Cerrada" });
            estados.Add(new EstadosReserva { IdEstado = 3, Estado = "Inasistencia" });
            estados.Add(new EstadosReserva { IdEstado = 4, Estado = "Cancelada" });
            
            /* Cargar combobox cbEstadoReserva*/
            cbEstadoReserva.ItemsSource = estados;
            cbEstadoReserva.DisplayMemberPath = "Estado"; //Propiedad para mostrar
            cbEstadoReserva.SelectedValuePath = "Estado"; //Propiedad con el valor a rescatar
            cbEstadoReserva.SelectedIndex = -1; //Posiciona el combobox en Null
            


            /* Configura los datos en el ComboBOx */

        }

        private void dgReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reserva seleccion = dgReservas.SelectedItem as Reserva;

        }

        private void CerrarSesion(object sender, RoutedEventArgs e)                                 // BOTON CERRAR SESIÓN
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
    }
}
