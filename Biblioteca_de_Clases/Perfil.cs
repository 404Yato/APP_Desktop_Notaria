using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Perfil
    {
        #region PROPIEDADES
        public String Cod_perfil { get; set; }
        public String Rol { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Perfil() //Inicializar constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Cod_perfil = String.Empty;
            Rol = String.Empty;
        }
        #endregion

        #region METODOS
        #endregion
    }


}
