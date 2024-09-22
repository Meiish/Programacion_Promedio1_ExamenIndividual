using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIndividual_Progra_Prom1
{
    class Cat : Enemy
    {
        public Cat()
        {
            enemyName = "Gato";
        }
        public override void AssignValues()
        {
                Console.WriteLine($"\nmiau miau");
                Console.WriteLine($"\nEncontraste a un {enemyName}");
                Console.WriteLine($"\nInserta su vida >>>");

                health = int.Parse(Console.ReadLine());

                Console.WriteLine("\nInserta su ataque >>>");

                attack = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enemigo {enemyName} creado con {health} de vida y {attack} de ataque");
        }
    }
}