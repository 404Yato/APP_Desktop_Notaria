using NotariaL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace NotariaWPF
{
    /// <summary>
    /// Lógica de interacción para Contador.xaml
    /// </summary>
    public partial class Contador : Window
    {
        public Contador()
        {
            InitializeComponent();
            Conexion.Conectar();
            /*MessageBox.Show("Conexion exitosa");*/
            DataGrid1.DataContext = llenar_grid2();
            DataGrid2.DataContext = llenar_grid3();
            DataGrid3.DataContext = llenar_grid();
            DataGrid4.DataContext = llenar_grid4();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select vo.cod_venta ID, vo.amount Cantidad, vo.transaction_date as 'Fecha de transacción', vo.cod_venta as 'Código', de.precio Precio from dbo.ventas_online vo join dbo.doc_emitido de on vo.cod_documento=de.cod_documento";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public DataTable llenar_grid2()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select sum(amount) as 'Ventas registradas', sum(precio*amount) as 'Ganancias', MONTH(transaction_date) as 'Mes' from dbo.ventas_online vo join dbo.doc_emitido de on vo.cod_documento=de.cod_documento group by MONTH(transaction_date)";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public DataTable llenar_grid3()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select sum(amount) as 'Ventas registradas', sum(precio*amount) as 'Ganancias', MONTH(transaction_date) as 'Mes' from dbo.ventas_presencial vp join dbo.doc_emitido de on vp.doc_emitido_cod_documento=de.cod_documento where estado='Confirmado' group by MONTH(transaction_date)";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public DataTable llenar_grid4()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select vp.cod_venta ID, vp.amount Cantidad, vp.transaction_date as 'Fecha de transacción', vp.cod_venta as 'Código', de.precio*vp.amount Precio, vp.estado Estado from dbo.ventas_presencial vp join dbo.doc_emitido de on vp.doc_emitido_cod_documento=de.cod_documento order by estado";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
    }
}
    

