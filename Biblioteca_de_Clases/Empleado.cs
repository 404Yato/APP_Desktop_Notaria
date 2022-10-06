using Notaria.Datos;
using System;
using System.Collections.Generic;
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
        public Empleado() //Inicializar el constructor
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
        #endregion
    }
}
