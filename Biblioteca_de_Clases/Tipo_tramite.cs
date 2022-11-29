using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notaria.Datos;

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
        public int cod_tramite { get; set; }
        public string nombre_tramite { get; set; }
        public string descripcion { get; set; }
        public string requisitos { get; set; }
        public int precio { get; set; }
        public int cod_template { get; set; }

        public Tipo_tramite()
        {
            this.Init();
        }

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
