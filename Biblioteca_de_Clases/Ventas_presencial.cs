using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Ventas_presencial
    {
        #region PROPIEDADES
        public String Cod_Venta { get; set; }
        public int Amount { get; set; }
        public DateTime Transaction_date { get; set; }
        public String Rut_persona { get; set; }
        public String Estado { get; set; }
        public String Cod_documento { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Ventas_presencial() //Inicializar Constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Cod_Venta = String.Empty;
            Amount = 0;
            Transaction_date = DateTime.Now;
            Rut_persona = String.Empty;
            Estado = String.Empty;
            Cod_documento = String.Empty;
        }
        #endregion

    }
}
