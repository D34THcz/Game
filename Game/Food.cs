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
            _id += 1;
            Weight = weight;
            HitpointsRecovered = hitpoints;
        }

        public override void UseItem(Character character)
        {
            character.Hitpoint += HitpointsRecovered;
            character.Inventory.DestroyItem(this);
        }
    }
}
