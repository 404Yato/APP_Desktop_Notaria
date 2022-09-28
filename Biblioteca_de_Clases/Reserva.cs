using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Reserva
    {
        #region PROPIEDADES
        public String Cod_reserva { get; set; }
        public DateTime Fecha_hora { get; set; }
        public String Motivo { get; set; }
        public String Estado { get; set; }
        public String Usuario_rut { get; set; }
        public String Cod_tramite { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Reserva() //Inicializar Constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Cod_reserva = String.Empty;
            Fecha_hora = DateTime.Now;
            Motivo = String.Empty;
            Estado = String.Empty;
            Usuario_rut = String.Empty;
            Cod_reserva = String.Empty;
        }
        #endregion
    }
}
