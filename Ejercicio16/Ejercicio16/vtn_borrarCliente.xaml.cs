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

namespace Ejercicio16
{

    /// <summary>
    /// Lógica de interacción para vtn_borrarCliente.xaml
    /// </summary>
    public partial class vtn_borrarCliente : Window
    {

        public event Delegado2 BorradoDNI;

        public vtn_borrarCliente()
        {
            InitializeComponent();
        }

        private void evento_btn_borrar(object sender, RoutedEventArgs e)
        {
            if (tbx_dniBorrar.Text.Length != 9)
            {
                MessageBox.Show("El dni introducido debe ser de nueve caracteres");
            }
            else
            {
                if (!BorradoDNI(tbx_dniBorrar.Text))
                    MessageBox.Show("El dni introducido no existe entre los clientes");
                else
                    this.Close();

            }
        }
    }
}
