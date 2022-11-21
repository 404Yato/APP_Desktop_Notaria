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

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para firma.xaml
    /// </summary>
    public partial class firma : Window
    {
        public firma()
        {
            InitializeComponent();
        }
      
        
        //settings
        int diameter = 7;
        private Brush color = Brushes.Black;
        private bool ispaint = false;

        private void paintcircle(Brush circlecolor, Point position)
        {
            Ellipse newellipse = new Ellipse();
            newellipse.Fill = circlecolor;
            newellipse.Width = diameter;
            newellipse.Height = diameter;
            Canvas.SetLeft(newellipse, position.X);
            Canvas.SetTop(newellipse, position.Y);
            paintcanvas.Children.Add(newellipse);
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (ispaint)
            { 
                Point mouseposition = e.GetPosition(paintcanvas);
                paintcircle(color, mouseposition);
           
            }

        }
        private void paintcanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ispaint = true;
        }

        private void paintcanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ispaint = false;
        }

        private void paintcanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            ispaint = false;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }



 
    }
}
