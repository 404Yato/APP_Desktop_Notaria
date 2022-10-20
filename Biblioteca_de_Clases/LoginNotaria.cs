using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class LoginNotaria
    {
        public string nombre { get; set; }
        public int cod_perfil { get; set; }

        public LoginNotaria() //Inicializar constructor
        {
            this.Init();

        }

        private void Init() //Constructor
        {
            nombre = string.Empty;
            cod_perfil = 0;
        }

        public IList<Notaria.Datos.notarialogin_Result> NotariaLogin(string rut, string contra)
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            var resultado = bbdd.notarialogin(rut, contra);
            return resultado.ToList();
        }
    }
}
