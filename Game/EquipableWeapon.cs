namespace Game
{
    public abstract class EquipableWeapon : Equipable
    {
        public abstract int Damage { get; set; }
        
        public override GearSlotType SlotType { get ; set; }
        
        protected EquipableWeapon()
        {
            SlotType = GearSlotType.WEAPON;
        }
    }
}
