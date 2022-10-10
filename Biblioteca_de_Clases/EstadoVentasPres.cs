using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class EstadoVentasPres
    {
        private int idEstado;
        public int IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
