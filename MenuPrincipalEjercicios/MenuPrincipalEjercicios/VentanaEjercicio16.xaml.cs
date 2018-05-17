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
//----------------------------------
using Microsoft.Win32;
using System.IO;

namespace MenuPrincipalEjercicios
{    
    //delegados
    public delegate bool Delegado3(string dni, string nombre, string apellidos, string fechaNacimiento, string sueldo);
    public delegate bool Delegado2(string dni);
    public delegate void Delegado(Cliente c);

    /// <summary>
    /// Lógica de interacción para VentanaEjercicio16.xaml
    /// </summary>
    public partial class VentanaEjercicio16 : Window
    {
        //Clientes actuales
        List<Cliente> clientes = new List<Cliente>();

        public VentanaEjercicio16()
        {
            InitializeComponent();
        }

        //HERRAMIENTAS
        private void evento_herramientas_guardar(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Texto|*.txt";
            fichero.InitialDirectory = @"C\";
            fichero.FileName = "clientes.txt";

            bool? opcionElegida = fichero.ShowDialog();

            if (opcionElegida == true)
            {
                try
                {
                    using (FileStream flujo = new FileStream(fichero.FileName, FileMode.Create))
                    {
                        using (StreamWriter escritor = new StreamWriter(flujo))
                        {
                            for (int i = 0; i < clientes.Count; i++)
                            {
                                escritor.Write(clientes[i].ToString());
                                escritor.Write(Environment.NewLine);
                            }

                        }
                    }

                    lbl_ruta.Content = fichero.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar guardar el archivo");
                }
            }
        }
        private void evento_herramientas_cargar(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Texto|*.txt";
            fichero.InitialDirectory = @"C\";
            string contenido = string.Empty;

            bool? opcionElegida = fichero.ShowDialog();

            if (opcionElegida == true)
            {
                try
                {
                    using (StreamReader flujo = new StreamReader(fichero.FileName))
                    {
                        contenido = flujo.ReadToEnd();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el fichero seleccionado");
                }

                //Rellenar la lista con el nuevo contenido
                clientes.Clear();
                char[] separadores = {';','\n'};
                string[] valores = contenido.Split(separadores, StringSplitOptions.RemoveEmptyEntries);

                try 
	            {	        
		            for (int i = 0; i < valores.Length; i++)
                    {
                        Cliente tmpCliente = new Cliente();
                        tmpCliente.Dni = valores[i];
                        i++;
                        tmpCliente.Nombre = valores[i];
                        i++;
                        tmpCliente.Apellidos = valores[i];
                        i++;
                        tmpCliente.FechaNacimiento = DateTime.Parse(valores[i]);
                        i++;
                        tmpCliente.Sueldo = double.Parse(valores[i]);
                        clientes.Add(tmpCliente);
                    }

                    lbl_ruta.Content = fichero.FileName;
	            }
	            catch (Exception)
	            {
		            MessageBox.Show("Fichero corrupto");
	            }
            }
        }
        private void evento_herramientas_salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //BOTONES
        private void evento_botones_anadirCliente(object sender, RoutedEventArgs e)
        {
            vtn_anadirCliente anadirCliente = new vtn_anadirCliente();
            anadirCliente.EventoAnadirCliente += anadirCliente_EventoAnadirCliente;
            anadirCliente.ShowDialog();
        }
        void anadirCliente_EventoAnadirCliente(Cliente c)
        {
            clientes.Add(c);
        }
        private void evento_botones_borrarTodosClientes(object sender, RoutedEventArgs e)
        {
            MessageBoxImage imagen = MessageBoxImage.Warning;
            MessageBoxButton botones = MessageBoxButton.YesNo;
            string mensaje = "¿Estas seguro?";
            string titulo = "Advertencia";

            MessageBoxResult resultado = MessageBox.Show(mensaje,titulo,botones,imagen);

            if (resultado == MessageBoxResult.Yes)
            {
                clientes.Clear();
            }
        }
        private void evento_botones_listarClientes(object sender, RoutedEventArgs e)
        {
            vtn_ListarClientes ventanaListado = new vtn_ListarClientes();
            DataGrid panelLista = new DataGrid();

            panelLista.Margin = new Thickness(30);
            panelLista.ItemsSource = clientes;
            ventanaListado.Content = panelLista;

            ventanaListado.ShowDialog();
        }
        private void evento_botones_borrarCliente(object sender, RoutedEventArgs e)
        {
            vtn_borrarCliente ventanaBorrado = new vtn_borrarCliente();
            ventanaBorrado.BorradoDNI += ventanaBorrado_BorradoDNI;
            ventanaBorrado.ShowDialog();
        }
        bool ventanaBorrado_BorradoDNI(string dni)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Dni == dni)
                {
                    clientes.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        private void evento_botones_editarCliente(object sender, RoutedEventArgs e)
        {
            ventana_editarCliente ventanaEdicion = new ventana_editarCliente();
            ventanaEdicion.ClienteEditado += ventanaEdicion_ClienteEditado;

            ventanaEdicion.ShowDialog();
        }

        bool ventanaEdicion_ClienteEditado(string dni, string nombre, string apellidos, string fechaNacimiento, string sueldo)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Dni == dni)
                {
                    clientes[i].Nombre = nombre;
                    clientes[i].Apellidos = apellidos;
                    clientes[i].FechaNacimiento = DateTime.Parse(fechaNacimiento);
                    clientes[i].Sueldo = double.Parse(sueldo);
                    return true;
                }
            }
            return false;
        }

 
    }
}
