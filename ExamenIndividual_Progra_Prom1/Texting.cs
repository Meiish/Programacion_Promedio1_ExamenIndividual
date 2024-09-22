using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamenIndividual_Progra_Prom1
{
    public static class Texting
    {
        public static void Type(ConsoleColor color, int speed, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.ForegroundColor = color;
                Console.Write(text[i]);
                Thread.Sleep(speed);
            }
            Console.ResetColor();
        }

        public static void Coloring(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < text.Length; i++)
            {
                Thread.Sleep(20);

                ConsoleColor color = (ConsoleColor)((i % 15) + 1);
                Console.ForegroundColor = color;

                Console.Write(text[i]);
            }
            Console.ResetColor();
        }
    }
}
