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
            Console.WriteLine("Diciembre 1 (Parte 1):");
            Console.ReadLine();
            //bool running = true;
            //
            //while (running)
            //{
            //
            //}
        }
    }
}
