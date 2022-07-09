using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : Character
    {
        public override string Name { get; set; }
        public override int Hitpoint { get; set; }
        public override int Strength { get; set; }
        public override Inventory Inventory { get; set; }
        public override int MaxWeight { get; set; }
        public override Dictionary<int, Equipable> EquipedGear { get; set; }

        public Player(string name, int hitpoint, int maxWeight, int strength = 1)
        {
            Name = name;
            Hitpoint = hitpoint;
            Strength = strength;
            Inventory = new Inventory();
            EquipedGear = new Dictionary<int,Equipable>();
            MaxWeight = maxWeight;
        }
    }
}
