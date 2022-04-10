using Game.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{
	public class CombatManager
	{
		public Character Figter0 { get; set; }
		public Character Figter1 { get; set; }

		public CombatManager(Character figther0, Character fighter1)
		{
			Figter0 = figther0;
			Figter1 = fighter1;
		}

		public void StartFight()
		{
			Console.WriteLine("Initiating fight!!!");

			int round = 0;

			// Combat loop
			while(Figter0.HP > 0 && Figter1.HP > 0)
			{
				Console.WriteLine($"Round {round++}");

				if(Attack(Figter0, Figter1))
				{
					break;
				}
				if(Attack(Figter1, Figter0))
				{
					break;
				}

				Console.ReadLine();
			}

			Console.WriteLine("End fight");
			
		}

		private bool Attack(Character attacker, Character defender)
		{
			var damage = attacker.CalculateDamage();
			var receivedDamage = defender.ReceiveDamage(damage);
			var hpLeft = defender.HP;

			if(hpLeft < 0)
			{
				hpLeft = 0;
				Console.WriteLine($"{attacker.Name} deals {receivedDamage} damage to {defender.Name} KILLING BLOW!");
				return true;
			}

			Console.WriteLine($"{attacker.Name} deals {receivedDamage} damage to {defender.Name}, {defender.Name} has {hpLeft} HP");
			return false;
		}
	}
}
