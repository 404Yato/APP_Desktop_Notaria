using System;

namespace Biblioteca_clases
{
    public class Region
    {
        #region PROPIEDADES
        public String Cod_region { get; set; }  
        public String Nombre { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Region() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Cod_region = String.Empty;
            Nombre = String.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
