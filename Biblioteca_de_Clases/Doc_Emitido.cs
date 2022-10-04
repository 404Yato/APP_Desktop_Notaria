using Biblioteca_de_Clases;
using Notaria.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca_de_Clases
{
    public class Doc_Emitido
    {
        #region PROPIEDADES
        public string cod_documento { get; set; }
        public System.DateTime fecha_emision { get; set; }
        public int precio { get; set; }
        public bool valido { get; set; }
        public bool presencialidad { get; set; }
        public string rut_cliente_pres { get; set; }
        public string cod_tramite { get; set; }
        public string usuario_rut { get; set; }
        public string empleado_rut { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Doc_Emitido() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            cod_documento = String.Empty;
            fecha_emision = DateTime.Now;
            precio = 0;
            valido = false;
            presencialidad = false;
            rut_cliente_pres = String.Empty;
            cod_tramite = String.Empty;
            usuario_rut = String.Empty;
            empleado_rut = String.Empty;
        }
        #endregion

        #region METODOS
        public List<Doc_Emitido> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.doc_emitido> listadoDatos = bbdd.doc_emitido.ToList<Notaria.Datos.doc_emitido>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Doc_Emitido> listadoDocumentos = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoDocumentos;
            }
            catch (Exception)
            {
                return new List<Doc_Emitido>();
            }
        }

        private List<Doc_Emitido> GenerarListado(List<Notaria.Datos.doc_emitido> listadoDatos)
        {
            List<Doc_Emitido> listaDoc = new List<Doc_Emitido>();

            foreach (Notaria.Datos.doc_emitido dato in listadoDatos)
            {

                Doc_Emitido doc_emitido = new Doc_Emitido();
                CommonBC.Syncronize(dato, doc_emitido);

                listaDoc.Add(doc_emitido);
            }

            return listaDoc;
        }

        public bool Read()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.doc_emitido documento = bbdd.doc_emitido.First(e => e.usuario_rut == usuario_rut);
                //Pasar los valores Datos(bd) a negocio 
                CommonBC.Syncronize(documento, this);
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