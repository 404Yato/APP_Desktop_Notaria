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
            BD();
         
        }
        
        
        private void BD() {

            var lista_perfiles = new List<Perfil>();

            var perf = new Perfil() { Cod_perfil = "PF_01", Rol = "Notario" };
            var perf2 = new Perfil() { Cod_perfil = "PF_02", Rol = "Administrador" };
            var perf3 = new Perfil() { Cod_perfil = "PF_03", Rol = "Recepcionista" };

            //Agregar 
            lista_perfiles.Add(perf);
            lista_perfiles.Add(perf2);
            lista_perfiles.Add(perf3);

            //Asignar los elementos a la tabla
            dg_rols.ItemsSource = lista_perfiles;
        }

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
        }
        private void SacarEmpleados() {
            btn_list_empleados.Visibility = Visibility.Hidden;
            btn_agregar_empleados.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Perfil(object sender, RoutedEventArgs e)
        {
            MostrarPerfil();
            SacarEmpleados();

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
            List<Perfil> List_Perfil = new List<Perfil>();
            if (ValidarTextbox_Perfil())
            {
                Perfil perfil = new Perfil
                {
                    Cod_perfil = tb_introid.Text,
                    Rol = tb_asignarrol.Text
                };
                limpiar_campos_perfil();

                List_Perfil.Add(perfil);
                dg_rols.ItemsSource = List_Perfil;
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
