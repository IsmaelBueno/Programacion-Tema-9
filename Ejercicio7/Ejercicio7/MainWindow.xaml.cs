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
//-------------------------------
using System.Windows.Threading;

namespace Ejercicio7
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer reloj = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void evento_iniciarPrograma(object sender, EventArgs e)
        {
            lbl_fechaLarga.Content = DateTime.Now.ToLongDateString();
            lbl_reloj.Content = DateTime.Now.ToLongTimeString();
            reloj.Interval = new TimeSpan(0, 0, 1);
            reloj.Tick += reloj_Tick;
            reloj.IsEnabled = true;
        }
        void reloj_Tick(object sender, EventArgs e)
        {
            lbl_reloj.Content = DateTime.Now.ToLongTimeString();
            lbl_fechaLarga.Content = DateTime.Now.ToLongDateString();
        }

        //Usuario
        private void evento_btn_paro(object sender, RoutedEventArgs e)
        {
            reloj.IsEnabled = false;
            btn_marcha.IsEnabled = true;
            btn_paro.IsEnabled = false;
        }
        private void evento_btn_marcha(object sender, RoutedEventArgs e)
        {
            reloj.IsEnabled = true;
            btn_paro.IsEnabled = true;
            btn_marcha.IsEnabled = false;
        }
        private void evento_btn_salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }






    }
}
