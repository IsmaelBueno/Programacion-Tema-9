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
    /// Lógica de interacción para VentanaEjercicio1.xaml
    /// </summary>
    public partial class VentanaEjercicio1 : Window
    {
        public VentanaEjercicio1()
        {
            InitializeComponent();
            tbx_numero.Focus();
        }
        private void btn_calcular_Click(object sender, RoutedEventArgs e)
        {
            double resultado = 0;
            int limite;

            try
            {
                limite = int.Parse(tbx_numero.Text);
                for (int i = 0; i <= limite; i++)
                {
                    resultado += i;
                }

                lbl_resultado.Content = resultado.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Valor incorrecto");
                tbx_numero.Focus();
                tbx_numero.Clear();
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
