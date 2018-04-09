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

namespace Ejercicio5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int desplazamiento = 3; //Se inicia en 3 por defecto

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_encriptar_Click(object sender, RoutedEventArgs e)
        {
            string fraseEncriptada = string.Empty;
            string fraseDesencriptada = string.Empty;

            for (int i = 0; i < tbx_frase.Text.Length; i++)
            {
                fraseEncriptada += (char)(tbx_frase.Text[i] + desplazamiento);
            }

            for (int i = 0; i < fraseEncriptada.Length; i++)
            {
                fraseDesencriptada += (char)(fraseEncriptada[i] - desplazamiento);
            }

            lbl_original.Content = tbx_frase.Text;
            lbl_encriptada.Content = fraseEncriptada;
            lbl_desencriptada.Content = fraseDesencriptada;
        }

        private void slb_desplazamiento_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue > e.OldValue)
            {
                desplazamiento--;
                tbx_desplazamiento.Text = desplazamiento.ToString();
            }
            else
            {
                desplazamiento++;
                tbx_desplazamiento.Text = desplazamiento.ToString();
            }
        }
    }
}
