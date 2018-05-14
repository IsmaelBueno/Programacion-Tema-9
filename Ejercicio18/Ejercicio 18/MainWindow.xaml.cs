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
//--------------------------------------
using System.Text.RegularExpressions;

namespace Ejercicio_18
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Jarra jarraA;
        Jarra jarraB;
        bool jarrasdefinidas = false;

        public MainWindow()
        {
            InitializeComponent();
            prb_barraprogresoA.SmallChange = 1;

        }

        private void evento_controlarContenidoTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regla = new Regex("[0-9]");
            if (!regla.IsMatch(e.Text))
                e.Handled = true;
        }
        void jarraB_CambioContenido(int contenido)
        {
            prb_barraprogresoB.Value = contenido;
        }
        void jarraA_CambioContenido(int contenido)
        {
            prb_barraprogresoA.Value = contenido;
        }

        //Usuario 
        private void evento_CrearJarras(object sender, RoutedEventArgs e)
        {
            int jarraAcapacidad;
            int jarraBcapacidad;

            if (int.TryParse(tbx_jarraA.Text, out jarraAcapacidad) && int.TryParse(tbx_jarraB.Text, out jarraBcapacidad))
            {
                if (!jarrasdefinidas)
                {
                    jarrasdefinidas = true;
                    btn_llenarA.IsEnabled = true;
                    btn_llenarB.IsEnabled = true;
                    btn_vaciarA.IsEnabled = true;
                    btn_vaciarB.IsEnabled = true;
                    btn_llenarenA.IsEnabled = true;
                    btn_llenarenB.IsEnabled = true;
                    prb_barraprogresoA.IsEnabled = true;
                    prb_barraprogresoB.IsEnabled = true;
                    btn_finalizar.IsEnabled = true;
                }

                //Cración de las jarras y ajuste de su chargebar
                jarraA = new Jarra(jarraAcapacidad);
                prb_barraprogresoA.Maximum = jarraAcapacidad;
                jarraA.CambioContenido += jarraA_CambioContenido;
                prb_barraprogresoA.Value = 0;

                jarraB = new Jarra(jarraBcapacidad);
                prb_barraprogresoB.Maximum = jarraBcapacidad;
                jarraB.CambioContenido += jarraB_CambioContenido;
                prb_barraprogresoB.Value = 0;

                lbx_acciones.Items.Clear();
            }
            else
                MessageBox.Show("Valores incorrectos");
        }

        private void evento_LlenarJarraA(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = new ListBoxItem();
            if (jarraA.Llenar())
                tmp.Content = "Se lleno la jarra A.";
            else tmp.Content = "La jarra A ya se encuentra llena.";
               lbx_acciones.Items.Add(tmp);
        }
        private void evento_LlenarJarraB(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = new ListBoxItem();
            if (jarraB.Llenar())
                tmp.Content = "Se lleno la jarra B.";
            else tmp.Content = "La jarra B ya se encuentra llena.";
            lbx_acciones.Items.Add(tmp);
        }

        private void evento_VaciarJarraA(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = new ListBoxItem();
            if (jarraA.Vaciar())
                tmp.Content = "Se vació la jarra A.";
            else tmp.Content = "La jarra A ya se encuentra vacía.";
            lbx_acciones.Items.Add(tmp);
        }
        private void evento_VaciarJarraB(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = new ListBoxItem();
            if (jarraB.Vaciar())
                tmp.Content = "Se vació la jarra B.";
            else tmp.Content = "La jarra B ya se encuentra vacía.";
            lbx_acciones.Items.Add(tmp);
        }

        private void evento_LlenarAconB(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = new ListBoxItem();
            if (jarraA.LLenarDesde(jarraB))
                tmp.Content = "Se vuelca la jarra B sobre la jarra A";
            else tmp.Content = "La jarra A se encuentra llena o la jarra B vacía";
            lbx_acciones.Items.Add(tmp);
        }
        private void evento_LlenarBconA(object sender, RoutedEventArgs e)
        {
            ListBoxItem tmp = new ListBoxItem();
            if (jarraB.LLenarDesde(jarraA))
                tmp.Content = "Se vuelca la jarra A sobre la jarra B";
            else tmp.Content = "La jarra B se encuentra llena o la jarra A vacía";
            lbx_acciones.Items.Add(tmp);
        }

        private void evento_finalizar(object sender, RoutedEventArgs e)
        {
            jarrasdefinidas = false;

            btn_llenarA.IsEnabled = true;
            btn_llenarB.IsEnabled = false;
            btn_vaciarA.IsEnabled = false;
            btn_vaciarB.IsEnabled = false;
            btn_llenarenA.IsEnabled = false;
            btn_llenarenB.IsEnabled = false;
            prb_barraprogresoA.IsEnabled = false;
            prb_barraprogresoB.IsEnabled = false;
            btn_finalizar.IsEnabled = false;

            jarraA = null;
            jarraB = null;

            lbx_acciones.Items.Clear();

            prb_barraprogresoA.Value = 0;
            prb_barraprogresoB.Value = 0;
            
        }


    }
}
