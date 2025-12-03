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
                Console.WriteLine("A.- 1 de Diciembre (Parte 1)");
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
                        case "A": Diciembre_1_A(); break;
                        default:
                            Console.WriteLine("Input no válido");
                            seleccionado = false;
                            break;
                    }
                }
            }
        }
        static void Diciembre_1_A ()
        {
            Console.Clear();
            Console.WriteLine("Diciembre 1 (Parte 1): Presione Enter para leer documento.");

            Console.ReadLine();

            int posicion = 50;
            int cantVecesCero = 0;

            foreach (string line in File.ReadLines("res/dec1Ainput.txt"))
            {
                Console.WriteLine($"{line}");

                int cantidadGiro = int.Parse(line.Substring(1, line.Length - 1));
                switch (line[0])
                {
                    case 'L':
                        posicion -= cantidadGiro;
                        break;
                    case 'R':
                        posicion += cantidadGiro;
                        break;
                }
                while (posicion < 0)
                {
                    posicion += 100;
                }
                while (posicion > 99)
                {
                    posicion -= 100;
                }
                if (posicion == 0)
                {
                    cantVecesCero++;
                }
            }

            Console.WriteLine($"La cantidad de puntos cero son: {cantVecesCero}.");
            Console.ReadLine();
        }
    }
}
