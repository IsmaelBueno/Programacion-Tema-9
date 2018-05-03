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
//-----------------------------------------------
using System.Text.RegularExpressions;

namespace Ejercicio8
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region PALINDROMOS
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string textoInvertido = string.Empty;
            string texto = string.Empty;

            //Crea un texto que es igual al introducido sin espacios
            for (int i = 0; i < tbx_frase.Text.Length; i++)
			{
                if(tbx_frase.Text[i] != ' ')
                texto += tbx_frase.Text[i];
			}

            //Crea un texto invertido
            for (int i = texto.Length-1; i >= 0; i--)
            {
                textoInvertido += texto[i];
            }

            //Compara ambos textos sin tener en cuenta mayúsculas o minúsculas
            if (texto.ToLower() == textoInvertido.ToLower())
            {
                lbl_resultado.Foreground = Brushes.DarkOliveGreen;
                lbl_resultado.Content = "Es un palíndromo";
            }
            else
            {
                lbl_resultado.Foreground = Brushes.DarkRed;
                lbl_resultado.Content = "No es un palíndromo";
            }
        }

        //Regla para controlar que solo se introducen letras en el tetxbox
        private void tbx_frase_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string caracteresPermitidos = "[a-z]|ñ|[A-Z]|Ñ";
            Regex regla = new Regex(caracteresPermitidos);

            if(!regla.IsMatch(e.Text)) e.Handled = true;
        }

        //EVENTOS DE LOS COMBOITEM 
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion1.Content.ToString();
        }
        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion2.Content.ToString();
        }
        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion3.Content.ToString();
        }
        private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion4.Content.ToString();
        }
        private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion5.Content.ToString();
        }
        private void ComboBoxItem_Selected_6(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion6.Content.ToString();
        }
        private void ComboBoxItem_Selected_7(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion7.Content.ToString();
        }
        private void ComboBoxItem_Selected_8(object sender, RoutedEventArgs e)
        {
            tbx_frase.Text = cbi_opcion8.Content.ToString();
        }
#endregion

        #region NUMEROS PRIMOS
        private void tbx_numero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string caracteresPermitidos = "[0-9]";
            Regex regla = new Regex(caracteresPermitidos);

            if (!regla.IsMatch(e.Text)) e.Handled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string numeroString = string.Empty;
            int numero;
           
            //Quitar los espacios
            for (int i = 0; i < tbx_numero.Text.Length; i++)
            {
                if (tbx_numero.Text[i] != ' ') numeroString += tbx_numero.Text[i];
            }
            numero = int.Parse(numeroString);

            //Calcular los primos e ir añadinedolos al listbox
            lbx_listaPrimos.Items.Clear();

            for (int i = 2; i <= numero; i++)
            {
                for (int j = 2; j <= i; j++)
                {
                    if (i % j == 0 && i != j)
                    {
                        j = i + 1;
                    }
                    if (i == j)
                    {
                        ListBoxItem tmpListBoxItem = new ListBoxItem();
                        tmpListBoxItem.Content = i.ToString();
                        lbx_listaPrimos.Items.Add(tmpListBoxItem);
                    }
                }
            }
        }
        #endregion
    }
}
