using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class CombatManager
    {
        public Player Fighter1 { get; set; }
        public Player Fighter2 { get; set; }

        public CombatManager(Player fighter1, Player fighter2)
        {
            Fighter1 = fighter1; 
            Fighter2 = fighter2;
        }

        public bool StartCombat()
        {
            Console.WriteLine("Battle starts !");
            while (Fighter1.Hitpoint > 0 && Fighter2.Hitpoint > 0)
            {
                var damageReceived = Fighter2.ReceiveDamage(Fighter1.CalculateDamage());
                Console.WriteLine($"{Fighter1.Name} attacks for {damageReceived} damage. {Fighter2.Name} have {Fighter2.Hitpoint} hitpoints left.");
                Console.ReadLine();
                
                if (Fighter2.Hitpoint >= 1)
                {
                    damageReceived = Fighter1.ReceiveDamage(Fighter2.CalculateDamage());
                    Console.WriteLine($"{Fighter2.Name} attacks for {damageReceived} damage. {Fighter1.Name} have {Fighter1.Hitpoint} hitpoints left.");
                    Console.ReadLine();

                    if (Fighter1.Hitpoint < 1)
                        Console.WriteLine($"{Fighter2.Name} WINS");
                }
                else
                {
                    Console.WriteLine($"{Fighter1.Name} WINS with {Fighter1.Hitpoint} hitpoints left.");
                }
            }
            Console.WriteLine("Battle ends !");
            return true;
        }      
    }
}
