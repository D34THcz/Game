using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
	public class Equipment : Item
	{
		public enum EquipmentType
		{
			HELM = 0,
			CHEST = 1,
			LEGS = 2,
			WEAPON = 3,
			RING = 4,
		}

		public EquipmentType Type;
		public int DamageModifier { get; set; }
		public int ArmorModifier { get; set; }

		public Equipment(int id, string name, int weight, EquipmentType type, int damage, int armor) : base(id, name, weight)
		{
			Type = type;
			DamageModifier = damage;
			ArmorModifier = armor;
		}
	}
}
