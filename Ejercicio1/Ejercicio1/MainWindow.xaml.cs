using System;
using System.Windows;
using System.Windows.Controls;

namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void tbx_numero_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
