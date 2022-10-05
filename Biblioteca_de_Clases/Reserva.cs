using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Reserva
    {
        #region PROPIEDADES
        public string cod_reserva { get; set; }
        public System.DateTime fecha_hora { get; set; }
        public string motivo { get; set; }
        public string estado { get; set; }
        public string usuario_rut { get; set; }
        public string cod_tramite { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Reserva() //Inicializar Constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            cod_reserva = string.Empty;
            fecha_hora = DateTime.Now;
            motivo = string.Empty;
            estado = string.Empty;
            usuario_rut = string.Empty;
            cod_tramite = string.Empty;
        }
        #endregion

        #region METODOS
        public List<Reserva> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.reserva> listadoDatos = bbdd.reserva.ToList<Notaria.Datos.reserva>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Reserva> listadoClientes = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoClientes;
            }
            catch (Exception)
            {
                return new List<Reserva>();
            }
        }

        private List<Reserva> GenerarListado(List<Notaria.Datos.reserva> listadoDatos)
        {
            List<Reserva> listaClient = new List<Reserva>();

            foreach (Notaria.Datos.reserva dato in listadoDatos)
            {

                Reserva reservas = new Reserva();
                CommonBC.Syncronize(dato, reservas);

                listaClient.Add(reservas);
            }

            return listaClient;
        }

        public bool Read()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.reserva cliente = bbdd.reserva.First(e => e.usuario_rut == usuario_rut);
                //Pasar los valores Datos(bd) a negocio 
                CommonBC.Syncronize(cliente, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion
    }
}
