using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIndividual_Progra_Prom1
{
    class Game
    {
        public static Game Instance;

        public Player player;
        private Inventory<Enemy> inventory = new Inventory<Enemy>();
        private Dictionary<string, Enemy> enemyDictionary = new Dictionary<string, Enemy>();
        private Random random=new Random();

        public Game()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                return;
            }
        }

        private void CreateEnemyOptions()
        {
            var unicorn = new Unicorn();
            enemyDictionary.Add(unicorn.enemyName, unicorn);

            var cat = new Cat();
            enemyDictionary.Add(cat.enemyName, cat);
        }

        public void NewGame()
        {
            CreateEnemyOptions();
            Texting.Coloring("HOLAAA BIENVENID@ a esta aventura");
            Texting.Type(ConsoleColor.White,40,"\n*      *      *");
            Texting.Type(ConsoleColor.Yellow, 16, "\nYo soy Miel y te acompañare en tu travesia~");
            Texting.Type(ConsoleColor.Yellow, 16, "\nPrimero debemos crear a tu personaje!!");
            Console.WriteLine("\n>      >      >");
            player = new Player();

            Texting.Type(ConsoleColor.White, 16, "\nMuy bien todo esta listo asi que...");
            Console.WriteLine("\nEMPECEMOS\n");
            Texting.Type(ConsoleColor.White, 40, "\n>      >      >");

            GameLoop();
        }

        private void GameLoop()
        {
            bool playing = true;

            while (playing)
            {
                Console.WriteLine("\n¿Qué deseas hacer?");
                Console.WriteLine("1. Explorar");
                Console.WriteLine("2. Salir");
                Console.WriteLine("3. Ver inventario");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Explore();
                        break;
                    case "2":
                        playing = false;
                        Console.WriteLine("lolo");
                        break;
                    case "3":
                        ShowInventory();
                        break;
                    default:
                        IncorrectAnswerMessage();
                        break;
                }
            }
        }

        private void Explore()
        {
            Texting.Coloring("\nExplorando...");
            if (random.Next(0, 2) == 0)
            {
                EncounterEnemy();
            }
            else
            {
                Texting.Type(ConsoleColor.Red, 16, "\nNo encontraste nada...");
            }
        }

        private void ShowInventory()
        {
            inventory.ShowItems();
        }

        private void EncounterEnemy()
        {
            string enemyName = enemyDictionary.Keys.ElementAt(random.Next(enemyDictionary.Count));

            if (enemyDictionary.TryGetValue(enemyName, out Enemy enemy))
            {
                enemy.AssignValues();
                //Console.WriteLine($"¡Te has encontrado con un {enemy.enemyName}!");

                while (enemy.health > 0 && player.health > 0)
                {
                    Console.WriteLine("¿Qué deseas hacer?");
                    Console.WriteLine("1. Atacar");
                    Console.WriteLine("2. Huir");
                    Console.WriteLine("3. Conservar");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AttackEnemy(enemy);
                            break;
                        case "2":
                            Console.WriteLine("lol");
                            return;
                        case "3":
                            inventory.Add(enemy);

                            return;
                        default:
                            IncorrectAnswerMessage();
                            break;
                    }
                }

                if (player.health <= 0)
                {
                    Texting.Type(ConsoleColor.Red, 16,"Te quedaste sin vida...");
                    Texting.Type(ConsoleColor.Red, 40, "Perdiste...");
                    Environment.Exit(0);
                }
                else if (enemy.health <= 0)
                {
                    Console.WriteLine($"Has derrotado a un inocente {enemy.enemyName}!");
                }
            }
            else
            {
                Console.WriteLine("e e e  e");
            }
        }

        private void AttackEnemy(Enemy enemy)
        {
            enemy.TakeDamage(player.attack);
            if (enemy.health > 0)
            {
                player.TakeDamage(enemy.attack);
            }
        }

        public void IncorrectAnswerMessage()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Lo siento no puedo utilizar esa informacion :(");
            Console.ResetColor();
        }
    }
}