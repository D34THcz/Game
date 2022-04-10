using Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters
{
	public class Player : Character
	{
		public Inventory Inventory { get; set; }

		public Player(int id, string name, int hp) : base(id, name, hp)
		{
			Inventory = new Inventory();
		}
	}
}
