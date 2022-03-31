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
        public override int BaseDamage { get; set; }
        public override Inventory Inventory { get; set; }
        public override EquipableWeapon? EquipedWeapon { get; set; }
        public override int MaxWeight { get; set; }

        public Player(string name, int hitpoint, int maxWeight, EquipableWeapon? equipedWeapon = null, int baseDamage = 1)
        {
            Name = name;
            Hitpoint = hitpoint;
            EquipedWeapon = equipedWeapon;
            BaseDamage = baseDamage;
            Inventory = new Inventory();
            MaxWeight = maxWeight;
        }
    }
}
