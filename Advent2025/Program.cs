namespace Advent2025
{
    internal class Program
    {
        enum Modo
        {
            MODO_MENU_PRINCIPAL,
        };
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1.- 1 de Diciembre (Parte 1)");
                Console.WriteLine("2.- 1 de Diciembre (Parte 2)");
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
                        default:
                            Console.WriteLine("Input no válido");
                            seleccionado = false;
                            break;
                    }
                }
            }
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
