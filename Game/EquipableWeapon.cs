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

        public override void EquipItem(Character character)
        {
            character.EquipedWeapon = (EquipableWeapon?)character.Inventory.Items.Find(this.Equals);
            character.Inventory.Items.Remove(this);
            character.RefreshTotalDamage();
        }

        public override void UnEquipItem(Character character)
        {
            character.Inventory.Items.Add(this);
            character.EquipedWeapon = null;
            character.RefreshTotalDamage();
        }
    }
}
