using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Food : Consumable
    {
        public override string Name { get; set; }
        public override int Id { get; set; }
        public override int Weight { get; set; }
        public override int HitpointsRecovered { get; set; }
        private static int _id = 0;

        public Food(string name, int weight, int hitpoints)
        {
            Name = name;
            Id = _id + 1;
            Weight = weight;
            HitpointsRecovered = hitpoints;
        }

        public override void UseItem()
        {
            //Character.Hitpoint += HitpointsRecovered;
            //DestroyItem();
        }

        public void ItemNotFound()
        {
            Console.WriteLine("Item not found");
        }

        public override void DestroyItem()
        {
            //Inventory.DestroyItem(this);
        }
    }
}
