using Game.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    public class Item 
    {
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }
        public int Weight { get; set; }
        public Ability? AbilityToUse { get; set; }

        public Item(int id, string name, int weight)
		{
            Id = id;
            Name = name;
            Weight = weight;
		}

		public void UseItem()
		{
            if(AbilityToUse == null)
			{
                return;
			}


		}

        public override string ToString()
        {
            return Name;
        }
    }
}
