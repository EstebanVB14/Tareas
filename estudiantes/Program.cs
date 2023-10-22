using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudiantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Acumuladores y contadores

            // contadores
            int contador = 0;

            contador = contador + 1;
            contador++; //0 1 2 3
            ++contador; //0 1 2 3 
            --contador; // 0 -1 -2 -3
            contador--; // 0 -1 -2 -3 

            //ciclo for
            for (int i = 4 - 1; i >= 0; i--) {

                Console.WriteLine(i);


                Console.ReadLine();

                // arreglos
                string[] notas = new int[4];

                float[] notas = new float[4];
                //hacer algoritmo que caalcule promedio de notas de todos los estudiantes
                //calcular cantidad de estudiantes que tiene nota superior al promedio
                // 4 estudiantes, formula la suma notas dividido la cantidad estudiantes

                string[] estudiantes = new string[4];
                float[] notas = new float[4];
                float promedio = 0;
               
              for(int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Digite el nombre");
                    estudiantes[i] = Console.ReadLine();
                    Console.WriteLine("Digite la nota");
                    notas[i] = float.Parse(Console.ReadLine());
                    promedio += notas[i]; //sumotoria notas

                }
                promedio /= estudiantes.Length;

                Console.WriteLine($"el promedio es de {promedio} "); 
                // calcula la cantidad de estudiantes que tienen una nota superior al promedio
                    

                for (int i = 0; i < notas.Length; i++)
                {
                    if(notas[i]>promedio)
                    {
                        Console.ReadLine($"nombre:{estudiantes[i]} nota: {notas[i]}");
                        contador++;



                    }
                
                    Console.ReadLine();
                }
