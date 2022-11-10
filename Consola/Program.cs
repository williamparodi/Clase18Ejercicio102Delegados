﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Environment;

namespace Consola
{
    class Program
    {
        public delegate int DelegadoComparacion(string primerTexto, string segundoTexto);

        static void Main(string[] args)
        {
            // Borrar o agregar la primera barra para switchear entre las pruebas fijas y el ingreso de texto por consola. 
            //*
            string primerTexto = "Vive como si fueras a morir mañana; aprende como si el mundo fuera a durar para siempre.";
            // Cant. caracteres: 88, Cant. palabras: 17 , Cant. vocales: 34, Cant. signos puntuación: 2 
            string segundoTexto = "La vida es como montar en bicicleta; para mantener el equilibrio debes seguir moviéndote.";
            // Cant. caracteres: 89, Cant. palabras: 13, Cant. vocales: 35, Cant. signos puntuación: 2

            /*/
            Console.WriteLine("Ingrese el primer texto:");
            string primerTexto = Console.ReadLine();

            Console.WriteLine("Ingrese el segundo texto:");
            string segundoTexto = Console.ReadLine();
            //*/

            Console.WriteLine($"{NewLine}1era Comparación - Texto con más caracteres:");
            Comparar(primerTexto, segundoTexto,(p,s) => p.Length - s.Length);
            // Punto 2

            Console.WriteLine($"{NewLine}2da Comparación - Texto con más palabras:");
            Comparar(primerTexto,segundoTexto,(p,s) => p.Split(' ').Length - s.Split(' ').Length);
            // Punto 3
            
            Console.WriteLine($"{NewLine}3era Comparación - Texto con más vocales:");
            // Punto 4
            Comparar(primerTexto,segundoTexto,(p,s) => ContarVocales(p) - ContarVocales(s));

            Console.WriteLine($"{NewLine}4ta Comparación - Texto con más signos de puntuación:");
            Comparar(primerTexto,segundoTexto,(p,s) => ContarSignosPuntuacion(p) - ContarSignosPuntuacion (s));
            // Punto 5
        }

        public static int ContarVocales(string texto)
        {
            List<char> vocales = new List<char>()
            {
                'a', 'á', 'A', 'Á', 'e', 'é', 'E', 'É',
                'i', 'í', 'I', 'Í', 'o', 'ó', 'O', 'Ó',
                'u', 'ú', 'U', 'Ú'
            };

            return ContarCaracteres(texto, vocales);
        }

        public static int ContarSignosPuntuacion(string texto)
        {
            List<char> signosPuntuacion = new List<char>()
            {
                '.', ';', ','
            };

            return ContarCaracteres(texto, signosPuntuacion);
        }

        public static int ContarCaracteres(string texto, List<char> caracteres)
        {
            int cantidadCaracteres = 0;

            foreach (char caracter in texto)
            {
                if (caracteres.Contains(caracter))
                {
                    cantidadCaracteres++;
                }
            }

            return cantidadCaracteres;
        }

        public static void Comparar(string texto1,string texto2,DelegadoComparacion delegado)
        {
            int retorno = delegado(texto1, texto2);
            
            if(retorno > 0)
            {
                Console.WriteLine("El primer texto es mayor al segundo");
            }
            else if( retorno < 0)
            {
                Console.WriteLine("El segundo texto es mayor al primero");
            }
            else
            {
                Console.WriteLine("Son iguales");
            }

        }
    }
}
