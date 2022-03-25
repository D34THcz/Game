using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class EquipableWeapon : Equipable
    {
        public abstract int DamageModifier { get; set; }

        public override void EquipItem()
        {
            Character.EquipedWeapon = this;
            Character.Inventory.Items.Remove(this);
            Character.TotalDamage = Character.BaseDamage + Character.EquipedWeapon.DamageModifier;
        }

        public override void UnEquipItem()
        {
            Character.Inventory.Items.Add(this);
            Character.EquipedWeapon = null;
            Character.TotalDamage = Character.BaseDamage + 0;
        }
    }
}
