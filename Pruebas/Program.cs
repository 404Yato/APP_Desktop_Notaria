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
                cod_region = "AP",
                nombre = "Arinca y Parinacota"
            };
            Console.WriteLine("Objeto Creado");

            if (region.Create())
            {

                Console.WriteLine("Exito");
            }

            else
            {
                Console.WriteLine("Error");
            }
            Console.ReadKey();
        }
    }
}
