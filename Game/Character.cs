namespace Game
{
    public abstract class Character
    {
        public abstract string Name { get; set; }
        public abstract int Hitpoint { get; set; }
        public abstract int Strength { get; set; }
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
        public abstract Inventory Inventory { get; set; }
        public abstract GearSlot EquipedHelm { get; set; }
        public abstract GearSlot EquipedChest { get; set; }
        public abstract GearSlot EquipedLegs { get; set; }
        public abstract GearSlot EquipedWeapon { get; set; }
        public abstract GearSlot EquipedRingLeft { get; set; }
        public abstract GearSlot EquipedRingRight { get; set; }
        public abstract Dictionary<GearSlot, Equipable?> EquipedGear { get; set; } 

        public void DealDamage(Character targetCharacter)
        {
            targetCharacter.ReceiveDamage(TotalDamage - targetCharacter.Defense);
        }

        public void ReceiveDamage(int damage)
        {
            if(damage < 0)
                damage = 0;
            Hitpoint -= damage;
        }

        public void EquipGear(GearSlot slot, Equipable equipable)
        {
            if (equipable.SlotType == slot.SlotType)
            {
                if (slot.Equipable != null)
                {
                    Inventory.AddItem(slot.Equipable);
                }
                slot.Equipable = equipable;
                Inventory.Items.Remove(equipable);
                EquipedGear[slot] = equipable;
            }
            else
            {
                Console.WriteLine($"You can not fit {equipable.SlotType} to {slot.SlotType} slot!");
            }
        }

        public void UnEquipGear(GearSlot slot)
        {
            if (slot.Equipable != null) 
            {
                Inventory.AddItem(slot.Equipable);
                slot.Equipable = null;
                EquipedGear[slot] = null;
            }
        }

        public void UseItem(Item item)
        {
            item.UseItem(this);
        }
                
        public int CalculateTotalDamage()
        {
            var totalDamage = 0;
            var strength = 0;
            
            foreach(var item in EquipedGear)
            {
                if(item.Value != null)
                {
                    if (item.Key.SlotType == Equipable.GearSlotType.WEAPON)
                    {
                        var weapon = item.Value as EquipableWeapon;
                        totalDamage += weapon.Damage;
                    }
                    else
                    {
                        var strengthItem = item.Value as Equipable;
                        strength += strengthItem.StrengthBonus;
                    }
                }
            }

            totalDamage *= (1 + strength / 10);
            Strength = strength;
            return totalDamage;
        }

        public int CalculateDefense()
        {
            var totalArmor = 0;
            foreach (var item in EquipedGear)
            {
                if (item.Key.SlotType != Equipable.GearSlotType.WEAPON && item.Key.SlotType != Equipable.GearSlotType.RING)
                {
                    var armor = item.Value as EquipableArmor;
                    totalArmor += armor.ArmorValue;
                }
            }
            return totalArmor;
        }
    }
}
