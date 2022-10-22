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
using Biblioteca_de_Clases;
using Notaria.Datos;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para VistaCajero.xaml
    /// </summary>
    public partial class VistaCajero : Window
    {
        public VistaCajero()
        {
            InitializeComponent();
            txtRutBuscado.Visibility = Visibility.Collapsed;
            dgVentas.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Collapsed;
            lbRut.Visibility = Visibility.Collapsed;
            btnRefresh.Visibility = Visibility.Collapsed;
            LlenaDataGrid();
        }

        private void txtRutBuscado_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarReserva();
        }

        private void BuscarReserva()
        {
            Ventas_presencial ventas = new Ventas_presencial();
            if (txtRutBuscado.Text != string.Empty)
            {
                    dgVentas.ItemsSource = ventas.BuscarVentasPres(txtRutBuscado.Text);
                    dgVentas.Items.Refresh();
            }
            else
            {
                LlenaDataGrid();
            }

        }

        private void LlenaDataGrid()
        {
            Ventas_presencial ventas = new Ventas_presencial();

            dgVentas.ItemsSource = ventas.BuscarVentasPendientes("Pendiente");
            dgVentas.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtRutBuscado.Visibility = Visibility.Visible;
            dgVentas.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            lbRut.Visibility = Visibility.Visible;
            btnRefresh.Visibility = Visibility.Visible;

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgVentas.SelectedItem != null)
            {
                if(txtRutBuscado.Text != "")
                {
                    buscar_ventas_pres_Result seleccionado = (buscar_ventas_pres_Result)dgVentas.SelectedItem;
                    Ventas_presencial venta = new Ventas_presencial()
                    {
                        cod_venta = seleccionado.cod_venta,
                        amount = seleccionado.amount,
                        transaction_date = seleccionado.transaction_date,
                        rut_persona = seleccionado.rut_persona,
                        estado = "Pagado",
                        doc_emitido_cod_documento = seleccionado.doc_emitido_cod_documento
                    };
                    if (MessageBox.Show("¿Desea cambiar el estado de la venta a Pagada?", "Atención", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                    {
                        if (venta.Update())
                        {
                            MessageBox.Show("Se cambio el estado de la venta correctamente", "Éxito", MessageBoxButton.OK);
                            BuscarReserva();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo el estado de la venta", "Error", MessageBoxButton.OK);
                        };
                    }
                    else
                    {
                        BuscarReserva();
                    }
                }
                else
                {
                    buscar_ventas_pendientes_Result seleccionado = (buscar_ventas_pendientes_Result)dgVentas.SelectedItem;
                    Ventas_presencial venta = new Ventas_presencial()
                    {
                        cod_venta = seleccionado.cod_venta,
                        amount = seleccionado.amount,
                        transaction_date = seleccionado.transaction_date,
                        rut_persona = seleccionado.rut_persona,
                        estado = "Pagado",
                        doc_emitido_cod_documento = seleccionado.doc_emitido_cod_documento
                    };
                    if (MessageBox.Show("¿Desea cambiar el estado de la venta a Pagada?", "Atención", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                    {
                        if (venta.Update())
                        {
                            MessageBox.Show("Se cambio el estado de la venta correctamente", "Éxito", MessageBoxButton.OK);
                            LlenaDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo el estado de la venta", "Error", MessageBoxButton.OK);
                        };
                    }
                    else
                    {
                        LlenaDataGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("¡Debe seleccionar la reserva que desea modificar!", "Error", MessageBoxButton.OK);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LlenaDataGrid();
            txtRutBuscado.Text = "";
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
    }
}
