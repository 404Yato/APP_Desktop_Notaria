//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notaria.Datos
{
    using System;
    
    public partial class buscar_documento_Result
    {
        public int cod_documento { get; set; }
        public byte[] copia_documento { get; set; }
        public System.DateTime fecha_emision { get; set; }
        public int precio { get; set; }
        public string estado { get; set; }
        public bool valido { get; set; }
        public bool presencialidad { get; set; }
        public string rut_cliente_pres { get; set; }
        public string cod_tramite { get; set; }
        public string usuario_rut { get; set; }
        public string empleado_rut { get; set; }
    }
}
