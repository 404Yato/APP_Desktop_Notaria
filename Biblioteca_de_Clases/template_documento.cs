using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Notaria.Datos;


namespace Biblioteca_de_Clases
{
    public class template_documento
    {
        public int cod_template { get; set; }
        public string nombre { get; set; }
        public byte[] template { get; set; }
        public System.DateTime fecha_subida { get; set; }

        public template_documento()
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            
            nombre = string.Empty;
            template = new byte[10];
            fecha_subida = DateTime.Now;


        }

        public bool Create()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            Notaria.Datos.template_documento template = new Notaria.Datos.template_documento();

            try
            {

                CommonBC.Syncronize(this, template);
                bbdd.template_documento.Add(template);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //En caso de que no se guarde, eliminara al objeto
                bbdd.template_documento.Remove(template);
                return false;
            }
        }

        public List<template_documento> ReadAll()
        {
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Notaria.Datos.template_documento> listadoDatos = bbdd.template_documento.ToList<Notaria.Datos.template_documento>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<template_documento> listadoTemplates = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoTemplates;
            }
            catch (Exception)
            {
                return new List<template_documento>();
            }
        }

        private List<template_documento> GenerarListado(List<Notaria.Datos.template_documento> listadoDatos)
        {
            List<template_documento> listadoTemplate = new List<template_documento>();

            foreach (Notaria.Datos.template_documento dato in listadoDatos)
            {

                template_documento template = new template_documento();
                CommonBC.Syncronize(dato, template);

                listadoTemplate.Add(template);
            }

            return listadoTemplate;
        }


        public bool Delete()
        {
            // Creo una instancia de conexión a Datos (SIEMPRE EN TODOS LOS METODOS)
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();
            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.template_documento template = bbdd.template_documento.First(e => e.cod_template == cod_template);
                bbdd.template_documento.Remove(template);
                bbdd.SaveChanges();
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
                Notaria.Datos.template_documento template = bbdd.template_documento.First(e => e.cod_template == cod_template);
                //Pasar los valores de las propiedades de negocio a Datos
                CommonBC.Syncronize(this, template);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Read()
        {
            // Creo una instancia de conexión a Datos
            Notaria.Datos.PortafolioEntities bbdd = new Notaria.Datos.PortafolioEntities();

            try
            {
                //Obtener el primer registro que coincida con el Rut usando LinQ
                Notaria.Datos.template_documento template = bbdd.template_documento.First(e => e.cod_template == cod_template);
                //Pasar los valores Datos(bd) a negocio 
                CommonBC.Syncronize(template, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
    
        
}   
