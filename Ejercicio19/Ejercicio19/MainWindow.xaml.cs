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

namespace Ejercicio19
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int MAXIMOFILAS = 20;
        const int MAXIMOCOLUMNAS = 20;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void evento_IniciarPrograma(object sender, EventArgs e)
        {
            //bucle de filas
            for (int i = 1; i <= MAXIMOFILAS; i++)
			{
                ComboBoxItem tmpComboBoxItem = new ComboBoxItem();
                tmpComboBoxItem.Content = i;
                cbx_filas.Items.Add(tmpComboBoxItem);
			}

            //bucle de columnas
            for (int i = 1; i <= MAXIMOCOLUMNAS; i++)
            {
                ComboBoxItem tmpComboBoxItem = new ComboBoxItem();
                tmpComboBoxItem.Content = i;
                cbx_columnas.Items.Add(tmpComboBoxItem);
            }
        }

        private void evento_boton_CreacionMatriz(object sender, RoutedEventArgs e)
        {
            try
            {
                grd_matriz.Children.Clear();
                grd_matriz.RowDefinitions.Clear();
                grd_matriz.ColumnDefinitions.Clear();

                ComboBoxItem tmpComboBoxItemFilas = (ComboBoxItem)cbx_filas.Items[cbx_filas.SelectedIndex];
                ComboBoxItem tmpComboBoxItemColumnas = (ComboBoxItem)cbx_columnas.Items[cbx_columnas.SelectedIndex];
                int filas = int.Parse(tmpComboBoxItemFilas.Content.ToString());
                int columnas = int.Parse(tmpComboBoxItemColumnas.Content.ToString());

                //Crea las columnas y filas del grd
                for (int i = 0; i < filas; i++)
                {
                    RowDefinition tmpRow = new RowDefinition();
                    grd_matriz.RowDefinitions.Add(tmpRow);
                }

                for (int i = 0; i < columnas; i++)
                {
                    ColumnDefinition tmpColumn = new ColumnDefinition();
                    grd_matriz.ColumnDefinitions.Add(tmpColumn);
                }


                //Ahora relleno los elemetos del grid con los botones
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        Button tmpButton = new Button();
                        tmpButton.Content = string.Format("[{0},{1}]",i,j);
                        tmpButton.FontSize = 18D;
                        tmpButton.FontWeight = FontWeights.Bold;
                        tmpButton.Margin = new Thickness(3);

                        grd_matriz.Children.Add(tmpButton);

                        Grid.SetRow(tmpButton, i);
                        Grid.SetColumn(tmpButton, j);
                    }
                }

                ReajustarAlto(filas);
                ReajustarAncho(columnas);
            }
            catch (Exception)
            {
                MessageBox.Show("Valor incorrecto");
            }

        }

        private void ReajustarAlto(int filas)
        {
            this.Height = MinHeight + (filas * 36);
        }

        private void ReajustarAncho(int columnas)
        {
            if (columnas > 10)
            {
                this.Width = MinWidth + ((columnas - 10) * 75);
            }
            else
            {
                this.Width = MinWidth;
            }
        }
    }
}
