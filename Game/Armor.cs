namespace Game
{
    internal class Armor : Equipable
    { 
        public override string Name { get; set; }
        public override int Id { get; set; }
        private static int _id = 0;
        public override int Weight { get; set; }
        public override EquipmentType Type { get; set; }
        public override int DamageModifier { get; set; }
        public override int ArmorModifier { get; set; }

        public Armor(string name, int weight, int armorModifier, int damageModifier, EquipmentType equipmentType)
        {
            Name = name;
            Id = _id + 1;
            _id += 1;
            Weight = weight;
            ArmorModifier = armorModifier;
            DamageModifier = damageModifier;
            Type = equipmentType;
        }

        public override void UseItem(Character character)
        {
            
        }
    }
}
