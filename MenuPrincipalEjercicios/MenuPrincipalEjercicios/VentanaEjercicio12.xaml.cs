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

namespace MenuPrincipalEjercicios
{
    /// <summary>
    /// Lógica de interacción para VentanaEjercicio12.xaml
    /// </summary>
    public partial class VentanaEjercicio12 : Window
    {
        byte rojo = 0;
        byte verde = 0;
        byte azul = 0;
        const byte TRANSPARENCIA = 255;

        public VentanaEjercicio12()
        {
            InitializeComponent();
        }

        //rojo
        private void ScrollBar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rojo = byte.Parse(Math.Round(e.NewValue).ToString());
            rtg_panelcolor.Fill = new SolidColorBrush(Color.FromArgb(TRANSPARENCIA, rojo, verde, azul));
        }

        //verde
        private void ScrollBar_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            verde = byte.Parse(Math.Round(e.NewValue).ToString());
            rtg_panelcolor.Fill = new SolidColorBrush(Color.FromArgb(TRANSPARENCIA, rojo, verde, azul));
        }

        //azul
        private void ScrollBar_ValueChanged_3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            azul = byte.Parse(Math.Round(e.NewValue).ToString());
            rtg_panelcolor.Fill = new SolidColorBrush(Color.FromArgb(TRANSPARENCIA, rojo, verde, azul));
        }
    }
}
