using Game;

// Get player's name
Console.Write("Enter your name: ");
var playerName = Console.ReadLine();
if (string.IsNullOrEmpty(playerName))
    playerName = "Player";

// Instantiate Weapon, Amor and Food classes
Weapon sword = new("Sword", 10, 4,0);
Weapon bow = new("Bow", 6, 2,0);
Weapon dagger = new("Dagger", 3, 1,0);
Weapon mace = new("Mace", 11, 4,0);
Armor lightArmor = new("Light armor", 20, 3,0, Equipable.EquipmentType.CHEST);
Armor heavyArmor = new("Heavy armor", 40, 2,0, Equipable.EquipmentType.CHEST);
Food bread = new("Bread", 1, 10);

// Instantiate Player classes. Inventory classes are instantiated within Player class
Player player = new(playerName, 10, 100, strength: 1);
Player enemy = new("Enemy", 10, 100, strength: 1);

// Assign created weapons, armor and food to inventories of created players
player.Inventory.AddItem(sword);
player.Inventory.AddItem(bow);
player.Inventory.AddItem(bread);
player.Inventory.AddItem(heavyArmor);
enemy.Inventory.AddItem(dagger);
enemy.Inventory.AddItem(mace);
enemy.Inventory.AddItem(lightArmor);

// Equip weapons on players
player.EquipGear(sword);
player.EquipGear(heavyArmor);
enemy.EquipGear(dagger);
enemy.EquipGear(lightArmor);

// Write in console stats of both players
Console.WriteLine(player.PrintCharacterStats());
Console.WriteLine(enemy.PrintCharacterStats());
Console.ReadLine();

// Battle loop
CombatManager combatManager = new(player, enemy);
combatManager.StartCombat();

Console.ReadLine();
        