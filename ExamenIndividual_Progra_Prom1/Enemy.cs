using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIndividual_Progra_Prom1
{
    abstract class Enemy : IDamagable
    {
        public string enemyName;
        public int health;
        public int attack;

        public Enemy() { }

        public abstract void AssignValues();
        public void TakeDamage(int amount)
        {
            health -= amount;
            Console.WriteLine($"{enemyName} ha recibido {amount} de daño. Le queda {health} de vida.");
        }
        public override string ToString()
        {
            return $"-{enemyName} (Vida: {health}, Ataque: {attack})";
        }
    }
}
