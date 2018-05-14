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

namespace Ejercicio20
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool jugador = false; //false es el jugador1, true es el jugador2
        BitmapImage equis = new BitmapImage(new Uri("../../equis.png",UriKind.Relative));
        BitmapImage circulo = new BitmapImage(new Uri("../../circulo.png",UriKind.Relative));

        public MainWindow()
        {
            InitializeComponent();
            CrearTablero();
        }

        //Usuario
        private void evento_juegoNuevo(object sender, RoutedEventArgs e)
        {
            grd_tablero.Children.Clear();
            CrearTablero();
        }
        private void evento_click_imagen(object sender, MouseButtonEventArgs e)
        {
            ((Image)sender).Source = turnoJugador();
            ((Image)sender).MouseLeftButtonDown -= evento_click_imagen;
            if (ComprobarVictoria())
            {
                MessageBox.Show("Victoria!");
                grd_tablero.Children.Clear();
                CrearTablero();
            }
        }
        private void evento_salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Método de cambio de turno
        private BitmapImage turnoJugador()
        {
            BitmapImage tmpImage = new BitmapImage();

            if (!jugador)
            {
                tmpImage = equis;
                jugador = true;
                lbl_jugador.Content = "Jugador 2";
            }
            else
            {
                tmpImage = circulo;
                jugador = false;
                lbl_jugador.Content = "Jugador 1";
            }

            return tmpImage;
        }

        //Método crear tablero
        private void CrearTablero()
        {
            jugador = false;
            lbl_jugador.Content = "Jugador 1";
            

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Border tmpBorde = new Border();
                    tmpBorde.BorderBrush = Brushes.Black;
                    tmpBorde.BorderThickness = new Thickness(2);
                    tmpBorde.Background = Brushes.White;
                    Image tmpImage = new Image();
                    tmpImage.MouseLeftButtonDown += evento_click_imagen;
                    tmpImage.Source = new BitmapImage(new Uri("../../bugfixed.png",UriKind.Relative));

                    tmpBorde.Child = tmpImage;

                    grd_tablero.Children.Add(tmpBorde);

                    Grid.SetRow(tmpBorde, j);
                    Grid.SetColumn(tmpBorde, i);
                }
            }
        }

        //Comprobar si un jugador gano 
        private bool ComprobarVictoria()
        {
            Image[,] tmpMatriz = new Image[3, 3];
            int contador = 0;

            //Matriz con datos para comprobar
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tmpMatriz[i, j] = (Image)((Border)grd_tablero.Children[contador]).Child;
                    contador++;
                }
            }

            try
            {
                //Comprobar columnas
                for (int i = 0; i < 3; i++)
                {
                    if (tmpMatriz[i, 0].Source == tmpMatriz[i, 1].Source && tmpMatriz[i, 2].Source == tmpMatriz[i, 0].Source)
                        return true;
                }

                //Comprobar filas
                for (int i = 0; i < 3; i++)
                {
                    if (tmpMatriz[0, i].Source == tmpMatriz[1, i].Source && tmpMatriz[2, i].Source == tmpMatriz[0, i].Source)
                        return true;
                }

                //Comprobar diagonales
                if (tmpMatriz[0, 0].Source == tmpMatriz[1, 1].Source && tmpMatriz[0, 0].Source == tmpMatriz[2, 2].Source) return true;
                if (tmpMatriz[0, 2].Source == tmpMatriz[1, 1].Source && tmpMatriz[0, 2].Source == tmpMatriz[2, 0].Source) return true;
            }
            catch (Exception)
            {
                
            }
            
            return false;
        }
    }
}
