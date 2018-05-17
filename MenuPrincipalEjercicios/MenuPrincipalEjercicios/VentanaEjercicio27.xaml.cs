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
//-------------------------------------
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace MenuPrincipalEjercicios
{
    /// <summary>
    /// Lógica de interacción para VentanaEjercicio27.xaml
    /// </summary>
    public partial class VentanaEjercicio27 : Window
    {
        //establecer sudoku
        string rutaSudokus = @"../../sudokus.txt";
        string rutaSoluciones = @"../../soluciones.txt";
        Random rnd = new Random();
        Sudoku sudokuActual;

        //temporizador
        int tiempoRestante;
        int tiempoInicial = 600;
        DispatcherTimer contadorTiempo = new DispatcherTimer();

        public VentanaEjercicio27()
        {
            InitializeComponent();
            contadorTiempo.Interval = new TimeSpan(0, 0, 1);
            contadorTiempo.Tick += contadorTiempo_Tick;
        }

        //Usuario
        private void evento_menu_JuegoNuevo(object sender, RoutedEventArgs e)
        {
            CrearSudoku();
            RellenarCasillas();
            PrepararTiempo();
        }
        private void evento_menu_Reiniciar(object sender, RoutedEventArgs e)
        {
            if (sudokuActual != null)
            {
                RellenarCasillas();
                PrepararTiempo();
            }
        }
        private void evento_menu_Configuracion(object sender, RoutedEventArgs e)
        {
            VventanaTimpo configuracion = new VventanaTimpo();
            configuracion.TiempoInicialCambiado += configuracion_TiempoInicialCambiado;
            configuracion.ShowDialog();
        }
        private void evento_menu_Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void evento_boton_Comprobar(object sender, RoutedEventArgs e)
        {
            if (sudokuActual != null)
            {
                if (!ComprobarSudoku())
                    MessageBox.Show("La solución es incorrecta");
                else
                {
                    contadorTiempo.IsEnabled = false;
                    MessageBox.Show("¡Sudoku completado!");
                    grd_contenido.Children.Clear();
                    sudokuActual = null;

                }
            }
        }


        //METODOS Y EVENTOS
        private void CrearSudoku()
        {
            sudokuActual = new Sudoku(rutaSudokus, rutaSoluciones, rnd.Next(0, 2));
        }
        private void RellenarCasillas()
        {
            //limpia el contenido del grid anterior
            grd_contenido.Children.Clear();

            for (int i = 0; i < Sudoku.TAMANIODIMENSIONES1; i++)
            {
                for (int j = 0; j < Sudoku.TAMANIODIMENSIONES1; j++)
                {
                    //definición del textbox con sus propiedades y evento, el bucle lo coloca en su casilla correspondiente
                    TextBox tmpTextBox = new TextBox();
                    Grid.SetColumn(tmpTextBox, j);
                    Grid.SetRow(tmpTextBox, i);
                    tmpTextBox.BorderBrush = Brushes.Black;
                    tmpTextBox.MaxLength = 1;
                    tmpTextBox.FontSize = 30D;
                    tmpTextBox.PreviewTextInput += evento_textbox_ComprobarCaracter;
                    tmpTextBox.Foreground = Brushes.Blue;


                    //Bordes
                    int bordetop = 1;
                    int bordebot = 1;
                    int bordeizq = 1;
                    int bordeder = 1;

                    if (i == 0 || i == 3 || i == 6)
                        bordetop = 3;
                    if (i == 8)
                        bordebot = 3;
                    if (j == 0 || j == 3 || j == 6)
                        bordeizq = 3;
                    if (j == 8)
                        bordeder = 3;
                    tmpTextBox.BorderThickness = new Thickness(bordeizq, bordetop, bordeder, bordebot);

                    //si el valor del sudoku en la casila no es 0, lo introducirá en el .text del textbox temporal y lo deshabilita para que no se pueda editar.
                    if (sudokuActual.Sudoku1[i, j] != '0')
                    {
                        tmpTextBox.Text = sudokuActual.Sudoku1[i, j].ToString();
                        tmpTextBox.IsReadOnly = true;
                        tmpTextBox.Foreground = Brushes.Black;
                    }

                    //por ultimo añade este texbox temporal a children del grid_contenido
                    grd_contenido.Children.Add(tmpTextBox);
                }
            }
        }
        private void evento_textbox_ComprobarCaracter(object sender, TextCompositionEventArgs e)
        {
            Regex patron = new Regex("[1-9]");
            if (!patron.IsMatch(e.Text))
                e.Handled = true;
        }
        private void contadorTiempo_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;
            if (tiempoRestante < 0)
            {
                MessageBox.Show("Tiempo agotado");
                contadorTiempo.IsEnabled = false;
                grd_contenido.Children.Clear();
                sudokuActual = null;
            }
            else
            {
                lbl_tiempo.Content = tiempoRestante;
            }
        }
        private void PrepararTiempo()
        {
            contadorTiempo.IsEnabled = false;
            tiempoRestante = tiempoInicial;
            contadorTiempo.IsEnabled = true;
        }
        private bool ComprobarSudoku()
        {
            int contador = 0;
            TextBox tmpTextBox;
            for (int i = 0; i < Sudoku.TAMANIODIMENSIONES1; i++)
            {
                for (int j = 0; j < Sudoku.TAMANIODIMENSIONES1; j++)
                {
                    tmpTextBox = (TextBox)grd_contenido.Children[contador];
                    contador++;

                    if (tmpTextBox.Text != sudokuActual.Solucion[i, j].ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        void configuracion_TiempoInicialCambiado(int tiempo)
        {
            tiempoInicial = tiempo;
        }

    }
}