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
        public abstract int Strength { get; set; }
        public abstract EquipableWeapon? EquipedWeapon { get; set; }
        public abstract EquipableArmor? EquipedArmor { get; set; }
        public abstract Inventory Inventory { get; set; }
        public abstract int MaxWeight { get; set; }
        public int TotalDamage
        {
            get
            {
                return CalculateTotalDamage();
            }
        }
        public int Defense
        {
            get
            {
                return CalculateDefense();
            }
        }

        public void DealDamage(Character targetCharacter)
        {
            targetCharacter.ReceiveDamage(TotalDamage - targetCharacter.Defense);
        }

        public void ReceiveDamage(int damage)
        {
            Hitpoint -= damage;
        }

        public void EquipWeapon(EquipableWeapon weapon) 
        {
            
            if(EquipedWeapon != null)
                Inventory.Items.Add(EquipedWeapon);
            EquipedWeapon = (EquipableWeapon?)Inventory.Items.Find(x => x == weapon);
            Inventory.Items.Remove(weapon);
        }

        public void UnEquipWeapon()
        {
            if(EquipedWeapon != null)
                Inventory.Items.Add(EquipedWeapon);
            EquipedWeapon = null;
        }

        public void EquipAmor(EquipableArmor armor)
        {
            if (EquipedArmor != null)
                Inventory.Items.Add(EquipedArmor);
            EquipedArmor = (EquipableArmor?)Inventory.Items.Find(x => x == armor);
            Inventory.Items.Remove(armor);
        }

        public void UnEquipArmor()
        {
            if (EquipedArmor != null)
                Inventory.Items.Add(EquipedArmor);
            EquipedArmor = null;
        }

        public void UseItem(Item item)
        {
            item.UseItem(this);
        }

        public int CalculateTotalDamage()
        {
            var totalDamage = 0;
            //var strength = 0;

            if(EquipedWeapon != null)
                totalDamage = EquipedWeapon.Damage;

            totalDamage += Strength;

            //foreach (item in EquipedItems)
            //{
            //    strength += item.Strength;
            //}

            //totalDamage = totalDamage * (1 + strength / 100);

            return totalDamage;
        }

        public int CalculateDefense()
        {
            var defense = 0;
            if(EquipedArmor != null)
                defense = EquipedArmor.ArmorValue;
            return defense;
        }
    }
}
