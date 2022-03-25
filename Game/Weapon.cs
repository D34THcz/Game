using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Weapon : EquipableWeapon
    {
        public override int DamageModifier { get; set; }
        public override string Name { get; set; }
        public override int Id { get; set; }
        public override int Weight { get; set; }
        public override Character Character { get; set; }
        public override Inventory Inventory { get; set; }
        private static int _id = 0;

        public Weapon(Inventory inventory, string name, int weight, int damageModifier)
        {
            Inventory = inventory;
            Inventory.AddItem(this);
            Character = Inventory.Character;
            Name = name;
            Id = _id + 1;
            Weight = weight;
            DamageModifier = damageModifier;
        }

        public override void UseItem()
        {
            throw new NotImplementedException();
        }

        public override void DestroyItem()
        {
            throw new NotImplementedException();
        }
    }
}
