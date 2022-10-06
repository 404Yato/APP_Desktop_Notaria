using Biblioteca_clases;
using Notaria.Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class LlenarCombo
    {
        public string cod_comuna { get; set; }
        public string nombre { get; set; }


      
        public LlenarCombo() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            cod_comuna = string.Empty;
            nombre = string.Empty;
            
        }


        public IList<Notaria.Datos.llenarComboComuna_Result> Llenar(string variable) 
        {
            PortafolioEntities bb = new PortafolioEntities();
            var results = bb.llenarComboComuna(variable);

            return results.ToList();
        }




    }
}
