using System;
using System.Collections.Generic;

namespace TP_1
{
	internal class Lector
    {
		private string nombre;
        private string dni;
        private List<Libro> librosPrestados;

        public Lector(string nombre, string dni)
		{
			this.nombre = nombre;
			this.dni = dni;
            this.librosPrestados = new List<Libro>();
        }

        public bool tomarLibroPrestado(Libro nuevoLibro)
		{
			bool resultado = false;
			if (librosPrestados.Count < 3)
			{
				librosPrestados.Add(nuevoLibro);
				resultado = true;
			}
			return resultado;
		}

        public string getDni()
        {
            return dni;
        }

        public override string ToString()
        {
            return "Nombre: " + nombre + " DNI: " + dni + "Libros: " + librosPrestados.Count;
        }

    }
}

