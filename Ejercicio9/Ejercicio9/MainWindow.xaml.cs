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
using System.Windows.Navigation;
using System.Windows.Shapes;
//---------------------------------------
using System.IO;
using System.Text.RegularExpressions;

namespace Ejercicio9
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string[] rutas = null;
        static Random rnd = new Random();
        static int uno = 0;
        static int dos = 0;
        static int tres = 0;
        static int cuatro = 0;
        static int cinco = 0;
        static int seis = 0;
        static int totalTiradas = 0;

        public MainWindow()
        {
            InitializeComponent();
            ObtenerRutasImagenes();

        }

        private void ObtenerRutasImagenes()
        {
            rutas = Directory.GetFiles("../../imagenes/");           
        }
        private void tbx_nTiradas_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regla = new Regex("[0-9]");
            if (!regla.IsMatch(e.Text)) e.Handled = true;
        }
        private void RegistrarResultadosyEstadisticas(int r)
        {
            switch (r + 1)//Le sumo ya que en los dados no existe el 0
            {
                case 1:
                    uno++;
                    lbl_resultado1.Content = uno.ToString();
                    break;
                case 2:
                    dos++;
                    lbl_resultado2.Content = dos.ToString();
                    break;
                case 3:
                    tres++;
                    lbl_resultado3.Content = tres.ToString();
                    break;
                case 4:
                    cuatro++;
                    lbl_resultado4.Content = cuatro.ToString();
                    break;
                case 5:
                    cinco++;
                    lbl_resultado5.Content = cinco.ToString();
                    break;
                case 6:
                    seis++;
                    lbl_resultado6.Content = seis.ToString();
                    break;
            }
            lbl_totaltiradas.Content = totalTiradas.ToString();

            #region Calcular estadisticas
            double tmp = 0D;

            //Para el uno
            tmp = (double)uno / (double)totalTiradas * 100;
            lbl_estadistica1.Content = Math.Round(tmp,2);

            //Para el dos
            tmp = (double)dos / (double)totalTiradas * 100;
            lbl_estadistica2.Content = Math.Round(tmp, 2);

            //Para el tres
            tmp = (double)tres / (double)totalTiradas * 100;
            lbl_estadistica3.Content = Math.Round(tmp, 2);

            //Para el cuatro
            tmp = (double)cuatro / (double)totalTiradas * 100;
            lbl_estadistica4.Content = Math.Round(tmp, 2);

            //Para el cinco
            tmp = (double)cinco / (double)totalTiradas * 100;
            lbl_estadistica5.Content = Math.Round(tmp, 2);

            //Para el seis
            tmp = (double)seis / (double)totalTiradas * 100;
            lbl_estadistica6.Content = Math.Round(tmp, 2);
#endregion
        }

        //Una tirada, la imagen cambia
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int tmp;

            tmp = rnd.Next(0, rutas.Length);
            totalTiradas++;
            RegistrarResultadosyEstadisticas(tmp);
            if(chx_simularimagen.IsChecked==true)
            img_dado.Source = new BitmapImage(new Uri(rutas[tmp], UriKind.Relative));
        }
        //Tiradas automáticas, la imagen no cambia
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < int.Parse(tbx_nTiradas.Text); i++)
            {
                int tmp;

                tmp = rnd.Next(0, rutas.Length);
                totalTiradas++;
                RegistrarResultadosyEstadisticas(tmp);
            }
        }
        //Limpiar
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            uno = 0;
            dos = 0;
            tres = 0;
            cuatro = 0;
            cinco = 0;
            seis = 0;
            totalTiradas = 0;
            lbl_resultado1.Content = 0;
            lbl_resultado2.Content = 0;
            lbl_resultado3.Content = 0;
            lbl_resultado4.Content = 0;
            lbl_resultado5.Content = 0;
            lbl_resultado6.Content = 0;
            lbl_totaltiradas.Content = 0;
            lbl_estadistica1.Content = 0;
            lbl_estadistica2.Content = 0;
            lbl_estadistica3.Content = 0;
            lbl_estadistica4.Content = 0;
            lbl_estadistica5.Content = 0;
            lbl_estadistica6.Content = 0;
        }
    }
}
