using Biblioteca_de_Clases;
using Notaria.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Biblioteca_clases
{
    public class Comuna
    {
        #region PROPIEDADES 
        public string cod_comuna { get; set; } 
        public string nombre { get; set; }
        public string region { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Comuna() //Inicializar el constructor
        {
            this.Init(); 
        }
         
        private void Init() //Constructor
        {
            cod_comuna = string.Empty;
            nombre = string.Empty;
            region = string.Empty;
        }
        #endregion

        #region Metodos

        public List<Comuna> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.comuna> listadoDatos = bbdd.comuna.ToList<Notaria.Datos.comuna>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Comuna> listadoPerfil = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoPerfil;
            }
            catch (Exception)
            {
                return new List<Comuna>();
            }
        }
        public bool Read()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.region cliente = bbdd.region.First(e => e.nombre == region);
                //Pasar los valores Datos(bd) a negocio 
                CommonBC.Syncronize(cliente, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        private List<Comuna> GenerarListado(List<Notaria.Datos.comuna> listadoDatos)
        {
            List<Comuna> listaPerfil = new List<Comuna>();

            foreach (Notaria.Datos.comuna dato in listadoDatos)
            {

                Comuna negocio = new Comuna();
                CommonBC.Syncronize(dato, negocio);

                listaPerfil.Add(negocio);
            }

            return listaPerfil;
        }
        #endregion
    }
}
