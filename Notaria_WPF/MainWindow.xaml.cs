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
using NotariaL;
using System.Data.SqlClient;
using System.Data;
using NotariaWPF;
using System.Web.UI.WebControls;
using Biblioteca_de_Clases;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Conexion.Conectar();
            ///MessageBox.Show("Conexion exitosa");
            DataGrid1.DataContext = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM dbo.tipo_tramite";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conexion.Conectar();

            string insertar = "INSERT INTO dbo.tipo_tramite VALUES (@cod_tramite, @nombre_tramite, @descripcion, @requisitos, @precio, @cod_template)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@cod_tramite", IDTB.Text);
            cmd1.Parameters.AddWithValue("@nombre_tramite", NTB.Text);
            cmd1.Parameters.AddWithValue("@descripcion", DTB.Text);
            cmd1.Parameters.AddWithValue("@requisitos", RTB.Text);
            cmd1.Parameters.AddWithValue("@precio", PTB.Text);
            cmd1.Parameters.AddWithValue("@cod_template", CTB.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados con exito");

            DataGrid1.DataContext = llenar_grid();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Conexion.Conectar();
            string actualizar = "UPDATE dbo.tipo_tramite SET cod_tramite=@cod_tramite, nombre_tramite=@nombre_tramite, descripcion=@descripcion, requisitos=@requisitos, precio=@precio, cod_template=@cod_template WHERE cod_template=@cod_template";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@cod_tramite", IDTB.Text);
            cmd2.Parameters.AddWithValue("@nombre_tramite", NTB.Text);
            cmd2.Parameters.AddWithValue("@descripcion", DTB.Text);
            cmd2.Parameters.AddWithValue("@requisitos", RTB.Text);
            cmd2.Parameters.AddWithValue("@precio", PTB.Text);
            cmd2.Parameters.AddWithValue("@cod_template", CTB.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados con exito");
            DataGrid1.DataContext = llenar_grid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Conexion.Conectar();

            if (DataGrid1.SelectedIndex != -1)
            {
                tipo_tramite tramite = (tipo_tramite)DataGrid1.SelectedItem;
                tramite.Delete();
                llenar_grid();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el objeto de la lista a eliminar");
            }

            /*if (DataGrid1.SelectedIndex != -1)
            {
                MessageBoxResult selecion = MessageBox.Show("¿Estás seguro que deseas eliminar este tipo de trámite?",
               "Advertencia", MessageBoxButton.YesNoCancel);

                switch (selecion)
                {
                    case MessageBoxResult.Yes:
                        string eliminar = "DELETE FROM dbo.tipo_tramite WHERE cod_tramite=@cod_tramite";
                        SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());

                        cmd3.Parameters.AddWithValue("@cod_tramite", DataGrid1.SelectedIndex);

                        cmd3.ExecuteNonQuery();

                        MessageBox.Show("Los datos fueron eliminados con exito");

                        break;

                    case MessageBoxResult.No:
                        MessageBox.Show("Los datos quedarán intactos.");
                        break;

                    case MessageBoxResult.Cancel:
                        MessageBox.Show("Operación cancelada.");
                        break;
                }

                DataGrid1.DataContext = llenar_grid();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el objeto de la lista a eliminar");
            }*/

            /*MessageBoxResult selecion = MessageBox.Show("¿Estás seguro que deseas eliminar este tipo de trámite?",
                "Advertencia", MessageBoxButton.YesNoCancel);

            switch (selecion)
            {
                case MessageBoxResult.Yes:
                    string eliminar = "DELETE FROM dbo.tipo_tramite WHERE cod_tramite=@cod_tramite";
                    SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());

                    cmd3.Parameters.AddWithValue("@cod_tramite", IDTB.Text);

                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Los datos fueron eliminados con exito");

                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("Los datos quedarán intactos.");
                    break;

                case MessageBoxResult.Cancel:
                    MessageBox.Show("Operación cancelada.");
                    break;
            }

            DataGrid1.DataContext = llenar_grid();*/
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IDTB.Clear();
            NTB.Clear();
            DTB.Clear();
            RTB.Clear();
            PTB.Clear();
            CTB.Clear();
            IDTB.Focus();
        }

        private void BContador_Click(object sender, RoutedEventArgs e)
        {
            Contador miContador = new Contador();
            miContador.ShowDialog();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid1_CellContentClick(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ///Diseño miDiseño = new Diseño();
            ///miDiseño.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Documentos(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Personal(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Perfil(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            TiposDeTramites miTramite = new TiposDeTramites();
            miTramite.ShowDialog();
        }
    }
}