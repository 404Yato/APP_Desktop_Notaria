using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using static System.Net.WebRequestMethods;
using Biblioteca_de_Clases;
using Biblioteca_de_Clases.Model;

namespace Notaria_WPF
{
    /// <summary>
    /// Lógica de interacción para Documentos.xaml
    /// </summary>
    public partial class Documentos : MetroWindow
    {
        public Documentos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSubir_Click(object sender, RoutedEventArgs e)
        {
            /*OpenFileDialog open = new OpenFileDialog();

                open.Multiselect = false;

                open.Filter = "AllFiles|*.*";

                if ((bool)open.ShowDialog())

                {

                    Uploader(open.FileName, open.OpenFile());
                }*/

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".docx"; // Required file extension 
            fileDialog.Filter = "Text documents (.docx)|*.docx"; // Optional file extensions

            fileDialog.ShowDialog();

            bool? res = fileDialog.ShowDialog();

            if (res.HasValue && res.Value)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fileDialog.FileName);
                MessageBox.Show(sr.ReadToEnd());
                //.Text = fileDialog.FileName;
                sr.Close();


                byte[] file = null;
                Stream mystream = fileDialog.OpenFile();
                using(MemoryStream ms = new MemoryStream())
                {
                    mystream.CopyTo(ms);
                    file = ms.ToArray();
                }

                Biblioteca_de_Clases.Model.NotariaEntities db = new Biblioteca_de_Clases.Model.NotariaEntities()
                {
                    //template_documento docTem = new template_documento();
                };

            }
        }



   
        private static void Uploader(string filename, Stream Data)

        {


            BinaryReader reader = new BinaryReader(Data);

            const string path = @"C:\new\file";

            FileStream fstream = new FileStream(path, FileMode.CreateNew);

            BinaryWriter wr = new BinaryWriter(fstream);

            wr.Write(reader.ReadBytes((int)Data.Length));

            wr.Close();

            fstream.Close();

        }

    
    }
}
