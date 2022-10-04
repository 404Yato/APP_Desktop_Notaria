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
        //Conexion a base de datos      
        
        //cargar data grid con datos de perfil
        /*
        void CargarDatos_Perfil() {
            con.Open();
            SqlCommand cmd = new SqlCommand("listar_perfil", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dg_rols.ItemsSource = dt.DefaultView;
            con.Close();
        } */

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString);

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
        }


        //Ocultar Todo de Perfil
        private void SacarPerfil() {
            tb_introid.Visibility = Visibility.Hidden;
            lb_introid.Visibility = Visibility.Hidden;
            lb_asignarrol.Visibility = Visibility.Hidden;
            tb_asignarrol.Visibility = Visibility.Hidden;
            btn_agregarrol.Visibility = Visibility.Hidden;
            btn_eliminarrol.Visibility = Visibility.Hidden;
            dg_rols.Visibility = Visibility.Hidden;
            rec_perfil.Visibility = Visibility.Hidden;
            lb_titulo_perfil.Visibility = Visibility.Hidden;
            lb_titulo2.Visibility = Visibility.Hidden;
        }
        //Limpiar los campos de Perfil 
        private void limpiar_campos_perfil() {
            tb_introid.Text = String.Empty;
            tb_asignarrol.Text = String.Empty;
        }
        //Validar los campos de Perfil que no esten vacíos
        private bool ValidarTextbox_Perfil() { 
            bool validar = true;
            if (tb_introid.Text == String.Empty)
            {
                validar = false;
            }
            if (tb_asignarrol.Text == String.Empty) {
                validar = false;
            }
            return validar;
        }
        private void MostrarEmpleados() { 
            btn_list_empleados.Visibility = Visibility.Visible;
            btn_agregar_empleados.Visibility = Visibility.Visible;
            lb_titulo_personal.Visibility = Visibility.Visible;
            img_agregar_empleado.Visibility = Visibility.Visible;
            img_list_empleado.Visibility = Visibility.Visible;
            rec_empleados.Visibility=Visibility.Visible;
            rec_empleados2.Visibility=Visibility.Visible;

        }
        private void SacarEmpleados() {
            btn_list_empleados.Visibility = Visibility.Hidden;
            btn_agregar_empleados.Visibility = Visibility.Hidden;
            lb_titulo_personal.Visibility = Visibility.Hidden;
            img_agregar_empleado.Visibility = Visibility.Hidden;
            img_list_empleado.Visibility = Visibility.Hidden;
            rec_empleados.Visibility = Visibility.Hidden;
            rec_empleados2.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Perfil(object sender, RoutedEventArgs e)
        {
            MostrarPerfil();
            SacarEmpleados();
            /*
            Perfil pf = new Perfil();
            dg_rols.ItemsSource =  pf.CargarDatos_Perfil().DefaultView;
            */
            
        }

        private void Button_Click_Personal(object sender, RoutedEventArgs e)
        {
            SacarPerfil();
            MostrarEmpleados();
        }

        private void Button_Click_Documentos(object sender, RoutedEventArgs e)
        {
            SacarPerfil();
            SacarEmpleados();
        }

        private void btn_agregarrol_Click(object sender, RoutedEventArgs e)
        {
            //lista de perfil
            
            if (ValidarTextbox_Perfil())
            {
                /*
                agregar_perfil();
                Perfil pf = new Perfil();
                dg_rols.ItemsSource = pf.CargarDatos_Perfil().DefaultView;*/
                
            }
            else {
                MessageBox.Show("Ups los campos estan vacíos", "Campos Vacíos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btn_eliminarrol_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
