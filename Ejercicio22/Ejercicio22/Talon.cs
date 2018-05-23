using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio22
{
    class Talon : Notificador
    {
        string _destinatario;
        public string Destinatario
        {
            get { return _destinatario; }
            set 
            { 
                _destinatario = value;
                Notificar("Destinatario");
            }
        }


        double _cantidad;
        public double Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value > 0)
                {
                    _cantidad = value;
                    Notificar("Cantidad");
                }
            }
        }


        string _fecha;
        public string Fecha
        {
            get
            {
                return _fecha; 
            }
            set 
            {
                //Se introduzca lo que sea la fecha será la actual
                Notificar("Fecha");
                _fecha = DateTime.Now.ToShortDateString();
            }
        }


        public Talon() { }//Constructor vacío para implimentar desde xaml
    }
}
