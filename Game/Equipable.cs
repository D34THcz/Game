using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Equipable : Item
    {
        public enum EquipmentType
        {
            HELM = 0,
            CHEST = 1,
            LEGS = 2,
            WEAPON = 3,
            RING = 4
        }

        public abstract EquipmentType Type { get; set; }
        public abstract int DamageModifier { get; set; }
        public abstract int ArmorModifier { get; set; }
    }
}
