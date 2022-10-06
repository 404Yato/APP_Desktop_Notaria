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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Biblioteca_clases;



namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para Administracion.xaml
    /// </summary>
    public partial class Administracion : Window
    {
        public Administracion()
        {
            InitializeComponent();
            
            
        }
        
        private void llenardatagridPerfil()
        {
            Perfil pf = new Perfil();
            dg_rols.ItemsSource = pf.ReadAll();
            dg_rols.Items.Refresh();
        }

        #region Visibilidad Perfil
        //Mostrar Todo de Perfil
        private void MostrarPerfil() {
            tb_introid.Visibility = Visibility.Visible;
            lb_introid.Visibility = Visibility.Visible;
            lb_asignarrol.Visibility = Visibility.Visible;
            tb_asignarrol.Visibility = Visibility.Visible;
            btn_agregarrol.Visibility = Visibility.Visible;
            btn_eliminarrol.Visibility = Visibility.Visible;
            dg_rols.Visibility = Visibility.Visible;
            rec_perfil.Visibility = Visibility.Visible;
            lb_titulo2.Visibility = Visibility.Visible;
            lb_titulo_perfil.Visibility = Visibility.Visible;
            //titulo de Gestion de perfiles
            lb_titulo_personal.Visibility = Visibility.Collapsed;
        }
        //Ocultar Todo de Perfil
        private void SacarPerfil() {
            tb_introid.Visibility = Visibility.Collapsed;
            lb_introid.Visibility = Visibility.Collapsed;
            lb_asignarrol.Visibility = Visibility.Collapsed;
            tb_asignarrol.Visibility = Visibility.Collapsed;
            btn_agregarrol.Visibility = Visibility.Collapsed;
            btn_eliminarrol.Visibility = Visibility.Collapsed;
            dg_rols.Visibility = Visibility.Collapsed;
            rec_perfil.Visibility = Visibility.Collapsed;
            lb_titulo_perfil.Visibility = Visibility.Collapsed;
            lb_titulo2.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Cargar Combo Box
        // CARGAR COMBOBOX PERFIL
        private void CargarComboBoxPerfil()
        {
            /* Carga todas los combobox con las actividad de empresa*/
            Perfil pf = new Perfil();
            cbx_selc_empleado.ItemsSource = pf.ReadAll();

            /* Configura los datos en el ComboBOx */
            cbx_selc_empleado.DisplayMemberPath = "rol"; //Propiedad para mostrar
            cbx_selc_empleado.SelectedValuePath = "cod_perfil"; //Propiedad con el valor a rescatar
            cbx_selc_empleado.SelectedIndex = -1; //Posiciona en el primer registro
        }
        //CARGAR COMBOBOX REGION
        private void CargarComboBoxRegion()
        {
            /* Carga todas los combobox con las actividad de empresa*/
            Region pf = new Region();
            cbx_region_empleado.ItemsSource = pf.ReadAll();
            /* Configura los datos en el ComboBOx */
            cbx_region_empleado.DisplayMemberPath = "nombre"; //Propiedad para mostrar
            cbx_region_empleado.SelectedValuePath = "cod_region"; //Propiedad con el valor a rescatar
            cbx_region_empleado.SelectedIndex = -1; //Posiciona en el primer registro

        }
        // CARGAR COMBOBOX COMUNA CON PROCESO ALMACENADO
        private void Combo()
        {       
            LlenarCombo cm = new LlenarCombo();
            string varible = (string)cbx_region_empleado.SelectedValue;
            cbx_Comuna_empleado.ItemsSource = cm.Llenar(varible);
            cbx_Comuna_empleado.DisplayMemberPath = "nombre";
            cbx_Comuna_empleado.SelectedValuePath = "cod_comuna";
            cbx_Comuna_empleado.SelectedIndex = -1;
        }

        #endregion

        #region Visibilidad Empleado
        private void SacarEmpleadoAgregar()
        {
            lb_ing_apmE.Visibility = Visibility.Collapsed;
            lb_ing_appE.Visibility = Visibility.Collapsed;
            lb_ing_rutE.Visibility = Visibility.Collapsed;
            lb_ing_dirE.Visibility = Visibility.Collapsed;
            lb_ing_emaE.Visibility = Visibility.Collapsed;
            lb_ing_nomE.Visibility = Visibility.Collapsed;
            lb_ing_numE.Visibility = Visibility.Collapsed;
            lb_titulo_agreE.Visibility = Visibility.Collapsed;
            lb_ing_comE.Visibility = Visibility.Collapsed;
            lb_ing_regE.Visibility = Visibility.Collapsed;
            lb_ing_perfilE.Visibility = Visibility.Collapsed;
            cbx_Comuna_empleado.Visibility = Visibility.Collapsed;
            cbx_region_empleado.Visibility = Visibility.Collapsed;         
            cbx_selc_empleado.Visibility = Visibility.Collapsed;
            txb_apellM_empleado.Visibility = Visibility.Collapsed;
            txb_apllP_empleado.Visibility = Visibility.Collapsed;
            txb_dirc_empleado.Visibility = Visibility.Collapsed;
            txb_email_empleado.Visibility = Visibility.Collapsed;
            txb_fono_empleado.Visibility = Visibility.Collapsed;
            txb_nom_empleado.Visibility = Visibility.Collapsed;
            txb_rut_empleado.Visibility = Visibility.Collapsed;
            btn_ing_AgrEmpl.Visibility = Visibility.Collapsed;
            btn_volver_AgregarEmpleado.Visibility = Visibility.Collapsed;
            lb_titulo_personal.Visibility = Visibility.Collapsed;
            
        }
        private void MostrarEmpleadoAgregar()
        {
            lb_ing_apmE.Visibility = Visibility.Visible;
            lb_ing_appE.Visibility = Visibility.Visible;
            lb_ing_rutE.Visibility = Visibility.Visible;
            lb_ing_dirE.Visibility = Visibility.Visible;
            lb_ing_emaE.Visibility = Visibility.Visible;
            lb_ing_nomE.Visibility = Visibility.Visible;
            lb_ing_numE.Visibility = Visibility.Visible;
            lb_titulo_agreE.Visibility = Visibility.Visible;
            lb_ing_comE.Visibility = Visibility.Visible;
            lb_ing_regE.Visibility = Visibility.Visible;
            lb_ing_perfilE.Visibility = Visibility.Visible;
            cbx_selc_empleado.Visibility = Visibility.Visible;
            cbx_Comuna_empleado.Visibility = Visibility.Visible;
            cbx_region_empleado.Visibility = Visibility.Visible;
            txb_apellM_empleado.Visibility = Visibility.Visible;
            txb_apllP_empleado.Visibility = Visibility.Visible;           
            txb_dirc_empleado.Visibility = Visibility.Visible;
            txb_email_empleado.Visibility = Visibility.Visible;
            txb_fono_empleado.Visibility = Visibility.Visible;
            txb_nom_empleado.Visibility = Visibility.Visible;
            txb_rut_empleado.Visibility = Visibility.Visible;
            btn_ing_AgrEmpl.Visibility = Visibility.Visible;
            btn_volver_AgregarEmpleado.Visibility = Visibility.Visible;
        }
        private void MostrarEmpleados()
        {
            btn_list_empleados.Visibility = Visibility.Visible;
            btn_agregar_empleados.Visibility = Visibility.Visible;
            lb_titulo_personal.Visibility = Visibility.Visible;
            img_agregar_empleado.Visibility = Visibility.Visible;
            img_list_empleado.Visibility = Visibility.Visible;
            rec_empleados.Visibility = Visibility.Visible;
            rec_empleados2.Visibility = Visibility.Visible;

        }
        private void SacarEmpleados()
        {
            btn_list_empleados.Visibility = Visibility.Hidden;
            btn_agregar_empleados.Visibility = Visibility.Hidden;            
            img_agregar_empleado.Visibility = Visibility.Hidden;
            img_list_empleado.Visibility = Visibility.Hidden;
            rec_empleados.Visibility = Visibility.Hidden;
            rec_empleados2.Visibility = Visibility.Hidden;
            
        }
        #endregion

        #region Validacion Empleado
        //Validar los campos de Perfil que no esten vacíos
        private bool ValidarTextbox_Perfil()
        {
            bool validar = true;
            if (tb_introid.Text == string.Empty)
            {
                validar = false;
            }
            if (tb_asignarrol.Text == string.Empty)
            {
                validar = false;
            }
            return validar;
        }
        //Limpiar los campos de Perfil 
        private void limpiar_campos_perfil()
        {
            tb_introid.Text = string.Empty;
            tb_asignarrol.Text = string.Empty;
        }

        #endregion

        #region Validacion Empleado
        private bool ValidarTextbox_Empleado()
        {
            bool validar = true;
            if (txb_rut_empleado.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_nom_empleado.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_apllP_empleado.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_apellM_empleado.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_fono_empleado.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_dirc_empleado.Text == string.Empty)
            {
                validar = false;
            }
            if (cbx_region_empleado.SelectedIndex == -1)
            {
                validar = false;
            }
            if (cbx_Comuna_empleado.SelectedIndex == -1)
            {
                validar = false;
            }
            if (cbx_selc_empleado.SelectedIndex == -1)
            {
                validar = false;
            }
            if (txb_email_empleado.Text == string.Empty)
            {
                validar = false;
            }

            return validar;
        }
        private void limpiarEmpleado()
        {
            cbx_region_empleado.SelectedIndex = -1;
            cbx_Comuna_empleado.SelectedIndex = -1;
            cbx_selc_empleado.SelectedIndex = -1;
            txb_apellM_empleado.Text = string.Empty;
            txb_apllP_empleado.Text = string.Empty;
            txb_dirc_empleado.Text = string.Empty;
            txb_email_empleado.Text = string.Empty;
            txb_fono_empleado.Text = string.Empty;
            txb_nom_empleado.Text = string.Empty;
            txb_rut_empleado.Text = string.Empty;
        }
        #endregion
      
        private void Button_Click_Perfil(object sender, RoutedEventArgs e)
        {
            MostrarPerfil();
            SacarEmpleados();
            SacarEmpleadoAgregar();
            llenardatagridPerfil();
        }

        private void Button_Click_Personal(object sender, RoutedEventArgs e)
        {
            SacarPerfil();
            SacarEmpleadoAgregar();
            MostrarEmpleados();
            
        }

        private void Button_Click_Documentos(object sender, RoutedEventArgs e)
        {
            SacarPerfil();
            SacarEmpleados();
            SacarEmpleadoAgregar();
        }

        private void btn_agregarrol_Click(object sender, RoutedEventArgs e)
        {
            //lista de perfil         
            if (ValidarTextbox_Perfil())
            {
                Perfil pf = new Perfil() 
                {
                    cod_perfil = tb_introid.Text,
                    rol = tb_asignarrol.Text
                };
                if (pf.Create())
                {
                    MessageBox.Show("Perfil agregado correctamente a la base de datos", "Perfil Creado!!!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiar_campos_perfil();
                    llenardatagridPerfil();
                }
                else 
                {
                    MessageBox.Show("Error al agregar Perfil", "Error !!!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else {
                MessageBox.Show("Ups los campos estan vacíos", "Campos Vacíos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_eliminarrol_Click(object sender, RoutedEventArgs e)
        {
            Perfil pf = (Perfil)dg_rols.SelectedItem;
            pf.Delete();
            llenardatagridPerfil();

        }

        private void btn_agregar_empleados_Click(object sender, RoutedEventArgs e)
        {
            limpiarEmpleado();
            SacarEmpleados();
            MostrarEmpleadoAgregar();
            CargarComboBoxPerfil();
            CargarComboBoxRegion();
        }

        private void cbx_region_empleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            Combo();
        }
        private void BotonVolverGestionPersonal(object sender, RoutedEventArgs e)
        {
            SacarEmpleadoAgregar();
            MostrarEmpleados();
        }

        private void btn_ing_AgrEmpl_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarTextbox_Empleado())
            {
                Empleado pf = new Empleado()
                { 
                    rut = txb_rut_empleado.Text,
                    nombre = txb_nom_empleado.Text,
                    apellido_paterno = txb_apllP_empleado.Text,
                    apellido_materno = txb_apellM_empleado.Text,
                    fono = int.Parse(txb_fono_empleado.Text),
                    direccion = txb_dirc_empleado.Text,
                    cod_comuna = (string)cbx_Comuna_empleado.SelectedValue,
                    cod_perfil = (string)cbx_selc_empleado.SelectedValue,
                    email = txb_email_empleado.Text
                };
          
                if (pf.Create())
                {
                    MessageBox.Show("Nuevo Empleado agregado correctamente al sistema", "Nuevo Empleado Creado!!!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarEmpleado();

                }
                else
                {
                    MessageBox.Show("Error al agregar Nuevo Empleado", "Error !!!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Ups los campos estan vacíos", "Campos Vacíos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
