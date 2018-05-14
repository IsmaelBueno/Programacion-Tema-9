using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------------------
using System.ComponentModel;

namespace Ejercicio_18
{
    public delegate void Delegado (int contenido);
    class Jarra
    {
        //EVENTOS
        public event Delegado CambioContenido;

        //CAMPOS
        int _capacidad;
        int _contenido;

        //PROPIEDADES
        public int Capacidad
        {
            get { return _capacidad; }
        }
        public int Contenido
        {
            get { return _contenido; }
            set
            {
                if (_contenido != value)
                {
                    CambioContenido(value);
                    _contenido = value;
                }
            }
        }

        //CONSTRUCTOR
        public Jarra(int capacidad)
        {
            _capacidad = capacidad;
            Contenido = 0;
        }

        //METODOS
        public bool Llenar()
        {
            if (Contenido == _capacidad)
                return false;
            else
            {
                Contenido = _capacidad;
                return true;
            }
        }
        public bool Vaciar()
        {
            if (Contenido == 0)
                return false;
            else
            {
                Contenido = 0;
                return true;
            }
        }
        public bool LLenarDesde(Jarra jarra)
        {
            //caso que ya este llena la jarra
            if (Contenido == _capacidad)
                return false;
            //caso que la jarra que va a llenar esté vacía
            if (jarra.Contenido == 0)
                return false;

            if (jarra.Contenido > _capacidad - Contenido)
            {
                jarra.Contenido -= _capacidad - Contenido;
                Contenido = _capacidad;
                return true;
            }
            else
            {
                Contenido += jarra.Contenido;
                jarra.Contenido = 0;
                return true;
            }
        }

        public override string ToString()
        {
            return string.Format("Capacidad: {0}, Contenido: {1}",_capacidad,_contenido);
        }

    }
}
