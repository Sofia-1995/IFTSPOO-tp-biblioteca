using System;

namespace TP_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            cargarLibros(10);
            cargarLibros(2);
            biblioteca.listarLibros();
            biblioteca.eliminarLibro("Libro5");
            biblioteca.listarLibros();
            cargarLectores(5);
            biblioteca.listarLectores();
            biblioteca.prestarLibro("Libro10", "dni5");
            //biblioteca.prestarLibro("Libro8", "dni5");
            //biblioteca.prestarLibro("Libro7", "dni5");
            //biblioteca.prestarLibro("Libro6", "dni5");

            biblioteca.listarLibros();

            biblioteca.listarLectores();


            void cargarLibros(int cantidad)
            {
                bool pude;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i);
                    if (pude)
                        Console.WriteLine("Libro" + i + " agregado correctamente.");
                    else
                        Console.WriteLine("Libro" + i + " Ya existe en la biblioteca.");
                }
            }

            void cargarLectores (int cantidad)
            {
                bool pude;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.altaLector("Nombre" + i, "dni" + i);
                    if (pude)
                        Console.WriteLine("Nombre" + i + " agregado correctamente.");
                    else
                        Console.WriteLine("Nombre" + i + " Ya existe en la biblioteca.");
                }
            }
        }
    }
}

