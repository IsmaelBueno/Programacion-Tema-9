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
    /// Lógica de interacción para VentanaEjercicio3.xaml
    /// </summary>
    public partial class VentanaEjercicio3 : Window
    {
        static int numero;
        static int intentos = 0;

        public VentanaEjercicio3()
        {
            InitializeComponent();
        }

        private void btn_numero_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            numero = rnd.Next(1, 101);
            btn_probar.IsEnabled = true;
            chx.IsEnabled = true;
            btn_numero.IsEnabled = false;
        }

        private void chx_Checked(object sender, RoutedEventArgs e)
        {
            lbl_vernumero.Content = numero;
        }

        private void chx_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl_vernumero.Content = string.Empty;
        }

        private void btn_probar_Click(object sender, RoutedEventArgs e)
        {
            int posible_resultado;

            try
            {
                posible_resultado = int.Parse(txb_resultado.Text);

                if (posible_resultado<1 || posible_resultado > 100) //valor mínimo y máximo para adivinar
                {
                    lbl_resultado.Content = "El valor introducido no es correcto";
                }
                else if (posible_resultado > numero)
                {
                    intentos++;
                    lbl_resultado.Content = "El número buscado es menor";
                } else if(posible_resultado < numero)
                {
                    intentos++;
                    lbl_resultado.Content = "El número buscado es mayor";
                }
                else if (posible_resultado == numero)
                {
                    intentos++;
                    MessageBox.Show("Acertaste en " + intentos + " intentos");

                    //Al acertar se restablecen los valores por defecto
                    intentos = 0;
                    btn_numero.IsEnabled = true;
                    btn_probar.IsEnabled = false;
                    chx.IsEnabled = false;
                    chx.IsChecked = false;
                    lbl_vernumero.Content = string.Empty;
                    lbl_resultado.Content = string.Empty;                  
                }
                txb_resultado.Focus();

            }
            catch (Exception)
            {
                lbl_resultado.Content = "El valor introducido no es correcto";
            }
        }
    }
}
