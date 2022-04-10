using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
	public class Inventory
	{
		public int MaxSlots { get; set; }
		public List<Item> Items { get; set; }

		public Inventory()
		{
			Items = new List<Item>();
		}
	}
}
