using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIndividual_Progra_Prom1
{
    class Player : IDamagable
    {
        public int health;
        public int attack;
        public string name;

        public Player()
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ResetColor();
                    Console.WriteLine("\nAsi que debes tener un nombre~");
                    Texting.Coloring("\nComo deseas llammarte (° 0 °)/\n");
                    name = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCuanta vida deseas que tener ~");
                    health = int.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nCuanto de ataque magico deseas que tener ~");
                    attack = int.Parse(Console.ReadLine());

                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Has creado a {name} con {health} de vida y {attack} de ataque");
                    Console.ResetColor();

                    break;
                }
                catch
                {
                    Game.Instance.IncorrectAnswerMessage();
                    continue;
                }
            }
        }
        public void TakeDamage(int amount)
        {
            health -= amount;
            Console.WriteLine($"Has recibido {amount} de daño. Te queda {health} de vida.");
        }
    }
}