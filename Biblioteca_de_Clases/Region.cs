using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_clases
{
    public class Region
    {
        public String cod_region { get; set; }  
        public String nombre { get; set; }

        public Region()
        {
            this.Init();
        }

        private void Init()
        {
            cod_region = String.Empty;
            nombre = String.Empty;
        }
    }
}
