using Game;
using Game.Characters;
using Game.Items;
using Game.Managers;

Console.Write("Enter your name: ");
var playerName = Console.ReadLine();

Player player = new(0, playerName, 100);
Enemy enemy = new(1, "Enemy", 100);

// Init items
Equipment sword = new(0, "Sword", 10, Equipment.EquipmentType.WEAPON, 20, 0);
Equipment dagger = new(1, "Dagger", 10, Equipment.EquipmentType.WEAPON, 10, 0);

Equipment leatherChest = new(2, "Leather Chest", 10, Equipment.EquipmentType.CHEST, 0, 3);
Equipment ironChest = new(3, "Iron Chest", 10, Equipment.EquipmentType.CHEST, 0, 7);

Equipment leatherHelm = new(2, "Leather Chest", 10, Equipment.EquipmentType.HELM, 0, 1);
Equipment ironHelm = new(3, "Iron Chest", 10, Equipment.EquipmentType.HELM, 0, 3);

player.EquipItem(sword);
player.EquipItem(dagger); // Shouldn't equip
player.EquipItem(leatherChest);
player.EquipItem(leatherHelm);

enemy.EquipItem(dagger);
enemy.EquipItem(ironChest);
enemy.EquipItem(ironHelm);

Console.WriteLine(player.EquipmentToString());
Console.WriteLine(enemy.EquipmentToString());

CombatManager combat = new(player, enemy);

combat.StartFight();
Console.ReadLine();