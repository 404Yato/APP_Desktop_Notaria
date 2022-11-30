using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Notaria.Datos;

namespace Biblioteca_de_Clases
{
    public class tipo_tramite
    {
        
        public int cod_tramite { get; set; }
        public string nombre_tramite { get; set; }
        public string descripcion { get; set; }
        public string requisitos { get; set; }
        public int precio { get; set; }
        public int cod_template { get; set; }

        public tipo_tramite()
        {
            this.Init();
        }
        private void Init() //Constructor
        {
            nombre_tramite = string.Empty;
            descripcion = string.Empty;
            requisitos = string.Empty;
            precio = int.MaxValue;


        }

        public bool Delete()
        {
            // Creo una instancia de conexión a Datos (SIEMPRE EN TODOS LOS METODOS)
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.tipo_tramite tramite = bbdd.tipo_tramite.First(e => e.cod_tramite == e.cod_tramite);
                bbdd.tipo_tramite.Remove(tramite);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
