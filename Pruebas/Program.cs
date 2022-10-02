using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_de_Clases;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca_de_Clases.Region region = new Biblioteca_de_Clases.Region()
            {
                Cod_region = "REG-PA",
                Nombre = "Arica-Parinacota",
            };

            if (region.Create())
            {
                Console.WriteLine("Exito");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
