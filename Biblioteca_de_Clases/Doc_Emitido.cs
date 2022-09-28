using System;

namespace Biblioteca_clases
{
    public class Doc_Emitido
    {
        #region PROPIEDADES
        public String Cod_documento { get; set; }
        public DateTime Fecha_emision { get; set; }
        public int Precio { get; set; }
        public bool Valido { get; set; }
        public bool Presencialidad {get; set; }
        public String Rut_cliente_pres { get; set; }
        public String Cod_tramite { get; set; }
        public String Usuario_rut { get; set; }
        public String Empleado_rut { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Doc_Emitido() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Cod_documento = String.Empty;
            Fecha_emision = DateTime.Now;
            Precio = 0;
            Valido = false;
            Presencialidad = false;
            Rut_cliente_pres = String.Empty;
            Cod_tramite = String.Empty;
            Usuario_rut = String.Empty;
            Empleado_rut = String.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}