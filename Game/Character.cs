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
        public abstract int BaseDamage { get; set; }  
        public abstract EquipableWeapon EquipedWeapon { get; set; }
        public abstract Inventory Inventory { get; set; }
        public int TotalDamage { get; set; }

        public virtual void Attack(Character targetCharacter)
        {
            targetCharacter.Hitpoint -= this.TotalDamage;
        }
        
    }
}
