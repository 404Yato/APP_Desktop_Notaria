using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Notaria.Datos;

namespace Biblioteca_de_Clases
{
    public class Perfil
    {
        #region PROPIEDADES
        public int cod_perfil { get; set; }
        public string rol { get; set; }

        #endregion

        #region CONSTRUCTOR

        public Perfil() //Inicializar constructor
        {
            this.Init();

        }

        private void Init() //Constructor
        {
            cod_perfil = 0;
            rol = string.Empty;
        }
        #endregion

        #region METODOS

        public bool Create()
        {
            // Creo una instancia de conexión a Datos
            //OnBreakEntities es el nombre de la conexión
            PortafolioEntities bbdd = new PortafolioEntities();
            Notaria.Datos.perfil PF = new Notaria.Datos.perfil();

            try
            {
                //Pasar los valores de las propiedades de negocio a Datos
                //CommonBC.Syncronize(desde, hasta); usa las propiedades definidas en this class
                //luego se agraga con el metodo add con el objeto creado como parametro y saveChanges() guarda=Commit
                CommonBC.Syncronize(this, PF);
                bbdd.perfil.Add(PF);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //En caso de que no se guarde, eliminara al objeto
                bbdd.perfil.Remove(PF);
                return false;
            }

        }
        public bool Read()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                //Obtener el primer registro que coincida con el codigo de perfil usando LinQ
                Notaria.Datos.perfil PF = bbdd.perfil.First(e => e.cod_perfil == cod_perfil);
                //Pasar los valores Datos(bd) a negocio 
                CommonBC.Syncronize(PF, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool Delete()
        {
            // Creo una instancia de conexión a Datos (SIEMPRE EN TODOS LOS METODOS)
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.perfil PF = bbdd.perfil.First(e => e.cod_perfil == cod_perfil);
                bbdd.perfil.Remove(PF);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Perfil> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.perfil> listadoDatos = bbdd.perfil.ToList<Notaria.Datos.perfil>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Perfil> listadoPerfil = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoPerfil;
            }
            catch (Exception)
            {
                return new List<Perfil>();
            }
        }
        private List<Perfil> GenerarListado(List<Notaria.Datos.perfil> listadoDatos)
        {
            List<Perfil> listaPerfil = new List<Perfil>();

            foreach (Notaria.Datos.perfil dato in listadoDatos)
            {

                Perfil negocio = new Perfil();
                CommonBC.Syncronize(dato, negocio);

                listaPerfil.Add(negocio);
            }

            return listaPerfil;
        }
        #endregion
    }


}
