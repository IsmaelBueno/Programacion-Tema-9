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

namespace Ejercicio2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbx_expresion.Focus();
        }

        private void btn_calcular_Click(object sender, RoutedEventArgs e)
        {
            double resultado = 0D;

            string[] numeros;
            string [] operadores;
            string tmp_numero = string.Empty;
            int j = 0; //segundo contador para el bucle

            try
            {
                numeros = tbx_expresion.Text.Split(new char[] { '+', '-', '*', '/' },StringSplitOptions.RemoveEmptyEntries);
                operadores = tbx_expresion.Text.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' },StringSplitOptions.RemoveEmptyEntries);

                resultado = int.Parse(numeros[0]); //Preparacion del primer número

                for (int i = 1; i < numeros.Length; i++)
                {
                    tmp_numero = numeros[i];

                    switch (operadores[j])
                    {
                        case "+":
                            resultado += int.Parse(tmp_numero);
                            break;
                        case "-":
                            resultado -= int.Parse(tmp_numero);
                            break;
                        case "*":
                            resultado *= int.Parse(tmp_numero);
                            break;
                        case "/":
                            resultado /= int.Parse(tmp_numero);
                            break;
                        default:
                            lbl_resultado.Content = "Expresión no válida";
                            return;
                    }
                    j++;
                }
                lbl_resultado.Content = resultado.ToString();
                tbx_expresion.Focus();
            }
            catch (Exception)
            {
                lbl_resultado.Content = "Expresión no válida";
                tbx_expresion.Focus();
            }
        }
    }
}
