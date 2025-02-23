﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteca_de_Clases;
using System.Configuration;
using NotariaL;
using System.Data.SqlClient;
using System.Data;
using NotariaWPF;
using System.ServiceModel.Security;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static string rutEmpleado { get; set; } = string.Empty;

       public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private bool ValidarCampos()
        {
            bool validar = true;
            if (txb_contra.Text == string.Empty)
             {
                 validar = false;
             }
            if (txb_rut.Text == string.Empty)
            {
                validar = false;
            }
            return validar;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rutEmpleado = txb_rut.Text;
            string rut = txb_rut.Text;
            string contra = txb_contra.Text;
            if (ValidarCampos())                                                                                // VALIDACION DE CAMPOS VACIOS
            {
                Empleado Em = new Empleado();
                Empleado empleado = new Empleado()
                {
                    rut = rut
                };
                if (empleado.Read())                                                                            //Validación Rut correcto
                {
                    if (empleado.ReadContra(contra))                                                            //Validación Contraseña Correcta
                    {
                        if (Em.login(rut, contra) == 1)                                                                 // ADMINISTRADOR
                        {
                            Administracion admin = new Administracion();
                            admin.Show();
                            this.Close();
                        }
                        else if (Em.login(rut, contra) == 2)                                                                 // Igresar Notario
                        {
                            VistaNotario NT = new VistaNotario();
                            NT.Show();
                            this.Close();
                        }
                        else if (Em.login(rut, contra) == 3)                                                                 // RECEPCIONISTA
                        {
                            VistaRecepcionista RC = new VistaRecepcionista();
                            RC.Show();
                            this.Close();
                        }
                        else if (Em.login(rut, contra) == 4)                                                                 // CAJERO
                        {
                            VistaCajero CJ = new VistaCajero();
                            CJ.Show();
                            this.Close();
                        }
                        else if (Em.login(rut, contra) == 5)                                                                 // Ingresar Oficial
                        {
                            VistaOficial OF = new VistaOficial();
                            OF.Show();
                            this.Close();
                        }
                        else if (Em.login(rut, contra) == 6)                                                                 // Ingresar Conservador de bienes raíces
                        {
                            VistaBienesRaices BR = new VistaBienesRaices();
                            BR.Show();
                            this.Close();
                        }

                        else if (Em.login(rut, contra) == 7)                                                                 // Ingresar Personal de póliza
                        {
                            VistaPoliza PL = new VistaPoliza();
                            PL.Show();
                            this.Close();
                        }
                        else if (Em.login(rut, contra) == 8)                                                                 // CONTADOR
                        {
                            Contador CO = new Contador();
                            CO.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("La contraseña o el rut son incorrectos", "Ups Empleado no encontrado !",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecta", "Contraseña inválida",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El rut es incorrecto", "Rut inválido",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else 
            {
                MessageBox.Show("Ups.. tenemos campos vacíos !!", "Ups Compos Vacíos!",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
