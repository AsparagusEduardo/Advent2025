using System.Text.RegularExpressions;

namespace Advent2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1.- Dec 1, Secret Entrance (Part 1)");
                Console.WriteLine("2.- Dec 1, Secret Entrance (Part 2)");
                Console.WriteLine("3.- Dec 2, Gift Shop (Part 1)");
                Console.WriteLine("4.- Dec 2, Gift Shop (Part 2)");
                bool seleccionado = false;

                while (!seleccionado) {
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        Console.WriteLine("Input no válido");
                        continue;
                    }
                    seleccionado = true;
                    switch (input.ToUpperInvariant())
                    {
                        case "1": Diciembre_1(false); break;
                        case "2": Diciembre_1(true); break;
                        case "3": Diciembre_2(false); break;
                        case "4": Diciembre_2(true); break;
                        default:
                            Console.WriteLine("Input no válido");
                            seleccionado = false;
                            break;
                    }
                }
            }
        }

        static void Diciembre_2(bool parte2)
        {
            Console.Clear();
            if (parte2)
                Console.WriteLine("Diciembre 2 (Parte 2): Presione Enter para iniciar el proceso.");
            else
                Console.WriteLine("Diciembre 2 (Parte 1): Presione Enter para iniciar el proceso.");
            Console.ReadLine();

            ulong sumaIDInvalidos = 0;

            foreach (string line in File.ReadLines("res/dec2input.txt"))
            {
                string[] rangos = line.Split(",");
                for (int i = 0; i < rangos.Length; i++)
                {
                    string[] rango = rangos[i].Split("-");
                    ulong inicio = ulong.Parse(rango[0]);
                    ulong fin = ulong.Parse(rango[1]);

                    for (ulong j = inicio; j <= fin; j++)
                    {
                        string texto = j.ToString();
                        int largo = texto.Length;

                        //Console.WriteLine($"{j}");
                        bool esInvalido = false;

                        for (int k = 1; k < largo && !esInvalido; k++)
                        {
                            if (largo % k != 0)
                                continue;
                            if (parte2 && (largo % 2 != 0 || k != largo / 2))
                                continue;
                            //Console.WriteLine($"  k:{k}");
                            string inicial = texto.Substring(0, k);
                            bool patronEsIgual = true;
                            for (int l = 0; l < largo / k; l++)
                            {
                                string subPatron = texto.Substring(l * k, k);
                                if (!inicial.Equals(subPatron))
                                    patronEsIgual = false;
                                //Console.WriteLine($"    l:{l}, inicial:{inicial}, substr:{subPatron},");
                            }
                            if (patronEsIgual)
                            {
                                //Console.WriteLine("PATRON IGUAL");
                                esInvalido = true;
                                break;
                            }
                            //if ()
                        }
                        if (esInvalido)
                        {
                            sumaIDInvalidos += j;
                            Console.WriteLine($"{j}");
                        }


                        //if (Regex.Count(j.ToString(), @"(\d+)(\1{1,})") > 0)
                        //{
                        //    sumaIDInvalidos += j;
                        //    Console.WriteLine($"{j}");
                        //}
                    }
                    //Console.WriteLine(rangos[i]);
                }
            }
            Console.WriteLine($"\nFin: {sumaIDInvalidos}");

            Console.ReadLine();
        }
        static void Diciembre_1 (bool considerarRotaciones)
        {
            Console.Clear();
            if (considerarRotaciones)
                Console.WriteLine("Diciembre 1 (Parte 2): Presione Enter para leer documento.");
            else
                Console.WriteLine("Diciembre 1 (Parte 1): Presione Enter para leer documento.");

            Console.ReadLine();

            int posicion = 50;
            int cantVecesCero = 0;

            Console.WriteLine($"pos:{posicion}");

            foreach (string line in File.ReadLines("res/dec1Ainput.txt"))
            {
                int cantidadGiro = int.Parse(line.Substring(1, line.Length - 1));
                switch (line[0])
                {
                    case 'L':
                        while (cantidadGiro != 0)
                        {
                            cantidadGiro--;
                            posicion--;
                            if (posicion == 0 && considerarRotaciones)
                                cantVecesCero++;
                            else if (posicion < 0)
                                posicion = 99;
                        }
                        break;
                    case 'R':
                        while (cantidadGiro != 0)
                        {
                            cantidadGiro--;
                            posicion++;
                            if (posicion == 100)
                            {
                                posicion = 0;
                                if (considerarRotaciones)
                                    cantVecesCero++;
                            }
                        }
                        break;
                }
                if (posicion == 0 && !considerarRotaciones)
                {
                    cantVecesCero++;
                }
                Console.WriteLine($"{line},pos:{posicion},cant:{cantVecesCero}");
            }

            Console.WriteLine($"La cantidad de puntos cero son: {cantVecesCero}.");
            Console.ReadLine();
        }
    }
}
