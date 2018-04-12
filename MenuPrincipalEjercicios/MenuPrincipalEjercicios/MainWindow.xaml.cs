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
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Ejercicio 1
        private void Ejercicio1_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Calcula la suma de los \"N\" primeros números.";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VentanaEjercicio1 v = new VentanaEjercicio1();
            v.Show();
        }
        #endregion

        #region Ejercicio 2
        private void Ejercicio2_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Permite evaluar una expresión matemática simple con los operadores: \"+\" , \"-\" , \"*\" , \"/\".\nNO tiene en cuenta la prioridad de operadores, solo el orden.";
            /*Haz un programa que use una clase que permita evaluar una expresión matemática simple con las operaciones; +,
-, *, / (sumar, restar, multiplicar y dividir) y muestre el resultado*/
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            VentanaEjercicio2 v = new VentanaEjercicio2();
            v.Show();
        }
        #endregion

        #region Ejercicio 3
        private void Ejercicio3_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Adivina en el menor número de intentos posibles un número generado aleatoriamente entre 1 y 100.";
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            VentanaEjercicio3 v = new VentanaEjercicio3();
            v.Show();
        }
        #endregion

        #region Ejercicio 4
        private void Ejercicio4_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Calcula la suma total de los números que hay entre un número inicial y otro final.";
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            VentanaEjercicio4 v = new VentanaEjercicio4();
            v.Show();
        }
        #endregion

        #region Ejercicio 5
        private void Ejercicio5_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Puedes introducir una frase y un valor de desplazamiento para encriptar (De 0 a 9), basándose en este valor encriptará la frase y también hará el proceso inverso para desencriptarla.";
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            VentanaEjercicio5 v = new VentanaEjercicio5();
            v.Show();
        }
        #endregion

        #region Ejercicio 6
        private void Ejercicio6_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 7
        private void Ejercicio7_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 8
        private void Ejercicio8_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 9
        private void Ejercicio9_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Simulador de tiradas de dados, muestra los resultados y los porcentajes de cada número.";
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            VentanaEjercicio9 v = new VentanaEjercicio9();
            v.Show();
        }
        #endregion

        #region Ejercicio 10
        private void Ejercicio10_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 11
        private void Ejercicio11_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 12
        private void Ejercicio12_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 13
        private void Ejercicio13_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 14
        private void Ejercicio14_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 15
        private void Ejercicio15_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_15(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 16
        private void Ejercicio16_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 17
        private void Ejercicio17_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 18
        private void Ejercicio18_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_18(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 19
        private void Ejercicio19_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_19(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 20
        private void Ejercicio20_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_20(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 21
        private void Ejercicio21_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_21(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 22
        private void Ejercicio22_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_22(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 23
        private void Ejercicio23_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_23(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 24
        private void Ejercicio24_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_24(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 25
        private void Ejercicio25_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_25(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 26
        private void Ejercicio26_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_26(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Ejercicio 27
        private void Ejercicio27_MouseEnter(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = "Estamos trabajando en ello";
        }
        private void Button_Click_27(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void Ejercicios_MouseLeave(object sender, MouseEventArgs e)
        {
            tbk_informacionejercicio.Text = string.Empty;
        }

        private void Hyperlink_RequestNavigate_1(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            //e.Handled = true;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AcercaDe v = new AcercaDe();
            v.ShowDialog();
        }


    }
}
