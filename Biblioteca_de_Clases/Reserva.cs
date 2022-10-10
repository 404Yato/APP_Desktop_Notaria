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
        public int cod_reserva { get; set; }
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
                List<Reserva> listadoReservas = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoReservas;
            }
            catch (Exception)
            {
                return new List<Reserva>();
            }
        }

        private List<Reserva> GenerarListado(List<Notaria.Datos.reserva> listadoDatos)
        {
            List<Reserva> listaReserva = new List<Reserva>();

            foreach (Notaria.Datos.reserva dato in listadoDatos)
            {

                Reserva reservas = new Reserva();
                CommonBC.Syncronize(dato, reservas);

                listaReserva.Add(reservas);
            }

            return listaReserva;
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

        public bool Update()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.reserva cliente = bbdd.reserva.First(e => e.cod_reserva == cod_reserva);
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

        public IList<Notaria.Datos.buscar_reservas_Result> BuscarReserva(string variable)
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            var resultado = bbdd.buscar_reservas(variable);
            return resultado.ToList();
        }
        #endregion
    }
}
