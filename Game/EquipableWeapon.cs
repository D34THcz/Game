using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class EquipableWeapon : Equipable
    {
        public abstract int Damage { get; set; }
    }
}
