using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Biblioteca_clases
{
    public class Usuario
    {
        public String rut { get; set; }
        public String nombre { get; set; }
        public String apellido_paterno { get; set; }
        public String apellido_materno { get; set; }
        public int fono { get; set; }
        public String contrasena {get; set; }
        public String email { get; set; }
        public String comuna {get; set; }

        public Usuario()
        {
            this.Init();
        }

        private void Init()
        {
            rut = String.Empty;
            nombre = String.Empty;
            apellido_paterno = String.Empty;
            apellido_materno = String.Empty;
            fono = 0;
            contrasena = String.Empty;
            email = String.Empty;
            comuna = String.Empty;
        }
    }

    
}

