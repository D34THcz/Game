using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Consumable : Item
    {
        public abstract int HitpointsRecovered { get; set; }
    }
}
