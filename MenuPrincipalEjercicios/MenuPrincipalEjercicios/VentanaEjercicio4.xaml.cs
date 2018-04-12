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
    /// Lógica de interacción para VentanaEjercicio4.xaml
    /// </summary>
    public partial class VentanaEjercicio4 : Window
    {
        public VentanaEjercicio4()
        {
            InitializeComponent();
            tbx_n1.Focus();
        }

        private void btn_sumar_Click(object sender, RoutedEventArgs e)
        {
            double resultado = 0;

            try
            {
                int n1 = int.Parse(tbx_n1.Text);
                int n2 = int.Parse(tbx_n2.Text);

                if (n1 > n2)
                {
                    lbl_resultado.Content = "Imposible calcular la operación";
                    return;
                }

                for (int i = n1; i <= n2; i++)
                {
                    resultado += i;
                }

                lbl_resultado.Content = string.Format("La suma desde {0} hasta {1} es: {2}",n1,n2,resultado);
            }
            catch (Exception)
            {
                lbl_resultado.Content = "Imposible calcular la operación";
            }
            finally
            {
                tbx_n1.Focus();
            }
        }

    }
}
