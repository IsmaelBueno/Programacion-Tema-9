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
//----------------------------
using Microsoft.Win32;
using System.IO;

namespace MenuPrincipalEjercicios
{
    /// <summary>
    /// Lógica de interacción para VentanaEjercicio14.xaml
    /// </summary>
    public partial class VentanaEjercicio14 : Window
    {
        string ruta = @"C:\";

        public VentanaEjercicio14()
        {
            InitializeComponent();
        }
        private void evento_btn_selecionarFichero(object sender, RoutedEventArgs e)
        {
            //Selección del archivo
            OpenFileDialog vtn_abrirArchivo = new OpenFileDialog();

            vtn_abrirArchivo.Filter = "Textos|*.txt";
            vtn_abrirArchivo.InitialDirectory = ruta;

            bool? seleccion = vtn_abrirArchivo.ShowDialog();

            //Extraer información del archivo
            char[] separadorLineas = { '\n' };
            char[] separadorPalabras = { ' ', '_', '\t', '\n' };
            string texto = string.Empty;
            FileInfo informacionFichero;

            if (seleccion == true)
            {
                ruta = vtn_abrirArchivo.FileName;

                using (StreamReader lector = new StreamReader(ruta))
                {
                    texto = lector.ReadToEnd();
                }

                string[] lineas = texto.Split(separadorLineas, StringSplitOptions.RemoveEmptyEntries);
                string[] palabras = texto.Split(separadorPalabras, StringSplitOptions.RemoveEmptyEntries);
                informacionFichero = new FileInfo(ruta);

                lbl_numeroLineas.Content = lineas.Length;
                lbl_numeroPalabras.Content = palabras.Length;
                lbl_ruta.Content = informacionFichero.Directory;
                lbl_tamanio.Content = informacionFichero.Length;
                lbl_nombreArchivo.Content = informacionFichero.Name;
                lbl_FechaCreacion.Content = informacionFichero.CreationTime;
            }
        }
    }
}
