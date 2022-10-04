using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblioteca_de_Clases
{
    public class Perfil
    {
        #region PROPIEDADES
        public String Cod_perfil { get; set; }
        public String Rol { get; set; }
        #endregion

        #region CONSTRUCTOR

        public Perfil() //Inicializar constructor
        {
            this.Init();

        }

        private void Init() //Constructor
        {
            Cod_perfil = String.Empty;
            Rol = String.Empty;
        }
        #endregion

        #region METODOS
        /*
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString);

        public void Agregar_Perfil(string Cod_perfil,string rol) {
            con.Open();
            SqlCommand cmd = new SqlCommand("agregar_perfil", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod_perfil", Cod_perfil));
            cmd.Parameters.Add(new SqlParameter("@rol", rol));
            IDataReader reader = cmd.ExecuteReader();
            con.Close();
        }

        public DataTable CargarDatos_Perfil()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("listar_perfil", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        */
        #endregion
    }


}
