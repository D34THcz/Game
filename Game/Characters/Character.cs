using Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters
{
	public class Character
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int HP { get; set; }

		public Dictionary<int, Equipment> Equipment { get; set; }

		public Character(int id, string name, int hp)
		{
			Id = id;
			Name = name;
			HP = hp;
			Equipment = new Dictionary<int, Equipment>();
		}

		public int CalculateDamage()
		{
			var damage = 0;
			foreach (var item in Equipment)
			{
				damage += item.Value.DamageModifier;
			}

			Random random = new();
			damage = random.Next(damage - damage/5, damage + damage/5);

			return damage;
		}

		public bool EquipItem(Equipment equipment)
		{
			if (Equipment.ContainsKey((int)equipment.Type))
			{
				return false;
			}

			Equipment.Add((int)equipment.Type, equipment);
			return true;
		}

		public int ReceiveDamage(int damage)
		{
			var armor = 0;
			foreach (var item in Equipment)
			{
				armor += item.Value.ArmorModifier;
			}
			int damageReceived = damage - armor;

			// Cannot go under 1 damage
			if (damageReceived < 1)
			{
				damageReceived = 1;
			}

			HP -= damageReceived;

			return (int)damageReceived;
		}

		public bool UnequipItem(Equipment equipment)
		{
			if (Equipment.ContainsKey((int)equipment.Type))
			{
				return false;
			}

			Equipment.Remove((int)equipment.Type);
			return true;
		}

		public string EquipmentToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Character {Name} equipment:");
			foreach (var item in Equipment)
			{
				var equipedItem = item.Value;
				sb.AppendLine($"{equipedItem.Type} - {equipedItem.Name} Attack: {equipedItem.DamageModifier} Armor: {equipedItem.ArmorModifier}");
			}

			return sb.ToString();
		}
	}
}
