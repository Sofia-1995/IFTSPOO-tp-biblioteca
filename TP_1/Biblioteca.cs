using System;
using System.Collections.Generic;

namespace TP_1
{
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>();

        }

        // aca buscamos al libro por titulo
        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null; // creo un libro vacio
            int i = 0; // creo contador

            // voy elemento por elemento
            // pregunto si el elemento en esa posicion coincide titulo
            // si no coincide, paso al siguiente numero
            // si coincide, corto y no sumo mas (no entra al while)
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
                i++;

            // pregunto si el contador no se paso del limite
            if (i != libros.Count)
                libroBuscado = libros[i]; // guardo el libro en esa posicion

            return libroBuscado; // devuelvo el libro, ya sea null, o el encontrado
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
                Console.WriteLine(libro);
        }

        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }
            return resultado;
        }

        private Lector buscarLector(string dni)
        {
            //misma logica que buscarLibro pero con lectores
            Lector lectorBuscado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].getDni().Equals(dni)) i++;
            if (i != lectores.Count)
                lectorBuscado = lectores[i];
            return lectorBuscado;
        }

        public string prestarLibro(string titulo, string dni)
        {
            // primero tiene que existir un libro
            string resultado = "";
            Libro libro;
            libro = buscarLibro(titulo); // busco libro
            if (libro != null) // si libro existe sigo
            {
                Lector lector; // tiene que existir un lector
                lector = buscarLector(dni); // busco lector

                // si lector existe
                // y si pude prestar el libro
                if (lector != null)
                {
                    if (lector.tomarLibroPrestado(libro))
                    {
                        libros.Remove(libro); //borro el libro de la lista
                        resultado = "PRESTAMO EXITOSO";
                    }
                    else
                    {
                        resultado = "TOPE DE PRESTAMO ALCAZADO";
                    }
                }
                else
                {
                    resultado = "LECTOR INEXISTENTE";
                }

            }
            else
            {
                resultado = "LIBRO INEXISTENTE";
            }
            return resultado;
        }

        public bool altaLector(string nombre, string dni)
        {
            bool resultado = false;
            Lector lector;
            lector = buscarLector(dni);
            if (lector == null)
            {
                lector = new Lector(nombre, dni);
                lectores.Add(lector);
                resultado = true;
            }
            return resultado;
        }

        public void listarLectores()
        {
            foreach (var lector in lectores)
                Console.WriteLine(lector);
        }
    }
}
