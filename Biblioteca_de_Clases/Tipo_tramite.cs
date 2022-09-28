using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Tipo_tramite
    {
        #region PROPIEDADES
        public String Cod_tramite { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Requisitos { get; set; }
        public int Precio { get; set; }
        public String Cod_template { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Tipo_tramite() //Inicializar Constructor
        {
            this.Init();
        }

        private void Init() // Constructor
        {
            Cod_tramite = String.Empty;
            Nombre = String.Empty;
            Descripcion = String.Empty;
            Requisitos = String.Empty;
            Precio = 0;
            Cod_template = String.Empty;
        }
        #endregion
    }
}
