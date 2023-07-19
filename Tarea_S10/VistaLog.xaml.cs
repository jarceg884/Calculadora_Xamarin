using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;


namespace Tarea_S10
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaLog : ContentPage
    {

        ObservableCollection<string> operaciones;
        //para el nombre del archivo
        private static string nombreArchivo = "LogCalcu.txt";
        //creando la ruta del archivo 
        private static string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private static string rutaCompleta = Path.Combine(ruta, nombreArchivo);
        public VistaLog()
        {
            operaciones = new ObservableCollection<string>();

            InitializeComponent();
            //operaciones.Add("Hola Mundo");
            agregar();
            string[] lines = File.ReadAllLines(rutaCompleta);
            int lineas = lines.Length;
            coleccion.ItemsSource = operaciones;
            Console.WriteLine(rutaCompleta);
            Console.WriteLine(lineas);
        }

        private void agregar()
        {
            string[] lines = File.ReadAllLines(rutaCompleta);
            foreach (string line in lines)
            {
                operaciones.Add(line);
            }

        }

    }
    
}