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
    using System.Collections.Generic;
    
    public partial class doc_emitido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public doc_emitido()
        {
            this.ventas_online = new HashSet<ventas_online>();
            this.ventas_presencial = new HashSet<ventas_presencial>();
        }
    
        public string cod_documento { get; set; }
        public byte[] copia_documento { get; set; }
        public System.DateTime fecha_emision { get; set; }
        public int precio { get; set; }
        public bool valido { get; set; }
        public bool presencialidad { get; set; }
        public string rut_cliente_pres { get; set; }
        public string cod_tramite { get; set; }
        public string usuario_rut { get; set; }
        public string empleado_rut { get; set; }
    
        public virtual empleado empleado { get; set; }
        public virtual tipo_tramite tipo_tramite { get; set; }
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ventas_online> ventas_online { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ventas_presencial> ventas_presencial { get; set; }
    }
}
