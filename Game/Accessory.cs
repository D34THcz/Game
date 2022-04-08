namespace Game
{
    public class Accessory : EquipableAccessory
    {
        public override string Name { get; set; }
        public override int Id { get; set; }
        private static int _id = 0;
        public override int Weight { get; set; }
        public override GearSlotType SlotType { get; set; }

        public Accessory(string name, int weight, int strengthBonus)
        {
            Name = name;
            Id = _id + 1;
            _id += 1;
            Weight = weight;
            StrengthBonus = strengthBonus;
        }

        public override void UseItem(Character character)
        {

        }
    }
}
