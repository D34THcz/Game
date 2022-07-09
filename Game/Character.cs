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
        public abstract Dictionary<int, Equipable> EquipedGear { get; set; }
        public abstract Inventory Inventory { get; set; }
        public abstract int MaxWeight { get; set; }
        
        // Subtract hitpoints of character based on damage reduced by defense stat
        public int ReceiveDamage(int damage)
        {
            var defense = CalculateDefense();
            var damageReceived = damage - defense;
            
            if (damageReceived < 1)
                damageReceived = 1;
            
            Hitpoint -= damageReceived;
            return damageReceived;
        }

        // Check if item is in characters inventory and if same type is already equiped then unequip item first (switch items)
        public bool EquipGear(Equipable equipableGear)          
        {
            if (IsInInventory(equipableGear))
            {
                if (EquipedGear.ContainsKey((int)equipableGear.Type))
                    UnEquipGear(equipableGear);
                EquipedGear.Add((int)equipableGear.Type, equipableGear);
                return true;
            }
            else
                return false;
        }

        // Check if provided gear is equiped and then unequip it
        public bool UnEquipGear(Equipable equipableGear)
        {
            if (EquipedGear.ContainsKey((int)equipableGear.Type))
            {
                EquipedGear.Remove((int)equipableGear.Type);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check if provided item is in character's inventory
        public bool IsInInventory(Item item)
        {
            if (item == Inventory.Items.Find(x => x == item))
                return true;
            else
                return false;
        }                
       

        public void UseItem(Item item)
        {
            item.UseItem(this);
        }

        // Returns total damage count based on character's strength and equiped gear
        public int CalculateDamage()
        {
            var totalDamage = Strength;
            
            foreach (var item in EquipedGear)
            {
                totalDamage += item.Value.DamageModifier;
            }
                        
            return totalDamage;
        }

        // Returns defense count based on character's equiped gear
        public int CalculateDefense()
        {
            var defense = 0;

            foreach (var item in EquipedGear)
            {
                defense += item.Value.ArmorModifier;
            }

            return defense;
        }

        // Print character's name, basic stats and equiped gear
        public string PrintCharacterStats()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"__ {Name} __");
            sb.AppendLine($"Hitpoint: {Hitpoint}");
            sb.AppendLine("Equiped gear: ");
            foreach (var item in EquipedGear)
                sb.AppendLine($"{item.Value.Name}");
            return sb.ToString();
        }
    }
}
