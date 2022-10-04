using System;

namespace Biblioteca_clases
{
    public class Comuna
    {
        #region PROPIEDADES 
        public String Cod_comuna { get; set; } 
        public String Nombre { get; set; }
        public String Region { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Comuna() //Inicializar el constructor
        {
            this.Init(); 
        }
         
        private void Init() //Constructor
        {
            Cod_comuna = String.Empty;
            Nombre = String.Empty;
            Region = String.Empty;
        }
        #endregion

        #region METODOS
        #endregion
    }
}
