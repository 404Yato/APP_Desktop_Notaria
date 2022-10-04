using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.PdfViewer;

namespace Biblioteca_de_Clases
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Stream docStream;

        public event PropertyChangedEventHandler PropertyChanged;

        public Stream DocumentStream
        {
            get
            {
                return docStream;
            }
            set
            {
                docStream = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DocumentStream"));
            }
        }

        public void PdfReport()
        {
            //Load the stream from the local system.
            docStream = new FileStream(@"../../Data/HTTP Succinctly.pdf", FileMode.OpenOrCreate);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
