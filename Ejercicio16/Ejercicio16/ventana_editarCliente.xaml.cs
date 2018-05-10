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
    /// Lógica de interacción para ventana_editarCliente.xaml
    /// </summary>
    public partial class ventana_editarCliente : Window
    {
        public event Delegado3 ClienteEditado;

        public ventana_editarCliente()
        {
            InitializeComponent();
        }

        private void evento_editarDni(object sender, RoutedEventArgs e)
        {
            if (ComprobarDni() && ComprobarNombre() && ComprobarApellidos() && ComprobarFechaNacimiento() && ComprobarSueldo())
            {
                if (ClienteEditado(tbx_dni.Text,tbx_nombre.Text,tbx_apellidos.Text,tbx_fechaNacimiento.Text,tbx_sueldo.Text))
                {
                    this.Close();
                }
                else MessageBox.Show("Este dni no se encuentra entre los clientes actuales");
            }
            else MessageBox.Show("El formato de algún campo es incorrecto");
        }

        //METODOS PARA COMPROBAR DATOS
        private bool ComprobarDni()
        {
            if (tbx_dni.Text.Length != 9)
                return false;
            else
                return true;
        }
        private bool ComprobarNombre()
        {
            if (tbx_nombre.Text.Length < 1)
                return false;
            else return true;
        }
        private bool ComprobarApellidos()
        {
            if (tbx_apellidos.Text.Length < 1)
                return false;
            else return true;
        }
        private bool ComprobarFechaNacimiento()
        {
            DateTime tmp;
            if (!DateTime.TryParse(tbx_fechaNacimiento.Text, out tmp))
                return false;
            else
                return true;
        }
        private bool ComprobarSueldo()
        {
            double tmp;
            if (double.TryParse(tbx_sueldo.Text, out tmp))
            {
                if (tmp < 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
    }
}
