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
        public override int Strength { get; set; }
        public override int MaxWeight { get; set; }
        public override Inventory Inventory { get; set; }
        public override GearSlot EquipedHelm { get; set; }
        public override GearSlot EquipedChest { get; set; }
        public override GearSlot EquipedLegs { get; set; }
        public override GearSlot EquipedWeapon { get; set; }
        public override GearSlot EquipedRingLeft { get; set; }
        public override GearSlot EquipedRingRight { get; set; }
        public override Dictionary<GearSlot, Equipable?> EquipedGear { get; set; }

        public Player(string name, int hitpoint, int maxWeight, int strength = 1)
        {
            Name = name;
            Hitpoint = hitpoint;
            Strength = strength;
            Inventory = new Inventory();
            MaxWeight = maxWeight;
            EquipedHelm = new(Equipable.GearSlotType.HELM);
            EquipedChest = new(Equipable.GearSlotType.CHEST);
            EquipedLegs = new(Equipable.GearSlotType.LEGS);
            EquipedWeapon = new(Equipable.GearSlotType.WEAPON);
            EquipedRingLeft = new(Equipable.GearSlotType.RING);
            EquipedRingRight = new(Equipable.GearSlotType.RING);
            EquipedGear = new();
        }
    }
}
