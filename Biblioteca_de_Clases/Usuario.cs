using Biblioteca_de_Clases;
using Notaria.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca_clases
{
    public class Usuario
    {
        #region PROPIEDADES
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int fono { get; set; }
        public string contraseña { get; set; }
        public string email { get; set; }
        public string cod_comuna { get; set; }
        #endregion

        public string Apellidos
        {
            get { return this.apellido_paterno + " " + this.apellido_materno; }
        }

        #region CONSTRUCTOR
        public Usuario() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            rut = string.Empty;
            nombre = string.Empty;
            apellido_paterno = string.Empty;
            apellido_materno = string.Empty;
            fono = 0;
            contraseña = string.Empty;
            email = string.Empty;
            cod_comuna = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Create()
        {
            // Creo una instancia de conexión a Datos
            //OnBreakEntities es el nombre de la conexión
            PortafolioEntities bbdd = new PortafolioEntities();
            Notaria.Datos.usuario Us = new Notaria.Datos.usuario();

            try
            {
                //Pasar los valores de las propiedades de negocio a Datos
                //CommonBC.Syncronize(desde, hasta); usa las propiedades definidas en this class
                //luego se agraga con el metodo add con el objeto creado como parametro y saveChanges() guarda=Commit
                CommonBC.Syncronize(this, Us);
                bbdd.usuario.Add(Us);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //En caso de que no se guarde, eliminara al objeto
                bbdd.usuario.Remove(Us);
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
                Notaria.Datos.usuario Us = bbdd.usuario.First(e => e.rut == rut);
                bbdd.usuario.Remove(Us);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.usuario cliente = bbdd.usuario.First(e => e.rut == rut);
                //Pasar los valores de las propiedades de negocio a Datos
                CommonBC.Syncronize(this, cliente);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Usuario> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.usuario> listadoDatos = bbdd.usuario.ToList<Notaria.Datos.usuario>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Usuario> listadoUsuario = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoUsuario;
            }
            catch (Exception)
            {
                return new List<Usuario>();
            }
        }

        private List<Usuario> GenerarListado(List<Notaria.Datos.usuario> listadoDatos)
        {
            List<Usuario> listadoUsuario = new List<Usuario>();

            foreach (Notaria.Datos.usuario dato in listadoDatos)
            {

                Usuario negocio = new Usuario();
                CommonBC.Syncronize(dato, negocio);

                listadoUsuario.Add(negocio);
            }

            return listadoUsuario;
        }

        public IList<Notaria.Datos.filtrar_rut_Result> Filtrar_rut(string variable)
        {
            PortafolioEntities bb = new PortafolioEntities();
            var results = bb.filtrar_rut(variable);

            return results.ToList();
        }

        #endregion
    }


}

