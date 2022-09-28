﻿using System;
namespace Biblioteca_clases
{
    public class Usuario
    {
        #region PROPIEDADES
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Apellido_paterno { get; set; }
        public String Apellido_materno { get; set; }
        public int Fono { get; set; }
        public String Contrasena {get; set; }
        public String Email { get; set; }
        public String Comuna {get; set; }
        #endregion

        #region CONSTRUCTOR
        public Usuario() //Inicializar el constructor
        {
            this.Init();
        }

        private void Init() //Constructor
        {
            Rut = String.Empty;
            Nombre = String.Empty;
            Apellido_paterno = String.Empty;
            Apellido_materno = String.Empty;
            Fono = 0;
            Contrasena = String.Empty;
            Email = String.Empty;
            Comuna = String.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }


}

