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

namespace Ejercicio12
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte rojo = 255;
        byte verde = 255;
        byte azul = 255;
        const byte TRANSPARENCIA = 255;

        public MainWindow()
        {
            InitializeComponent();
        }

        //rojo
        private void ScrollBar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rojo = byte.Parse((Math.Round(e.NewValue * 10)).ToString());
            rtg_panelcolor.Fill = new SolidColorBrush(Color.FromArgb(TRANSPARENCIA, rojo, verde, azul));
        }

        //verde
        private void ScrollBar_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            verde = byte.Parse((Math.Round(e.NewValue * 10)).ToString());
            rtg_panelcolor.Fill = new SolidColorBrush(Color.FromArgb(TRANSPARENCIA, rojo, verde, azul));
        }

        //azul
        private void ScrollBar_ValueChanged_3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            azul = byte.Parse((Math.Round(e.NewValue * 10)).ToString());
            rtg_panelcolor.Fill = new SolidColorBrush(Color.FromArgb(TRANSPARENCIA, rojo, verde, azul));
        }
    }
}
