using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIndividual_Progra_Prom1
{
    public class Inventory<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
            Console.WriteLine($"Lo has añadido al inventario ~");
        }

        public void ShowItems()
        {
            Console.WriteLine("Tu inventario contiene:");
            if (items.Count == 0)
            {
                Console.WriteLine("Aun no tienes nada en tu inventario :(");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
