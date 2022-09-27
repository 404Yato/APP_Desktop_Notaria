﻿using System;

namespace Biblioteca_clases
{
    public class Comuna
    {
        public String cod_comuna { get; set; } 
        public String nombre { get; set; }
        public String region { get; set; }

        public Comuna()
        {
            this.Init();
        }

        private void Init()
        {
            cod_comuna = String.Empty;
            nombre = String.Empty;
            region = String.Empty;
        }
    }
}
