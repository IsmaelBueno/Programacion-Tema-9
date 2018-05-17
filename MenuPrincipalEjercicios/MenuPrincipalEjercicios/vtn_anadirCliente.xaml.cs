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
    /// Lógica de interacción para vtn_anadirCliente.xaml
    /// </summary>
    public partial class vtn_anadirCliente : Window
    {
        public event Delegado EventoAnadirCliente;

        public vtn_anadirCliente()
        {
            InitializeComponent();
        }
        private void evento_anadirCliente(object sender, RoutedEventArgs e)
        {
            Cliente tmpCliente = new Cliente();


            if (ComprobarDni() && ComprobarNombre() && ComprobarApellidos() && ComprobarFechaNacimiento() && ComprobarSueldo())
            {

                tmpCliente.Dni = tbx_dni.Text;
                tmpCliente.Nombre = tbx_nombre.Text;
                tmpCliente.Apellidos = tbx_apellidos.Text;
                tmpCliente.FechaNacimiento = DateTime.Parse(tbx_fechaNacimiento.Text);
                tmpCliente.Sueldo = double.Parse(tbx_sueldo.Text);

                EventoAnadirCliente(tmpCliente);
                this.Close();
            }
            else
            {
                MessageBox.Show("Algunos campos no son correctos");
            }
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
