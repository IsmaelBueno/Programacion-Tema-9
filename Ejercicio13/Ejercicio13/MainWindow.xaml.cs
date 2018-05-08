﻿using System;
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
//--------------------------------------
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;

namespace Ejercicio13
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int REAJUSTETAMANIORICHTEXTBOX = 90;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Reajustar el alto del richtextbox cuando cambia la ventana
        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            rtbx_editor.Height = e.NewSize.Height - REAJUSTETAMANIORICHTEXTBOX;
        }

        //Cuando se inicia el programa
        private void Window_Initialized_1(object sender, EventArgs e)
        {
            rtbx_editor.Focus();
        }


        #region BARRA HERRAMIENTAS
        private void evento_herramientas_negrita(object sender, MouseButtonEventArgs e)
        {
            TextRange textoSeleccionado = new TextRange(rtbx_editor.Selection.Start, rtbx_editor.Selection.End);

            try 
            {
                FontWeight grosorFuente = (FontWeight)textoSeleccionado.GetPropertyValue(FontWeightProperty);

                if (grosorFuente == FontWeights.Bold)
                {
                    textoSeleccionado.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
                }
                else
                {
                    textoSeleccionado.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
                }           		      
	        }
	        catch (Exception)
	        {
                textoSeleccionado.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
	        }
        }

        private void evento_herramientas_cursiva(object sender, MouseButtonEventArgs e)
        {
            TextRange rango = new TextRange(rtbx_editor.Selection.Start, rtbx_editor.Selection.End);

            try
            {
                FontStyle estiloFuente = (FontStyle)rango.GetPropertyValue(FontStyleProperty);

                if (estiloFuente == FontStyles.Oblique)
                {
                    rango.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
                }
                else
                {
                    rango.ApplyPropertyValue(FontStretchProperty, FontStyles.Oblique);
                }
            }
            catch (Exception)
            {
                rango.ApplyPropertyValue(FontStyleProperty, FontStyles.Oblique);
            }
    
        }

        private void evento_herramientas_color(object sender, MouseButtonEventArgs e)
        {
            Rectangle tmpRectangulo = (Rectangle)sender;

            TextRange rango = new TextRange(rtbx_editor.Selection.Start, rtbx_editor.Selection.End);
            rango.ApplyPropertyValue(ForegroundProperty, tmpRectangulo.Fill);
        }

        private void evento_herramientas_paletacolores(object sender, RoutedEventArgs e)
        {
            VtnPaletaColores vtn_colores = new VtnPaletaColores();
            vtn_colores.ColorPaleta += vtn_colores_ColorPaleta;
            vtn_colores.ShowDialog();
        }
        private void vtn_colores_ColorPaleta(SolidColorBrush color, int colorCambiar)
        {
            Rectangle tmpRectangulo = (Rectangle)grd_colores.Children[colorCambiar];
            tmpRectangulo.Fill = color;
            grd_colores.Children[colorCambiar] = tmpRectangulo;
        }

        private void evento_herramientas_tamanioLetra(object sender, TextChangedEventArgs e)
        {
            int valor = 0;

            try
            {
                if (int.TryParse(tbx_tamanioLetra.Text, out valor))
                {
                    rtbx_editor.FontSize = valor;
                }
            }
            catch (Exception)
            {
                //solucion provisional para que no de una excepción al arrancar el fontsize por null reference.
                //No influye en el funcionamiento para nada una vez arranca.
            }

        }
        private void evento_herramientas_tamanioLetra_reglaNumeros(object sender, TextCompositionEventArgs e)
        {
            string caracteresPermitidos = "[0-9]";
            Regex regla = new Regex(caracteresPermitidos);

            if (!regla.IsMatch(e.Text)) e.Handled = true;
        }

        private void evento_herramientas_fuente(object sender, RoutedEventArgs e)
        {
            ComboBoxItem tmp_ComboBoxItem = (ComboBoxItem)sender;
            string fuente = tmp_ComboBoxItem.Content.ToString();
            try
            {
                rtbx_editor.FontFamily = new FontFamily(fuente);
            }
            catch (Exception)
            {
              //Este catch esta provisional porque me da una especie de error raro, pero solo al arrancar haciendo esto lo cubro.
            }



        }
        #endregion

        #region MENU
        //ARCHIVO
        private void evento_menu_salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void evento_menu_guardar(object sender, RoutedEventArgs e)
        {
            SaveFileDialog ventanaGuardar = new SaveFileDialog();
            ventanaGuardar.InitialDirectory = @"C:\";
            ventanaGuardar.FileName = "NuevoDocumento";
            ventanaGuardar.DefaultExt = ".txt";
            ventanaGuardar.Filter = "Textos|*.txt|Todas las Extensiones|*.*";

            //Aquí recoje si se llego a pulsar guardar
            bool? opcion = ventanaGuardar.ShowDialog();
            if (opcion==true)
            {
                if (!GuardarArchivo(ventanaGuardar.FileName))
                {
                    MessageBox.Show("Error al intentar guardar el archivo");
                }
            }
        }
        private bool GuardarArchivo(string ruta)
        {
            try
            {
                FileStream fichero = new FileStream(ruta, FileMode.Create);
                using (StreamWriter escritor = new StreamWriter(fichero))
                {
                    rtbx_editor.SelectAll();
                    escritor.Write(rtbx_editor.Selection.Text);
                }
                fichero.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void evento_menu_abrir(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ventanaAbrir = new OpenFileDialog();
            ventanaAbrir.InitialDirectory = @"c:\"; //IMPORTANTE poner esta barra invertida, con la barra normal peta
            ventanaAbrir.FileName = "";
            ventanaAbrir.DefaultExt = ".txt";
            ventanaAbrir.Filter = "Textos|*.txt|Todas las Extensiones|*.*";

            Nullable<bool> resultado = ventanaAbrir.ShowDialog();

            if (resultado == true)
            {
                if (!LeerArchivo(ventanaAbrir.FileName))
                {
                    MessageBox.Show("Error al intentar abrir el archivo");
                }
            }
        }
        private bool LeerArchivo(string ruta)
        {
            try
            {
                FileStream fichero = new FileStream(ruta, FileMode.Open);
                using (StreamReader lector = new StreamReader(fichero))
                {
                    rtbx_editor.SelectAll();
                    rtbx_editor.Selection.Text = lector.ReadToEnd();
                }
                fichero.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
