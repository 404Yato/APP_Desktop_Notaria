using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NotariaL
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-S1MQ4GV\\SQLEXPRESS01;DATABASE=Portafolio;integrated security=true");
            cn.Open();
            return cn;
        }
    }
}
