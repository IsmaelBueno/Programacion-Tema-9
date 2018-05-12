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
//using
using System.Text.RegularExpressions;

namespace Ejercicio27
{
    /// <summary>
    /// Lógica de interacción para VentanaTimpo.xaml
    /// </summary>
    public partial class VentanaTimpo : Window
    {
        public event Delegado TiempoInicialCambiado;

        public VentanaTimpo()
        {
            InitializeComponent();
        }

        private void evento_tbx_ContenidoPrevio(object sender, TextCompositionEventArgs e)
        {
            Regex contenidoPermitido = new Regex("[0-9]");
            if(!contenidoPermitido.IsMatch(e.Text))
                e.Handled = true;
        }

        private void evento_boton_Aplicar(object sender, RoutedEventArgs e)
        {
            try
            {
                int tiempo = int.Parse(tbx_tiempo.Text);
                TiempoInicialCambiado(tiempo);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado");
            }
        }
    }
}
