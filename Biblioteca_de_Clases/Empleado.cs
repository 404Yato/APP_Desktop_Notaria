using Notaria.Datos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Empleado
    {
        #region PROPIEDADES
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int fono { get; set; }
        public string direccion { get; set; }
        public string cod_comuna { get; set; }
        public string cod_perfil { get; set; }
        public string email { get; set; }


        #endregion

        #region CONSTRUCTOR
        public string Apellidos
        {
            get { return this.apellido_paterno + " " + this.apellido_materno; }
        }


        private void Init() //Constructor
        {
            rut = string.Empty;
            nombre = string.Empty;
            apellido_paterno = string.Empty;
            apellido_materno = string.Empty;
            fono = 0;
            direccion = string.Empty;
            cod_comuna = string.Empty;
            cod_perfil = string.Empty;
            email = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Create()
        {
            // Creo una instancia de conexión a Datos
            //OnBreakEntities es el nombre de la conexión
            PortafolioEntities bbdd = new PortafolioEntities();
            Notaria.Datos.empleado EP = new Notaria.Datos.empleado();

            try
            {
                //Pasar los valores de las propiedades de negocio a Datos
                //CommonBC.Syncronize(desde, hasta); usa las propiedades definidas en this class
                //luego se agraga con el metodo add con el objeto creado como parametro y saveChanges() guarda=Commit
                CommonBC.Syncronize(this, EP);
                bbdd.empleado.Add(EP);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //En caso de que no se guarde, eliminara al objeto
                bbdd.empleado.Remove(EP);
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
                Notaria.Datos.empleado cliente = bbdd.empleado.First(e => e.rut == rut);
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
        public bool Read()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                //Obtener el primer registro que coincida con el codigo de perfil usando LinQ
                Notaria.Datos.empleado PF = bbdd.empleado.First(e => e.rut == rut);
                //Pasar los valores Datos(bd) a negocio 
                CommonBC.Syncronize(PF, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool Read(string var)
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                //Obtener el primer registro que coincida con el codigo de perfil usando LinQ
                Notaria.Datos.empleado PF = bbdd.empleado.First(e => e.cod_perfil == var);
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
                Notaria.Datos.empleado PF = bbdd.empleado.First(e => e.rut == rut);
                bbdd.empleado.Remove(PF);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Empleado> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.empleado> listadoDatos = bbdd.empleado.ToList<Notaria.Datos.empleado>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Empleado> listadoEmp = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoEmp;
            }
            catch (Exception)
            {
                return new List<Empleado>();
            }
        }
        private List<Empleado> GenerarListado(List<Notaria.Datos.empleado> listadoDatos)
        {
            List<Empleado> listaEmpleado = new List<Empleado>();

            foreach (Notaria.Datos.empleado dato in listadoDatos)
            {

                Empleado negocio = new Empleado();
                CommonBC.Syncronize(dato, negocio);

                listaEmpleado.Add(negocio);
            }

            return listaEmpleado;
        }
        #endregion
    }
}
