namespace Game
{
    public abstract class EquipableAccessory : Equipable
    {
        
        public override GearSlotType SlotType { get; set; }

        protected EquipableAccessory()
        {
            SlotType = GearSlotType.RING;
        }
    }
}
