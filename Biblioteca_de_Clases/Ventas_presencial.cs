using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Ventas_presencial
    {
        #region PROPIEDADES
        public int cod_venta { get; set; }
        public int amount { get; set; }
        public System.DateTime transaction_date { get; set; }
        public string rut_persona { get; set; }
        public string estado { get; set; }
        public int doc_emitido_cod_documento { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Ventas_presencial() //Inicializar Constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            amount = 0;
            transaction_date = DateTime.Now;
            rut_persona = string.Empty;
            estado = string.Empty;
            doc_emitido_cod_documento = 0;
        }
        #endregion

        public List<Ventas_presencial> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.ventas_presencial> listadoDatos = bbdd.ventas_presencial.ToList<Notaria.Datos.ventas_presencial>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Ventas_presencial> listadoVentas = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoVentas;
            }
            catch (Exception)
            {
                return new List<Ventas_presencial>();
            }
        }

        private List<Ventas_presencial> GenerarListado(List<Notaria.Datos.ventas_presencial> listadoDatos)
        {
            List<Ventas_presencial> listaVentas = new List<Ventas_presencial>();

            foreach (Notaria.Datos.ventas_presencial dato in listadoDatos)
            {

                Ventas_presencial ventas = new Ventas_presencial();
                CommonBC.Syncronize(dato, ventas);

                listaVentas.Add(ventas);
            }

            return listaVentas;
        }

        public bool Update()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.ventas_presencial cliente = bbdd.ventas_presencial.First(e => e.cod_venta == cod_venta);
                //Pasar los valores de las propiedades de negocio a Datos
                CommonBC.Syncronize(this, cliente);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IList<Notaria.Datos.buscar_ventas_pres_Result> BuscarVentasPres(string variable)
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            var resultado = bbdd.buscar_ventas_pres(variable);
            return resultado.ToList();
        }
        
        public IList<Notaria.Datos.buscar_ventas_pendientes_Result> BuscarVentasPendientes(string variable)
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            var resultado = bbdd.buscar_ventas_pendientes(variable);
            return resultado.ToList();
        }
    }
}
