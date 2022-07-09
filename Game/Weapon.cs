using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Weapon : Equipable
    {
        public override string Name { get; set; }
        public override int Id { get; set; }
        public override int Weight { get; set; }
        public override EquipmentType Type { get; set; }
        public override int DamageModifier { get; set; }
        public override int ArmorModifier { get; set; }

        private static int _id = 0;

        public Weapon(string name, int weight, int damageModifier, int armorModifier)
        {
            Name = name;
            Id = _id + 1;
            _id += 1;
            Weight = weight;
            DamageModifier = damageModifier;
            ArmorModifier = armorModifier;
            Type = EquipmentType.WEAPON;            
        }

        public override void UseItem(Character character)
        {
            Console.WriteLine("You killed yourself");
            character.Hitpoint = 0;
        }
    }
}
