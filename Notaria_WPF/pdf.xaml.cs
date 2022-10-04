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
using System.Windows.Shapes;
using Syncfusion.Windows.PdfViewer;
using Biblioteca_de_Clases;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para pdf.xaml
    /// </summary>
    public partial class pdf : Window
    {
        public pdf()
        {
            InitializeComponent();
            PdfViewerControl pdfViewer = new PdfViewerControl();
            HomeGrid.Children.Add(pdfViewer);
        }
    }
}
