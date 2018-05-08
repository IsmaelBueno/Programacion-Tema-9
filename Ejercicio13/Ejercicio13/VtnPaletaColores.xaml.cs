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

namespace Ejercicio13
{
    /// <summary>
    /// Lógica de interacción para VtnPaletaColores.xaml
    /// </summary>
    public partial class VtnPaletaColores : Window
    {
        public delegate void Delegado(SolidColorBrush color, int PanelColor);
        public event Delegado ColorPaleta;

        byte rojo = 0;
        byte azul = 0;
        byte verde = 0;

        public VtnPaletaColores()
        {
            InitializeComponent();
        }

        //colores
        private void evento_color_rojo(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rojo = byte.Parse((Math.Round(e.NewValue * 10)).ToString());
            rct_colorPaleta.Fill = new SolidColorBrush(Color.FromRgb(rojo, verde, azul));
        }
        private void evento_color_verde(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            verde = byte.Parse((Math.Round(e.NewValue * 10)).ToString());
            rct_colorPaleta.Fill = new SolidColorBrush(Color.FromRgb(rojo, verde, azul));
        }
        private void evento_color_azul(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            azul = byte.Parse((Math.Round(e.NewValue * 10)).ToString());
            rct_colorPaleta.Fill = new SolidColorBrush(Color.FromRgb(rojo, verde, azul));
        }

        //boton con evento
        private void btn_paletaColroes_aplicar(object sender, RoutedEventArgs e)
        {
            ColorPaleta(new SolidColorBrush(Color.FromRgb(rojo, verde, azul)), cbx_ColorCambiar.SelectedIndex);
        }

        
    }
}
