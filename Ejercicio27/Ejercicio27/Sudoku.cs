using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------------
using System.IO;

namespace Ejercicio27
{
    class Sudoku
    {
        //Campos
        private char[,] _sudoku;
        private char[,] _solucion;
        private static int TAMANIODIMENSIONES = 9;

        //Propiedades
        public char[,] Sudoku1
        {
            get { return _sudoku; }
        }
        public char[,] Solucion
        {
            get { return _solucion; }
        }
        public static int TAMANIODIMENSIONES1
        {
            get { return Sudoku.TAMANIODIMENSIONES; }
        }

        //constructor
        public Sudoku(string rutaSudoku, string rutaSoluciones, int nSudoku)
        {
            _sudoku = CargarContenido(rutaSudoku, nSudoku);
            _solucion = CargarContenido(rutaSoluciones, nSudoku);
        }

        private char[,] CargarContenido(string ruta, int nSudoku)
        {
            char[,] tmpContenido = new char[TAMANIODIMENSIONES, TAMANIODIMENSIONES];
            string contenidoFichero = string.Empty;
            string[] sudokusSeparados;
            int contadorLectura = 0;
            char[] separadores = {'\n'};

            //Leer el contenido del fichero
            using(StreamReader fichero = new StreamReader(ruta))
            {
                contenidoFichero = fichero.ReadToEnd();
            }

            //Seleccionar el número de sudoku correspondiente
            sudokusSeparados = contenidoFichero.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            contenidoFichero = sudokusSeparados[nSudoku];

            //Llenar la matriz con el contenido de la fila del sudoku correspondiente
            for (int i = 0; i < TAMANIODIMENSIONES; i++)
            {
                for (int j = 0; j < TAMANIODIMENSIONES; j++)
                {
                    tmpContenido[i, j] = contenidoFichero[contadorLectura];
                    contadorLectura++;
                }
            }

            return tmpContenido;
            

        }
    }
}
