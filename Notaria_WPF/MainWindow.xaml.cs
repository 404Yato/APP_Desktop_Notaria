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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        SqlConnection conexionSql;

        public MainWindow()
        {
            InitializeComponent();
            String conexion = ConfigurationManager.ConnectionStrings["Biblioteca_de_Clases.Properties.Settings.Notaria"].ConnectionString; //Se señala que se desea conectar. Proyecto --> BD
            conexionSql = new SqlConnection(conexion); //Conexion entre el proyecto y la BD Entity 

        }


        private void MostrarComunas()
        {
            String consulta = "SELECT * FROM COMUNA"; //Consulta o Query

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, conexionSql); //Referencia a la variable consulta con la conexion a la bd

            using (sqlDataAdapter) //Traerá los datos desde la bd a un DataTable
            {
                DataTable tablaComunas = new DataTable();

                sqlDataAdapter.Fill(tablaComunas); //inserta la query en la tabla

                listaComuna.DisplayMemberPath = "nombre"; //campo a mostrar
                listaComuna.SelectedValuePath = "cod_comuna"; //campo clave
                listaComuna.ItemsSource = tablaComunas.DefaultView; //Espesificar de donde viene los datos
            }

        }
    }
}
