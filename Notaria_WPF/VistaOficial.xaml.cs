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
using System.Windows.Shapes;
using Biblioteca_de_Clases;
using Notaria.Datos;

namespace Notaria_WPF
{
    /// <summary>
    /// Interaction logic for VistaOficial.xaml
    /// </summary>
    public partial class VistaOficial : Window
    {
        public VistaOficial()
        {
            InitializeComponent();
            LlenarGrid();
        }
        private void LlenarGrid()
        {
            Doc_Emitido doc_Emitido = new Doc_Emitido();

            DtOficial.ItemsSource = doc_Emitido.ReadAll();
            DtOficial.Items.Refresh();
        }
    }
}
