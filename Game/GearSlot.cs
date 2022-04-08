namespace Game
{
    public class GearSlot
    {
        public Equipable? Equipable { get; set; }
        public Equipable.GearSlotType SlotType { get; set; }

        public GearSlot(Equipable.GearSlotType slotType)
        {
            SlotType = slotType;
        }

        public override string ToString()
        {
            return SlotType.ToString();
        }
    }
}
