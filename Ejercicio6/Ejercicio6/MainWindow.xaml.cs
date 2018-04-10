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
//------------------------------------------------
using System.Text.RegularExpressions;

namespace Ejercicio6
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Regex regla = new Regex("[0-9]");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calcular_Click(object sender, RoutedEventArgs e)
        {
            tbx_m3_00.Text = (int.Parse(tbx_m1_1.Text) * int.Parse(tbx_m2_1.Text)).ToString();
            tbx_m3_01.Text = (int.Parse(tbx_m1_1.Text) * int.Parse(tbx_m2_2.Text)).ToString();
            tbx_m3_02.Text = (int.Parse(tbx_m1_1.Text) * int.Parse(tbx_m2_3.Text)).ToString();

            tbx_m3_10.Text = (int.Parse(tbx_m1_2.Text) * int.Parse(tbx_m2_1.Text)).ToString();
            tbx_m3_11.Text = (int.Parse(tbx_m1_2.Text) * int.Parse(tbx_m2_2.Text)).ToString();
            tbx_m3_12.Text = (int.Parse(tbx_m1_2.Text) * int.Parse(tbx_m2_3.Text)).ToString();

            tbx_m3_20.Text = (int.Parse(tbx_m1_3.Text) * int.Parse(tbx_m2_1.Text)).ToString();
            tbx_m3_21.Text = (int.Parse(tbx_m1_3.Text) * int.Parse(tbx_m2_2.Text)).ToString();
            tbx_m3_22.Text = (int.Parse(tbx_m1_3.Text) * int.Parse(tbx_m2_3.Text)).ToString();
        }

        private void tbx_m3_00_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!regla.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
    }
}
