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
//---------------------------------
using System.IO;

namespace MenuPrincipalEjercicios
{
    /// <summary>
    /// Lógica de interacción para VentanaEjercicio25.xaml
    /// </summary>
    public partial class VentanaEjercicio25 : Window
    {
        const string RUTA = @"../../imagenesVisor";
        List<BitmapImage> imagenes = new List<BitmapImage>();

        public VentanaEjercicio25()
        {
            InitializeComponent();
        }

        //Al iniciar el programa
        private void evento_inicializarPrograma(object sender, EventArgs e)
        {
            try
            {
                string[] rutaImagenes = Directory.GetFiles(RUTA);

                for (int i = 0; i < rutaImagenes.Length; i++)
                {
                    imagenes.Add(new BitmapImage(new Uri(rutaImagenes[i], UriKind.Relative)));
                }

                sld_visor.Maximum = rutaImagenes.Length - 1;//Menos uno porque el visor empieza desde 0 e inculye el número
                img_imagenActual.Source = imagenes[0];

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar las imágenes");
            }
        }

        //evento mover el slider
        private void sld_visor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int posicion = int.Parse(Math.Round(((Slider)sender).Value).ToString());
            img_imagenActual.Source = imagenes[posicion];
        }

        private void img_imagenActual_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            vtn_Imagen ventanaImagen = new vtn_Imagen();
            Image tmpImagen = new Image();
            tmpImagen.Source = img_imagenActual.Source;
            ventanaImagen.Content = tmpImagen;

            ventanaImagen.WindowState = System.Windows.WindowState.Maximized;
            ventanaImagen.ShowDialog();
        }
    }
}
