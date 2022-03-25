using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Inventory
    {
        public List<Item> Items = new List<Item>();
        public Character Character { get; set; }
        public Item Item { get; set; }

        public Inventory(Character character)
        {
            Character = character;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void DestroyItem(Item item)
        {
            Items.Remove(item);
            
        }

    }
}
