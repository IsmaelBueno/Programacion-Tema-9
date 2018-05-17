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
//---------------------------------------
using System.Diagnostics;

namespace MenuPrincipalEjercicios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int NFILAS = 3;
        const int NCOLUMNAS = 9;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Evento que carga el grid de botones al inicar el programa
        private void evento_inicializarPrograma(object sender, EventArgs e)
        {
            //Definición de filas
            for (int i = 0; i < NFILAS; i++)
            {
                grd_panelEjercicios.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < NCOLUMNAS; i++)
            {
                grd_panelEjercicios.ColumnDefinitions.Add(new ColumnDefinition());
            }

            //Definición de los botones

            int numeroEjercicio = 1;
            for (int i = 0; i < NFILAS; i++)
            {
                for (int j = 0; j < NCOLUMNAS; j++)
                {
                    //Definición de cada botón
                    Button tmpBoton = new Button();
                    tmpBoton.Content = string.Format("Ejercicio {0}",numeroEjercicio);
                    numeroEjercicio++;
                    tmpBoton.FontWeight = FontWeights.Bold;
                    tmpBoton.FontFamily = new FontFamily("Consolas");
                    tmpBoton.MouseEnter+=evento_ratonEntrandoEjercicios;
                    tmpBoton.MouseLeave+=evento_ratonSaliendoEjercicios;
                    tmpBoton.Click+=evento_clickEjercicios;

                    grd_panelEjercicios.Children.Add(tmpBoton);

                    Grid.SetColumn(tmpBoton,j);
                    Grid.SetRow(tmpBoton,i);
                }
            }
        }

        //BOTONES
        void evento_clickEjercicios(object sender, RoutedEventArgs e)
        {
 	        string nombreBoton = ((Button)sender).Content.ToString();
            switch (nombreBoton)
            {
                case "Ejercicio 1":
                        VentanaEjercicio1 v = new VentanaEjercicio1();
                        v.ShowDialog();
                    break;
                case "Ejercicio 2":
                        VentanaEjercicio2 v2 = new VentanaEjercicio2();
                        v2.ShowDialog();
                    break;
                case "Ejercicio 3":
                        VentanaEjercicio3 v3 = new VentanaEjercicio3();
                        v3.ShowDialog();
                    break;
                case "Ejercicio 4":
                        VentanaEjercicio4 v4 = new VentanaEjercicio4();
                        v4.ShowDialog();
                    break;
                case "Ejercicio 5":
                        VentanaEjercicio5 v5 = new VentanaEjercicio5();
                        v5.ShowDialog();
                    break;
                case "Ejercicio 6":
                        VentanaEjercicio6 v6 = new VentanaEjercicio6();
                        v6.ShowDialog();
                    break;
                case "Ejercicio 7":
                    VentanaEjercicio7 v7 = new VentanaEjercicio7();
                    v7.ShowDialog();
                    break;
                case "Ejercicio 8":
                    VentanaEjercicio8 v8 = new VentanaEjercicio8();
                    v8.ShowDialog();
                    break;
                case "Ejercicio 9":
                        VentanaEjercicio9 v9 = new VentanaEjercicio9();
                        v9.ShowDialog();
                    break;
                case "Ejercicio 12":
                    VentanaEjercicio12 v12 = new VentanaEjercicio12();
                    v12.ShowDialog();
                    break;
                case "Ejercicio 13":
                    VentanaEjercicio13 v13 = new VentanaEjercicio13();
                    v13.ShowDialog();
                    break;
                case "Ejercicio 14":
                    VentanaEjercicio14 v14 = new VentanaEjercicio14();
                    v14.ShowDialog();
                    break;
                case "Ejercicio 16":
                    VentanaEjercicio16 v16 = new VentanaEjercicio16();
                    v16.ShowDialog();
                    break;
                case "Ejercicio 18":
                    VentanaEjercicio18 v18 = new VentanaEjercicio18();
                    v18.ShowDialog();
                    break;
                case "Ejercicio 20":
                    VentanaEjercicio20 v20 = new VentanaEjercicio20();
                    v20.ShowDialog();
                    break;
                case "Ejercicio 27":
                    VentanaEjercicio27 v27 = new VentanaEjercicio27();
                    v27.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        void evento_ratonSaliendoEjercicios(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = string.Empty;
        }
        void evento_ratonEntrandoEjercicios(object sender, MouseEventArgs e)
        {
            string nombreBoton = ((Button)sender).Content.ToString();
            switch (nombreBoton)
            {
                case "Ejercicio 1":
                    tbk_informacionejercicio.Text = "Calcula la suma de los \"N\" primeros números.";
                    break;
                case "Ejercicio 2":
                    tbk_informacionejercicio.Text = "Permite evaluar una expresión matemática simple con los operadores: \"+\" , \"-\" , \"*\" , \"/\".\nNO tiene en cuenta la prioridad de operadores, solo el orden.";
                    break;
                case "Ejercicio 3":
                    tbk_informacionejercicio.Text = "Adivina en el menor número de intentos posibles un número generado aleatoriamente entre 1 y 100.";
                    break;
                case "Ejercicio 4":
                    tbk_informacionejercicio.Text = "Calcula la suma total de los números que hay entre un número inicial y otro final.";
                    break;
                case "Ejercicio 5":
                    tbk_informacionejercicio.Text = "Puedes introducir una frase y un valor de desplazamiento para encriptar (De 0 a 9), basándose en este valor encriptará la frase y también hará el proceso inverso para desencriptarla.";
                    break;
                case "Ejercicio 6":
                    tbk_informacionejercicio.Text = "Reloj digital que se puede parar y reanudar";
                    break;
                case "Ejercicio 7":
                    tbk_informacionejercicio.Text = "Multipliación de una matriz 3x1 por otra 1x3";
                    break;
                case "Ejercicio 8":
                    tbk_informacionejercicio.Text = "Programa con dos pestañas, la primera comprueba si una frase es palíndroma, la segunda muestra todos los números primos menores al número introducido";
                    break;
                case "Ejercicio 9":
                    tbk_informacionejercicio.Text = "Simulador de tiradas de dados, muestra los resultados y los porcentajes de cada número.";
                    break;
                case "Ejercicio 12":
                    tbk_informacionejercicio.Text = "Programa que muestra de forma visual una combinación de colores.";
                    break;
                case "Ejercicio 13":
                    tbk_informacionejercicio.Text = "Editor de texto con formato RTF, permite manipular archivos, guardarlos y cargarlos.";
                    break;
                case "Ejercicio 14":
                    tbk_informacionejercicio.Text = "Programa que muestra algunas características de un archivo seleccionado.";
                    break;
                case "Ejercicio 16":
                    tbk_informacionejercicio.Text = "Programa que gestiona un fichero binario con datos personales de clientes";
                    break;
                case "Ejercicio 18":
                    tbk_informacionejercicio.Text = "Programa que simula el uso de dos jarras y su contenido, podremos llenarlas, vaciarlas y volcarlas sobre la otra jarra.";
                    break;
                case "Ejercicio 20":
                    tbk_informacionejercicio.Text = "Tres en raya para dos jugadores.";
                    break;
                case "Ejercicio 27":
                    tbk_informacionejercicio.Text = "Sudoku.";
                    break;
                default:
                    tbk_informacionejercicio.Text = "Estamos trabajando en ello";
                    break;
            }
        }

        //MENU
        private void evento_clickMenuGitHub(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
        }
        private void evento_clickMenuAcercaDe(object sender, RoutedEventArgs e)
        {
            AcercaDe v = new AcercaDe();
            v.ShowDialog();
        }

    }
}
