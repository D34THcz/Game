using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Item 
    {
        public abstract string Name { get; set; }
        public abstract int Id { get; set; }
        public abstract int Weight { get; set; }

        public abstract void UseItem(Character character);
    }
}
