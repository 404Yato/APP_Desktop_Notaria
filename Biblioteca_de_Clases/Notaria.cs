using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Notaria
    {
        #region PROPIEDADES
        public String Cod_notaria { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Telefono2 { get; set; }
        public String Fax { get; set; }
        public String Email_notaria { get; set; }
        public String Email_meson { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Notaria() //Inicializar constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Cod_notaria = String.Empty;
            Direccion = String.Empty;
            Telefono = String.Empty;
            Telefono2 = String.Empty;
            Fax = String.Empty;
            Email_notaria = String.Empty;
            Email_meson = String.Empty;
        }
        #endregion

        #region METODOS

        #endregion
    }
}
