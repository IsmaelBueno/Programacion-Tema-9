using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPrincipalEjercicios
{
    public class Cliente
    {
        //CAMPOS
        private string _dni;
        private int _edad;
        private DateTime _fechaNacimiento;
        private double _sueldo;
        private string _apellidos;
        private string _nombre;

        //PROPIEDADES
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }
        public int Edad
        {
            get { return _edad; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set 
            {
                if (value < DateTime.Now)
                {
                    _edad = CalcularEdad(value);
                    _fechaNacimiento = value;
                }
                else
                {
                    _edad = 0;
                    _fechaNacimiento = DateTime.Now;
                }
            }
        }
        public double Sueldo
        {
            get { return _sueldo; }
            set 
            { _sueldo = value; }
        }
        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int CalcularEdad(DateTime fn)
        {
            int edad = DateTime.Now.Year - fn.Year;

            if (DateTime.Now.Month > fn.Month) return edad;
            if (DateTime.Now.Month < fn.Month) return edad -1;
            if (DateTime.Now.Month == fn.Month)
            {
                if (DateTime.Now.Day >= fn.Day) return edad;
                else return edad-1;
            }

            return -1;
        }

        public override string ToString()
        {
            return _dni + ";" + _nombre + ";" + _apellidos + ";" + _fechaNacimiento + ";" + _sueldo;
        }
    }
}
