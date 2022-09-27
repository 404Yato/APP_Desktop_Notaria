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
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Apellido_paterno { get; set; }
        public String Apellido_materno { get; set; }
        public int Fono { get; set; }
        public String Direccion { get; set; }
        public String Cod_comuna { get; set; }
        public String Cod_perfil { get; set; }
        public String Email { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Empleado() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Rut = String.Empty;
            Nombre = String.Empty;
            Apellido_paterno = String.Empty;
            Apellido_materno = String.Empty;
            Fono = 0;
            Direccion = String.Empty;
            Cod_comuna = String.Empty;
            Cod_perfil = String.Empty;
            Email = String.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
