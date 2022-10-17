using Biblioteca_de_Clases;
using Notaria.Datos;
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
using Notaria_WPF.Formularios;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para VistaRecepcionista.xaml
    /// </summary>
    
    public partial class VistaRecepcionista : Window
    {
        //Declaración de objetos referencia a paginas de formularios
        FormCartaPoder formCartaPoder = new FormCartaPoder();

        public VistaRecepcionista()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            OcultarReservas();
            OcultarDocumentos();
            LlenaDataGrid();
            CargarComboBox();
        }

        #region Reservas
        private void LimpiarCamposReservas()
        {
            txtRutBuscado.Text = String.Empty;
            cbEstadoReserva.SelectedIndex = -1;

        }

        private void OcultarReservas()
        {
            dgReservas.Visibility = Visibility.Collapsed;
            txtRutBuscado.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Collapsed;
            cbEstadoReserva.Visibility = Visibility.Collapsed;
            lbRut.Visibility = Visibility.Collapsed;
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
            OcultarDocumentos();
            LimpiarCamposReservas();
            OcultarControlesTramite();
        }

        private void BuscarReserva()
        {
            Reserva reserva = new Reserva();
            if (txtRutBuscado.Text != string.Empty)
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
            if (dgReservas.SelectedItem != null)
            {
                if (cbEstadoReserva.SelectedValue != null)
                {
                    if (txtRutBuscado.Text != "")
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

        }

        private void dgReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reserva seleccion = dgReservas.SelectedItem as Reserva;

        }
        #endregion

        #region Documentos
        private void btn_docs_Click(object sender, RoutedEventArgs e)
        {
            cbTipoTramite.Visibility = Visibility.Visible;
            lbTipoTramite.Visibility = Visibility.Visible;
            OcultarReservas();
            OcultarControlesTramite();
            LimpiarCamposTramites();
            CargarComboTipoTramite();
        }
        private void LimpiarCamposTramites()
        {
            txbDesc.Text = String.Empty;
            txbRequisitos.Text = String.Empty;
            txtPrecio.Text = String.Empty;
            cbTipoTramite.SelectedIndex = -1;
        }

        private void OcultarDocumentos()
        {
            cbTipoTramite.Visibility = Visibility.Collapsed;
            lbTipoTramite.Visibility = Visibility.Collapsed;
        }

        private void CargarComboTipoTramite()
        {
            Tipo_tramite tramites = new Tipo_tramite();
            cbTipoTramite.ItemsSource = tramites.ReadAll();
            cbTipoTramite.DisplayMemberPath = "nombre_tramite"; //Propiedad para mostrar
            cbTipoTramite.SelectedValuePath = "cod_tramite"; //Propiedad con el valor a rescatar
            cbTipoTramite.SelectedIndex = -1; //Posiciona el combobox en Null

        }
        private void OcultarControlesTramite()
        {
            lbDesc.Visibility = Visibility.Collapsed;
            lbNombreTramite.Visibility = Visibility.Collapsed;
            lbRequisitos.Visibility = Visibility.Collapsed;
            lbPrecio.Visibility = Visibility.Collapsed;
            txbDesc.Visibility = Visibility.Collapsed;
            txbRequisitos.Visibility = Visibility.Collapsed;
            txtPrecio.Visibility = Visibility.Collapsed;
            btnCrearDoc.Visibility = Visibility.Collapsed;
        }

        private void MostrarControlesTramite()
        {
            lbDesc.Visibility = Visibility.Visible;
            lbNombreTramite.Visibility = Visibility.Visible;
            lbRequisitos.Visibility = Visibility.Visible;
            lbPrecio.Visibility = Visibility.Visible;
            txbDesc.Visibility = Visibility.Visible;
            txbRequisitos.Visibility = Visibility.Visible;
            txtPrecio.Visibility = Visibility.Visible;
            btnCrearDoc.Visibility = Visibility.Visible;
        }
        private void MostrarInfoTramite()
        {
            MostrarControlesTramite();
            Tipo_tramite tramite = (Tipo_tramite)cbTipoTramite.SelectedItem;
            lbNombreTramite.Content = tramite.nombre_tramite;
            txbDesc.Text = tramite.descripcion;
            txbRequisitos.Text = tramite.requisitos;
            txtPrecio.Text = "$ " + tramite.precio.ToString();
        }

        private void cbTipoTramite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbTipoTramite.SelectedIndex != -1)
            {
                MostrarInfoTramite();
            }
        }

        #endregion

        private void btnCrearDoc_Click(object sender, RoutedEventArgs e)
        {
            OcultarControlesTramite();
            OcultarDocumentos();
            FrameFormularios.NavigationService.Navigate(formCartaPoder);
        }
    }
}
