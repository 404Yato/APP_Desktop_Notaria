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
using Notaria_WPF;

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
            dtg_ventasO.DataContext = llenar_grid2();
            dtg_ventasP.DataContext = llenar_grid3();
            dtg_DetalleventasO.DataContext = llenar_grid();
            dtg_DetalleventasP.DataContext = llenar_grid4();
        }

        #region Visibilidad Ventas online
        private void MostrarVentasO() 
        {
            lb_tituloVentasO.Visibility = Visibility.Visible;
            lb_ventasO.Visibility = Visibility.Visible;
            lb_DetalleventasO.Visibility = Visibility.Visible;
            dtg_DetalleventasO.Visibility = Visibility.Visible;
            dtg_ventasO.Visibility = Visibility.Visible;
        }
        private void SacarVentasO()
        {
            lb_tituloVentasO.Visibility = Visibility.Collapsed;
            lb_ventasO.Visibility = Visibility.Collapsed;
            lb_DetalleventasO.Visibility = Visibility.Collapsed;
            dtg_DetalleventasO.Visibility = Visibility.Collapsed;
            dtg_ventasO.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Visibilidad Ventas Presencial
        private void MostrarVentasP()
        {
            lb_tituloVentasP.Visibility = Visibility.Visible;
            lb_ventasP.Visibility = Visibility.Visible;
            lb_DetalleventasP.Visibility = Visibility.Visible;
            dtg_DetalleventasP.Visibility = Visibility.Visible;
            dtg_ventasP.Visibility = Visibility.Visible;
        }
        private void SacarVentasP()
        {
            lb_tituloVentasP.Visibility = Visibility.Collapsed;
            lb_ventasP.Visibility = Visibility.Collapsed;
            lb_DetalleventasP.Visibility = Visibility.Collapsed;
            dtg_DetalleventasP.Visibility = Visibility.Collapsed;
            dtg_ventasP.Visibility = Visibility.Collapsed;
        }
        #endregion


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
            string consulta = "select sum(amount) as 'Ventas registradas', sum(precio*amount) as 'Ganancias', MONTH(transaction_date) as 'Mes' from dbo.ventas_presencial vp join dbo.doc_emitido de on vp.doc_emitido_cod_documento=de.cod_documento where vp.estado='Confirmado' group by MONTH(transaction_date)";
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

        private void btn_ventasO_Click(object sender, RoutedEventArgs e)                                //BOTON VENTAS ONLINE
        {
            SacarVentasP();
            MostrarVentasO();

        }

        private void btn_ventasP_Click(object sender, RoutedEventArgs e)                                //BOTON VENTAS PRESENCIAL
        {
            SacarVentasO();
            MostrarVentasP();
        }
    }
}
    

