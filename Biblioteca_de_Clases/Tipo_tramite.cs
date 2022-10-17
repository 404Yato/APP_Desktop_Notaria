using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Tipo_tramite
    {
        #region PROPIEDADES
        public int cod_tramite { get; set; }
        public string nombre_tramite { get; set; }
        public string descripcion { get; set; }
        public string requisitos { get; set; }
        public int precio { get; set; }
        public int cod_template { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Tipo_tramite() //Inicializar Constructor
        {
            this.Init();
        }

        private void Init() // Constructor
        {
            cod_tramite = 0;
            nombre_tramite = string.Empty;
            descripcion = string.Empty;
            requisitos = string.Empty;
            precio = 0;
            cod_template = 0;
        }
        #endregion

        #region MÉTODOS
        public List<Tipo_tramite> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.tipo_tramite> listadoDatos = bbdd.tipo_tramite.ToList<Notaria.Datos.tipo_tramite>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Tipo_tramite> listadoTramites = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoTramites;
            }
            catch (Exception)
            {
                return new List<Tipo_tramite>();
            }
        }

        private List<Tipo_tramite> GenerarListado(List<Notaria.Datos.tipo_tramite> listadoDatos)
        {
            List<Tipo_tramite> listadoTramites = new List<Tipo_tramite>();

            foreach (Notaria.Datos.tipo_tramite dato in listadoDatos)
            {

                Tipo_tramite negocio = new Tipo_tramite();
                CommonBC.Syncronize(dato, negocio);

                listadoTramites.Add(negocio);
            }

            return listadoTramites;
        }
        #endregion
    }
}
