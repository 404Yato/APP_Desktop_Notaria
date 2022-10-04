using System;
using Notaria.Datos;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Region
    {
        #region PROPIEDADES
        public string cod_region { get; set; }
        public string nombre { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Region() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            cod_region = string.Empty;
            nombre = string.Empty;
        }
        #endregion

        #region Metodos
        public bool Create()
        {
            // Creo una instancia de conexión a Datos
            //OnBreakEntities es el nombre de la conexión
            PortafolioEntities bbdd = new PortafolioEntities();
            Notaria.Datos.region regionOBJ = new Notaria.Datos.region();

            try
            {
                //Pasar los valores de las propiedades de negocio a Datos
                //CommonBC.Syncronize(desde, hasta); usa las propiedades definidas en this class
                //luego se agraga con el metodo add con el objeto creado como parametro y saveChanges() guarda=Commit
                CommonBC.Syncronize(this, regionOBJ);
                bbdd.region.Add(regionOBJ);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //En caso de que no se guarde, eliminara al objeto
                bbdd.region.Remove(regionOBJ);
                return false;
            }

        }
        #endregion
    }
}
