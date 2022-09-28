using System;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Shapes;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : MetroWindow
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private bool IsNumber(string Text) //metodo que verifica que el caracter ingresado se un número, retorna un booleano
        {
            int output;
            return int.TryParse(Text, out output);
        }
        private void txtRut_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }

        }
    }
}
