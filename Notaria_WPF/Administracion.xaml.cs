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

        #region Llenar data Grid
        private void llenardatagridPerfil()
        {
            Perfil pf = new Perfil();
            dg_rols.ItemsSource = pf.ReadAll();
            dg_rols.Items.Refresh();
        }
        private void llenardatagridUsuario() 
        {
            Usuario us = new Usuario();
            dg_usuarios.ItemsSource = us.ReadAll();
            dg_usuarios.Items.Refresh();
        }
        #endregion

        #region Visibilidad Perfil
        //Mostrar Todo de Perfil
        private void MostrarPerfil() {
            //tb_introid.Visibility = Visibility.Visible;
            //lb_introid.Visibility = Visibility.Visible;
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
            //tb_introid.Visibility = Visibility.Collapsed;
            //lb_introid.Visibility = Visibility.Collapsed;
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
        
        private void CargarComboBoxPerfil()                                                                 // CARGAR COMBOBOX PERFIL
        {
            /* Carga todas los combobox con las actividad de empresa*/
            Perfil pf = new Perfil();
            cbx_selc_empleado.ItemsSource = pf.ReadAll();

            /* Configura los datos en el ComboBOx */
            cbx_selc_empleado.DisplayMemberPath = "rol"; //Propiedad para mostrar
            cbx_selc_empleado.SelectedValuePath = "cod_perfil"; //Propiedad con el valor a rescatar
            cbx_selc_empleado.SelectedIndex = -1; //Posiciona en el primer registro
        }
        
        private void CargarComboBoxRegion()                                                                 //CARGAR COMBOBOX REGION
        {
            /* Carga todas los combobox con las actividad de empresa*/
            Region pf = new Region();
            cbx_region_empleado.ItemsSource = pf.ReadAll();
            /* Configura los datos en el ComboBOx */
            cbx_region_empleado.DisplayMemberPath = "nombre"; //Propiedad para mostrar
            cbx_region_empleado.SelectedValuePath = "cod_region"; //Propiedad con el valor a rescatar
            cbx_region_empleado.SelectedIndex = -1; //Posiciona en el primer registro

        }
        
        private void Combo()                                                                                // CARGAR COMBOBOX COMUNA CON PROCESO ALMACENADO EMPLEADO
        {       
            LlenarCombo cm = new LlenarCombo();
            string varible = (string)cbx_region_empleado.SelectedValue;
            cbx_Comuna_empleado.ItemsSource = cm.Llenar(varible);
            cbx_Comuna_empleado.DisplayMemberPath = "nombre";
            cbx_Comuna_empleado.SelectedValuePath = "cod_comuna";
            cbx_Comuna_empleado.SelectedIndex = -1;
        }
        private void CargarComboRegionUsuario()                                                             //CARGAR COMBOBOX COMUNA
        {
            /* Carga todas los combobox con las actividad de empresa*/
            Region pf = new Region();
            cbx_region_usuario.ItemsSource = pf.ReadAll();
            /* Configura los datos en el ComboBOx */
            cbx_region_usuario.DisplayMemberPath = "nombre"; //Propiedad para mostrar
            cbx_region_usuario.SelectedValuePath = "cod_region"; //Propiedad con el valor a rescatar
            cbx_region_usuario.SelectedIndex = -1; //Posiciona en el primer registro

        }
        private void ComboUsuario()                                                                        // CARGAR COMBOBOX COMUNA CON PROCESO ALMACENADO USUARIO
        {
            LlenarCombo cm = new LlenarCombo();
            string varible = (string)cbx_region_usuario.SelectedValue;

            cbx_comuna_usuario.ItemsSource = cm.Llenar(varible);
            cbx_comuna_usuario.DisplayMemberPath = "nombre";
            cbx_comuna_usuario.SelectedValuePath = "cod_comuna";
            cbx_comuna_usuario.SelectedIndex = -1;
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
            btn_limpiar.Visibility = Visibility.Collapsed;
            txb_contra_empleado.Visibility = Visibility.Collapsed;
            lb_ing_contra.Visibility = Visibility.Collapsed;


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
            btn_limpiar.Visibility = Visibility.Visible;
            txb_contra_empleado.Visibility = Visibility.Visible;
            lb_ing_contra.Visibility = Visibility.Visible;
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

        private void MostrarListaEmpleados()
        {
            lb_titulo_lista.Visibility = Visibility.Visible;
            dg_empleados.Visibility = Visibility.Visible;
            btn_eliminar_Emp.Visibility = Visibility.Visible;
            btn_volver_Emp.Visibility = Visibility.Visible;
            btn_modificar_Emp.Visibility = Visibility.Visible;
        }
        private void SacarListaEmpleados()
        {
            lb_titulo_lista.Visibility = Visibility.Collapsed;
            dg_empleados.Visibility = Visibility.Collapsed;
            btn_eliminar_Emp.Visibility = Visibility.Collapsed;
            btn_volver_Emp.Visibility = Visibility.Collapsed;
            btn_modificar_Emp.Visibility = Visibility.Collapsed;
        }

        private void SacarEmpleadoModificar()
        {

            lb_titulo_modificar.Visibility = Visibility.Collapsed;
            lb_ing_apmE.Visibility = Visibility.Collapsed;
            lb_ing_appE.Visibility = Visibility.Collapsed;
            lb_ing_rutE.Visibility = Visibility.Collapsed;
            lb_ing_dirE.Visibility = Visibility.Collapsed;
            lb_ing_emaE.Visibility = Visibility.Collapsed;
            lb_ing_nomE.Visibility = Visibility.Collapsed;
            lb_ing_numE.Visibility = Visibility.Collapsed;           
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
            txbC_rut_empleado.Visibility = Visibility.Collapsed;            
            btn_volver_AgregarEmpleado.Visibility = Visibility.Collapsed;
            lb_titulo_personal.Visibility = Visibility.Collapsed;
            btn_limpiar.Visibility = Visibility.Collapsed;
            btn_modificar_Emp.Visibility = Visibility.Collapsed;
            btn_Modificar_Emp.Visibility = Visibility.Collapsed;
            txb_contra_empleado.Visibility = Visibility.Collapsed;
            lb_ing_contra.Visibility = Visibility.Collapsed;

        }
        private void MostrarEmpleadoModificar()
        {
            lb_titulo_modificar.Visibility = Visibility.Visible;
            lb_ing_apmE.Visibility = Visibility.Visible;
            lb_ing_appE.Visibility = Visibility.Visible;
            lb_ing_rutE.Visibility = Visibility.Visible;
            lb_ing_dirE.Visibility = Visibility.Visible;
            lb_ing_emaE.Visibility = Visibility.Visible;
            lb_ing_nomE.Visibility = Visibility.Visible;
            lb_ing_numE.Visibility = Visibility.Visible;           
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
            txbC_rut_empleado.Visibility = Visibility.Visible;
            btn_volver_AgregarEmpleado.Visibility = Visibility.Visible;
            btn_modificar_Emp.Visibility = Visibility.Visible;
            btn_Modificar_Emp.Visibility = Visibility.Visible;
            txb_contra_empleado.Visibility = Visibility.Visible;
            lb_ing_contra.Visibility = Visibility.Visible;

        }
        #endregion

        #region Validacion Campos vacios
        //Validar los campos de Perfil que no esten vacíos
        private bool ValidarTextbox_Perfil()
        {
            bool validar = true;
           /* if (tb_introid.Text == string.Empty)
            {
                validar = false;
            }*/
            if (tb_asignarrol.Text == string.Empty)
            {
                validar = false;
            }
            return validar;
        }
        //Limpiar los campos de Perfil 
        private void limpiar_campos_perfil()
        {
            //tb_introid.Text = string.Empty;
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
            if(txb_contra_empleado.Text == string.Empty)
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
            txb_contra_empleado.Text = string.Empty;
        }
        #endregion

        #region Visibilidad Usuario
        private void MostrarUsuario() 
        {
            lb_titulo_Usuario.Visibility = Visibility.Visible;
            rec_usuario_1.Visibility = Visibility.Visible;
            rec_usuario_2.Visibility = Visibility.Visible;
            btn_agre_usuario.Visibility = Visibility.Visible;
            btn_lista_usuario.Visibility = Visibility.Visible;
            img_agregar_usuario.Visibility = Visibility.Visible;
            img_listar_usuario.Visibility = Visibility.Visible;
        }
        private void SacarUsuario()
        {
            lb_titulo_Usuario.Visibility = Visibility.Collapsed;
            rec_usuario_1.Visibility = Visibility.Collapsed;
            rec_usuario_2.Visibility = Visibility.Collapsed;
            btn_agre_usuario.Visibility = Visibility.Collapsed;
            btn_lista_usuario.Visibility = Visibility.Collapsed;
            img_agregar_usuario.Visibility = Visibility.Collapsed;
            img_listar_usuario.Visibility = Visibility.Collapsed;
        }
        private void MostrarUsuarioAgregar()
        {
            btn_aregar_usuario.Visibility = Visibility.Visible;
            lb_rut_usuario.Visibility = Visibility.Visible;
            lb_contrasena_usuario.Visibility = Visibility.Visible;
            lb_apellidoM_usuario.Visibility = Visibility.Visible;
            lb_apellidoP_usuario.Visibility = Visibility.Visible;
            lb_nombre_usuario.Visibility = Visibility.Visible;
            lb_fono_usuario.Visibility = Visibility.Visible;
            lb_email_usuario.Visibility = Visibility.Visible;
            lb_comuna_usuario.Visibility = Visibility.Visible;
            lb_region_usuario.Visibility = Visibility.Visible;
            txb_rut_usuario.Visibility = Visibility.Visible;
            txb_contrasena_usuario.Visibility = Visibility.Visible;
            txb_apellidoM_usuario.Visibility = Visibility.Visible;
            txb_apellidoP_usuario.Visibility = Visibility.Visible;
            txb_nombre_usuario.Visibility = Visibility.Visible;
            txb_fono_usuario.Visibility = Visibility.Visible;
            txb_email_usuario.Visibility = Visibility.Visible;
            cbx_comuna_usuario.Visibility = Visibility.Visible;
            cbx_region_usuario.Visibility = Visibility.Visible;
        }
        private void SacarUsuarioAgregar()
        {
            btn_aregar_usuario.Visibility = Visibility.Collapsed;
            lb_rut_usuario.Visibility = Visibility.Collapsed;
            lb_contrasena_usuario.Visibility = Visibility.Collapsed;
            lb_apellidoM_usuario.Visibility = Visibility.Collapsed;
            lb_apellidoP_usuario.Visibility = Visibility.Collapsed;
            lb_nombre_usuario.Visibility = Visibility.Collapsed;
            lb_fono_usuario.Visibility = Visibility.Collapsed;
            lb_email_usuario.Visibility = Visibility.Collapsed;
            lb_comuna_usuario.Visibility = Visibility.Collapsed;
            lb_region_usuario.Visibility = Visibility.Collapsed;
            txb_rut_usuario.Visibility = Visibility.Collapsed;
            txb_contrasena_usuario.Visibility = Visibility.Collapsed;
            txb_apellidoM_usuario.Visibility = Visibility.Collapsed;
            txb_apellidoP_usuario.Visibility = Visibility.Collapsed;
            txb_nombre_usuario.Visibility = Visibility.Collapsed;
            txb_fono_usuario.Visibility = Visibility.Collapsed;
            txb_email_usuario.Visibility = Visibility.Collapsed;
            cbx_comuna_usuario.Visibility = Visibility.Collapsed;
            cbx_region_usuario.Visibility = Visibility.Collapsed;
        }
        private void MostrarUsuarioList()
        {
            dg_usuarios.Visibility = Visibility.Visible;
            btn_eliminar_usuario.Visibility = Visibility.Visible;
            btn_modificar_usuario.Visibility = Visibility.Visible;
            txb_buscar_usuario.Visibility = Visibility.Visible;
           
        }
        private void SacarUsuarioList()
        {
            dg_usuarios.Visibility = Visibility.Collapsed;
            btn_eliminar_usuario.Visibility = Visibility.Collapsed;
            btn_modificar_usuario.Visibility = Visibility.Collapsed;
            txb_buscar_usuario.Visibility = Visibility.Collapsed;

        }
        private void MostrarUsuarioModificar()
        {
            btn_modifi_usuario.Visibility = Visibility.Visible;
            lb_rutM_usuario.Visibility = Visibility.Visible;
            lb_contraM_usuario.Visibility = Visibility.Visible;
            lb_apelPM_usuario.Visibility = Visibility.Visible;
            lb_apellMM_usuario.Visibility = Visibility.Visible;
            lb_nomM_usuario.Visibility = Visibility.Visible;
            lb_fonoM_usuario.Visibility = Visibility.Visible;
            lb_emailM_usuario.Visibility = Visibility.Visible;
            lb_comunaM_usaurio.Visibility = Visibility.Visible;
            lb_regionM_usaurio.Visibility = Visibility.Visible;
            txbc_rut_usuario.Visibility = Visibility.Visible;
            txb_contrasena_usuario.Visibility = Visibility.Visible;
            txb_apellidoM_usuario.Visibility = Visibility.Visible;
            txb_apellidoP_usuario.Visibility = Visibility.Visible;
            txb_nombre_usuario.Visibility = Visibility.Visible;
            txb_fono_usuario.Visibility = Visibility.Visible;
            txb_email_usuario.Visibility = Visibility.Visible;
            cbx_comuna_usuario.Visibility = Visibility.Visible;
            cbx_region_usuario.Visibility = Visibility.Visible;
        }
        private void SacarUsuarioModificar()
        {
            btn_modifi_usuario.Visibility = Visibility.Collapsed;
            lb_rutM_usuario.Visibility = Visibility.Collapsed;
            lb_contraM_usuario.Visibility = Visibility.Collapsed;
            lb_apelPM_usuario.Visibility = Visibility.Collapsed;
            lb_apellMM_usuario.Visibility = Visibility.Collapsed;
            lb_nomM_usuario.Visibility = Visibility.Collapsed;
            lb_fonoM_usuario.Visibility = Visibility.Collapsed;
            lb_emailM_usuario.Visibility = Visibility.Collapsed;
            lb_comunaM_usaurio.Visibility = Visibility.Collapsed;
            lb_regionM_usaurio.Visibility = Visibility.Collapsed;
            txbc_rut_usuario.Visibility = Visibility.Collapsed;
            txb_contrasena_usuario.Visibility = Visibility.Collapsed;
            txb_apellidoM_usuario.Visibility = Visibility.Collapsed;
            txb_apellidoP_usuario.Visibility = Visibility.Collapsed;
            txb_nombre_usuario.Visibility = Visibility.Collapsed;
            txb_fono_usuario.Visibility = Visibility.Collapsed;
            txb_email_usuario.Visibility = Visibility.Collapsed;
            cbx_comuna_usuario.Visibility = Visibility.Collapsed;
            cbx_region_usuario.Visibility = Visibility.Collapsed;
        }
        private bool ValidarAgregarUsuario()
        {
            bool validar = true;
            if (txb_rut_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_contrasena_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_apellidoM_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_apellidoP_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_nombre_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_fono_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_email_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (cbx_comuna_usuario.SelectedIndex == -1)
            {
                validar = false;
            }
            if (cbx_region_usuario.SelectedIndex == -1)
            {
                validar = false;
            }
            return validar;
        }
        private bool ValidarModificarUsuario() 
        {
            bool validar = true;
            if (txb_contrasena_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_apellidoM_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_apellidoP_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_nombre_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_fono_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (txb_email_usuario.Text == string.Empty)
            {
                validar = false;
            }
            if (cbx_comuna_usuario.SelectedIndex == -1)
            {
                validar = false;
            }
            if (cbx_region_usuario.SelectedIndex == -1)
            {
                validar = false;
            }
            return validar;
        }



        #endregion

        #region Botones de Menu
        private void Button_Click_Perfil(object sender, RoutedEventArgs e)                              // BOTON MENU GESTION DE PERFIL
        {
            MostrarPerfil();
            SacarEmpleados();
            SacarEmpleadoAgregar();
            SacarListaEmpleados();
            SacarEmpleadoModificar();
            SacarUsuario();
            SacarUsuarioList();
            SacarUsuarioModificar();
            SacarUsuarioAgregar();
            llenardatagridPerfil();
            
        }

        private void Button_Click_Personal(object sender, RoutedEventArgs e)                            // BOTON MENU GESTION DE PERSONAL
        {
            SacarPerfil();
            SacarEmpleadoAgregar();
            SacarListaEmpleados();
            SacarEmpleadoModificar();
            SacarUsuario();
            SacarUsuarioList();
            SacarUsuarioModificar();
            SacarUsuarioAgregar();
            MostrarEmpleados();
            
            
        }

        private void Button_Click_Documentos(object sender, RoutedEventArgs e)                          // BOTON MENU GESTION DE DOCUMENTOS
        {
            SacarPerfil();
            SacarEmpleados();
            SacarEmpleadoAgregar();
            SacarListaEmpleados();
            SacarEmpleadoModificar();
            SacarUsuario();
            SacarUsuarioList();
            SacarUsuarioModificar();
            SacarUsuarioAgregar();


        }

        private void Button_Click(object sender, RoutedEventArgs e)                                     // BOTON MENU GESTION DE USAURIO
        {
            SacarPerfil();
            SacarEmpleados();
            SacarEmpleadoAgregar();
            SacarListaEmpleados();
            SacarUsuarioList();
            SacarEmpleadoModificar();
            SacarUsuarioAgregar();
            MostrarUsuario();
            SacarUsuarioModificar();
            llenardatagridUsuario();
        }

        #endregion

        #region Gestion de Perfil
        private void btn_agregarrol_Click(object sender, RoutedEventArgs e)                             // BOTON PERFIL AGREGAR ROL
        {
            //lista de perfil         
            if (ValidarTextbox_Perfil())
            {
                Perfil pf = new Perfil() 
                {                    
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

        private void btn_eliminarrol_Click(object sender, RoutedEventArgs e)                            // BOTON PERFIL ELIMINAR ROL
        {
            // Validacion de seleccion
            if (dg_rols.SelectedIndex != -1)
            {
                Perfil pf = (Perfil)dg_rols.SelectedItem;
                Empleado Em = new Empleado();

                //Cosulta si estas seguro
                if (MessageBox.Show("Seguro que desea eliminar " + pf.rol, "¿Está seguro?",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    // validacion rol en uso por empleado
                    
                    if (Em.Readid(pf.cod_perfil))
                    {
                        MessageBox.Show("El rol [ " + pf.rol + " " + pf.cod_perfil + " ] se esta usando en un empleado. No se puede eliminar", "Rol en Uso !!!",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                        
                    }
                    else 
                    {
                        MessageBox.Show("El rol fue eliminado correctamente", "Rol Eliminado",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                        pf.Delete();
                        llenardatagridPerfil();
                    }
                }
                else 
                { 
                    dg_rols.SelectedIndex = -1;
                }                 
            }
            else 
            {
                MessageBox.Show("Ups se debe seleccionar un rol en la tabla para ser eliminada", "¿Eliminar?",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region Gestion de Empleados
        private void btn_agregar_empleados_Click(object sender, RoutedEventArgs e)                      // BOTON EMPLEADO MOSTRAR AGREGAR 
        {
            limpiarEmpleado();
            SacarEmpleados();
            MostrarEmpleadoAgregar();
            CargarComboBoxPerfil();
            CargarComboBoxRegion();
        }

        private void cbx_region_empleado_SelectionChanged(object sender, SelectionChangedEventArgs e)   // COMBOBOX EMPLEADO CARGAR COMBOBOX COMUNA 
        {  
            Combo();
        }

        private void BotonVolverGestionPersonal(object sender, RoutedEventArgs e)                       // BOTON EMPLEADO VOLVER ATRAS
        {
            SacarEmpleadoAgregar();
            SacarListaEmpleados();
            SacarEmpleadoModificar();
            MostrarEmpleados();
          
        }

        private void btn_ing_AgrEmpl_Click(object sender, RoutedEventArgs e)                            // BOTON EMPLEADO AGREGAR EMPLEADO
        {
            if (ValidarTextbox_Empleado())
            {
                Empleado Em = new Empleado()
                { 
                    rut = txb_rut_empleado.Text,
                    nombre = txb_nom_empleado.Text,
                    apellido_paterno = txb_apllP_empleado.Text,
                    apellido_materno = txb_apellM_empleado.Text,
                    contrasena = txb_contra_empleado.Text,
                    fono = int.Parse(txb_fono_empleado.Text),
                    direccion = txb_dirc_empleado.Text,
                    cod_comuna = (string)cbx_Comuna_empleado.SelectedValue,
                    cod_perfil = (int)cbx_selc_empleado.SelectedValue,
                    email = txb_email_empleado.Text
                };

                if (Em.Create())
                {
                    MessageBox.Show("Nuevo Empleado agregado correctamente al sistema", "Nuevo Empleado Creado!!!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarEmpleado();

                }
                else
                {
                    MessageBox.Show("El rut del empleado ya existe " + Em.rut + "Ingreselo nuevamente", "Empleado existente",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    txb_rut_empleado.Text = string.Empty;
                }
                
            }
            else
            {
                MessageBox.Show("Ups los campos estan vacíos", "Campos Vacíos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)                                // BOTON EMPLEADO LIMPIAR CAMPOS
        {
            limpiarEmpleado();
        }

        private void btn_list_empleados_Click(object sender, RoutedEventArgs e)                         // BOTON EMPLEADO LISTA 
        {
            SacarEmpleados();
            MostrarListaEmpleados();
            Empleado Em = new Empleado();
            dg_empleados.ItemsSource = Em.ReadAll();
            dg_empleados.Items.Refresh();

        }

        private void btn_eliminar_Emp_Click(object sender, RoutedEventArgs e)                           // BOTON EMPLEADO ELIMINAR
        {
            if (dg_empleados.SelectedIndex != -1)
            {
                Empleado Em = (Empleado)dg_empleados.SelectedItem;
                Em.Delete();

                if (MessageBox.Show("Seguro que desea eliminar al empleado " + Em.nombre, "¿Está seguro?",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    dg_empleados.ItemsSource = Em.ReadAll();
                    dg_empleados.Items.Refresh();
                }
                else
                {
                    dg_empleados.SelectedIndex = -1;
                }
            }
            else 
            {
                MessageBox.Show("Ups se debe seleccionar un empleado en la tabla para ser eliminada", "¿Eliminar?",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_modificar_Emp_Click(object sender, RoutedEventArgs e)                          // BOTON EMPLEADO MOSTRAR MODIFICAR
        {           
            if (dg_empleados.SelectedIndex != -1)
            {
                SacarListaEmpleados();
                MostrarEmpleadoModificar();
                CargarComboBoxPerfil();
                CargarComboBoxRegion();

                Empleado Em = (Empleado)dg_empleados.SelectedItem;
                txbC_rut_empleado.Text = Em.rut.ToString();
                txb_nom_empleado.Text = Em.nombre.ToString();
                txb_apllP_empleado.Text = Em.apellido_paterno.ToString();
                txb_apellM_empleado.Text = Em.apellido_materno.ToString();
                txb_contra_empleado.Text = Em.contrasena.ToString();
                txb_fono_empleado.Text = Em.fono.ToString();
                txb_dirc_empleado.Text = Em.direccion.ToString();             
                cbx_selc_empleado.SelectedValue = Em.cod_perfil;
                txb_email_empleado.Text = Em.email;

                btn_modificar_Emp.Visibility = Visibility.Collapsed;

            }
            else 
            {
                MessageBox.Show("Ups se debe seleccionar un empleado en la tabla para ser modificado", "¿modificar?",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
          
        }

        private void btn_Modificar_Emp_Click_1(object sender, RoutedEventArgs e)                        // BOTON EMPLEADO REALIZAR MODIFICACION
        {
            Empleado template = new Empleado
            {
                rut = txbC_rut_empleado.Text,
                nombre = txb_nom_empleado.Text,
                apellido_paterno = txb_apllP_empleado.Text,
                apellido_materno = txb_apellM_empleado.Text,
                contrasena = txb_contra_empleado.Text,
                fono = int.Parse(txb_fono_empleado.Text),
                direccion = txb_dirc_empleado.Text,
                cod_comuna = (string)cbx_Comuna_empleado.SelectedValue,
                cod_perfil = (int)cbx_selc_empleado.SelectedValue,
                email = txb_email_empleado.Text
            };
            if (ValidarTextbox_Empleado())
            {
                if (template.Update())
                {
                    MessageBox.Show("Se han actualizado los datos correctamente", "Datos Actualizados",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    SacarEmpleadoModificar();
                    MostrarListaEmpleados();
                    Empleado Em = new Empleado();
                    dg_empleados.ItemsSource = Em.ReadAll();
                    dg_empleados.Items.Refresh();

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos", "Error al Actualizar",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else 
            {
                MessageBox.Show("Ups los campos estan vacíos", "Campos Vacíos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Gestion de Usuarios
        private void btn_agre_usuario_Click(object sender, RoutedEventArgs e)                           // BOTON USUARIO MOSTRAR AGREGAR
        {
            SacarUsuario();
            MostrarUsuarioAgregar();
            CargarComboRegionUsuario();
            
        }

        private void cbx_region_usuario_SelectionChanged(object sender, SelectionChangedEventArgs e)    // COMBOBOX USUARIO CARGA COMBOBOX COMUNA
        {
            ComboUsuario();
        }

        private void btn_lista_usuario_Click(object sender, RoutedEventArgs e)                          // BOTON USUARIO MOSTRAR LISTAR
        {
            SacarUsuario();
            MostrarUsuarioList();
            llenardatagridUsuario();

        }

        private void btn_aregar_usuario_Click(object sender, RoutedEventArgs e)                         // BOTON USUARIO AGREGAR NUEVO USUARIO
        {
            if (ValidarAgregarUsuario())
            {
                Usuario Us = new Usuario()
                {
                    rut = txb_rut_usuario.Text,
                    nombre = txb_nombre_usuario.Text,
                    apellido_paterno = txb_apellidoP_usuario.Text,
                    apellido_materno = txb_apellidoM_usuario.Text,                   
                    fono = int.Parse(txb_fono_usuario.Text),
                    contraseña = txb_contrasena_usuario.Text,
                    email = txb_email_usuario.Text,
                    cod_comuna = (string)cbx_comuna_usuario.SelectedValue,                                        
                };
                if (Us.Create())
                {
                    MessageBox.Show("Nuevo Usuario agregado correctamente al sistema", "Nuevo Usuario Creado!!!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarEmpleado();

                }
                else
                {
                    MessageBox.Show("El rut del usuario ya existe " + Us.rut + "Ingreselo nuevamente", "Usuario existente",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    txb_rut_usuario.Text = string.Empty;
                }
            }
            else 
            {
                MessageBox.Show("Ups los campos estan vacíos", "Campos Vacíos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_modificar_usuario_Click(object sender, RoutedEventArgs e)                      // BOTON USUARIO MOSTRAR MODIFICAR 
        {
            SacarUsuarioList();
            MostrarUsuarioModificar();
                    
            if (dg_usuarios.SelectedIndex != -1)
            {             
                CargarComboRegionUsuario();

                Usuario Us = (Usuario)dg_usuarios.SelectedItem;
                txbc_rut_usuario.Text = Us.rut.ToString();
                txb_nombre_usuario.Text = Us.nombre.ToString();
                txb_apellidoP_usuario.Text = Us.apellido_paterno.ToString();
                txb_apellidoM_usuario.Text = Us.apellido_materno.ToString();
                txb_fono_usuario.Text = Us.fono.ToString();
                txb_contrasena_usuario.Text = Us.contraseña.ToString();
                txb_email_usuario.Text = Us.email.ToString();
                cbx_comuna_usuario.SelectedValue = Us.cod_comuna;

            }
            else
            {
                MessageBox.Show("Ups se debe seleccionar un empleado en la tabla para ser modificado", "¿modificar?",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_eliminar_usuario_Click(object sender, RoutedEventArgs e)                       // BOTON USUARIO ELIMINAR
        {
            if (dg_usuarios.SelectedIndex != -1)
            {
                Usuario Us = (Usuario)dg_usuarios.SelectedItem;
                Us.Delete();

                if (MessageBox.Show("Seguro que desea eliminar al usuario? " + Us.nombre, "¿Está seguro?",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    dg_usuarios.ItemsSource = Us.ReadAll();
                    dg_usuarios.Items.Refresh();
                }
                else
                {
                    dg_usuarios.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Ups se debe seleccionar un usuario en la tabla para ser eliminada", "¿Eliminar?",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_modifi_usuario_Click(object sender, RoutedEventArgs e)                         // BOTON USUARIO REALIZAR MODIFICAR
        {
            Usuario template = new Usuario
            {
                rut = txbc_rut_usuario.Text,
                nombre = txb_nombre_usuario.Text,
                apellido_paterno = txb_apellidoP_usuario.Text,
                apellido_materno = txb_apellidoM_usuario.Text,
                fono = int.Parse(txb_fono_usuario.Text),
                contraseña = txb_contrasena_usuario.Text,
                email = txb_email_usuario.Text,
                cod_comuna = (string)cbx_comuna_usuario.SelectedValue,
            };
            if (ValidarModificarUsuario())
            {
                if (template.Update())
                {
                    MessageBox.Show("Se han actualizado los datos correctamente", "Datos Actualizados",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    SacarUsuarioModificar();
                    MostrarUsuarioList();
                    llenardatagridUsuario();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos", "Error al Actualizar",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Ups los campos estan vacíos", "Campos Vacíos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
