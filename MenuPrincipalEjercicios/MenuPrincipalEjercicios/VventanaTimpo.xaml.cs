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
//----------------------------------------------
using System.Text.RegularExpressions;

namespace MenuPrincipalEjercicios
{


    /// <summary>
    /// Lógica de interacción para VventanaTimpo.xaml
    /// </summary>
    public partial class VventanaTimpo : Window
    {
        public delegate void Delegado(int tiempo);
        public event Delegado TiempoInicialCambiado;

        public VventanaTimpo()
        {
            InitializeComponent();
        }

        private void evento_tbx_ContenidoPrevio(object sender, TextCompositionEventArgs e)
        {
            Regex contenidoPermitido = new Regex("[0-9]");
            if (!contenidoPermitido.IsMatch(e.Text))
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
