namespace Game
{
    public abstract class Equipable : Item
    {
        public enum GearSlotType { HELM, CHEST, LEGS, WEAPON, RING }
        public abstract GearSlotType SlotType { get; set; }
        public virtual int StrengthBonus { get; set; } = 0;
    }
}
