using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Character
    {
        public abstract string Name { get; set; }
        public abstract int Hitpoint { get; set; }
        public abstract int BaseDamage { get; set; }  
        public abstract EquipableWeapon? EquipedWeapon { get; set; }
        public abstract Inventory Inventory { get; set; }
        public abstract int MaxWeight { get; set; }
        private int _totalDamage;
        public int TotalDamage
        {
            get
            {
                RefreshTotalDamage();
                return _totalDamage;
            }
            set
            {
                _totalDamage = value;
            }
        }

        public virtual void Attack(Character targetCharacter)
        {
            targetCharacter.Hitpoint -= this.TotalDamage;
        }

        public void EquipWeapon(EquipableWeapon weapon) 
        {
            
            if(EquipedWeapon != null)
                Inventory.Items.Add(EquipedWeapon);
            EquipedWeapon = (EquipableWeapon?)Inventory.Items.Find(x => x == weapon);
            Inventory.Items.Remove(weapon);
            RefreshTotalDamage();
        }

        public void UnEquipWeapon()
        {
            if(EquipedWeapon != null)
                Inventory.Items.Add(EquipedWeapon);
            EquipedWeapon = null;
            RefreshTotalDamage();
        }

        public void UseItem(Item item)
        {
            item.UseItem(this);
        }

        public void RefreshTotalDamage()
        {
            var WeaponModifier = 0;
            if (EquipedWeapon != null)
                WeaponModifier = EquipedWeapon.DamageModifier;
            _totalDamage = BaseDamage + WeaponModifier;
        }
    }
}
