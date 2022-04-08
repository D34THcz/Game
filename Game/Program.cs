using Game;

Console.Write("Enter your name: ");

// Instantiate Weapon, Armor and Food classes
Weapon sword = new("Sword", 10, 3);
Weapon bow = new("Bow", 6, 1);
Weapon dagger = new("Dagger", 3, 1);
Weapon mace = new("Mace", 11, 4);
Armor lightArmor = new("Light chestplate", 20, 2,Equipable.GearSlotType.CHEST, 20);
Armor heavyArmor = new("Heavy chestplate", 40, 5, Equipable.GearSlotType.CHEST, 25);
Armor helm = new("Iron helm", 15, 2, Equipable.GearSlotType.HELM, 10);
Accessory ring1 = new("Ring of war", 1, 15);
Accessory ring2 = new("Ring of strength", 1, 20);
Food bread = new("Bread", 1, 10);

// Instantiate Player classes. Inventory classes are instantiated within Player class
Player player = new(Console.ReadLine()??"Player", 10, 100, strength: 1);
Player enemy = new("Enemy", 10, 100, strength: 1);

// Assign created weapons, armor and food to inventories of created players
player.Inventory.AddItem(sword);
player.Inventory.AddItem(bow);
player.Inventory.AddItem(bread);
player.Inventory.AddItem(heavyArmor);
player.Inventory.AddItem(helm);
player.Inventory.AddItem(ring1);
player.Inventory.AddItem(ring2);
enemy.Inventory.AddItem(dagger);
enemy.Inventory.AddItem(mace);
enemy.Inventory.AddItem(lightArmor);

// Equip weapons on players
enemy.EquipGear(enemy.EquipedWeapon, dagger);
player.EquipGear(player.EquipedWeapon, sword);
player.EquipGear(player.EquipedChest, lightArmor);
player.EquipGear(player.EquipedHelm, helm);
player.EquipGear(player.EquipedRingLeft, ring1);
player.EquipGear(player.EquipedRingRight, ring2);
player.UnEquipGear(player.EquipedRingRight);

// Write in console stats of both players
Console.WriteLine($"\nYour hero: {player.Name}\nHitPoints: {player.Hitpoint}\nStrength: {player.Strength}\nEquiped weapon: {player.EquipedWeapon?.Equipable?.Name}\nEquiped armor: {player.EquipedChest?.Equipable?.Name}\nTotal damage: {player.TotalDamage}\nDefense: {player.Defense}\nWeight: XXXXXX/{player.MaxWeight}");
Console.WriteLine($"\nYour enemy: {enemy.Name}\nHitPoints: {enemy.Hitpoint}\nStrength: {enemy.Strength}\nEquiped weapon: {enemy.EquipedWeapon?.Equipable?.Name}\nEquiped armor: {enemy.EquipedChest?.Equipable?.Name}\nTotal damage: {enemy.TotalDamage}\nDefense: {enemy.Defense}\nWeight: XXXXXX/{enemy.MaxWeight}");
Console.WriteLine("\nFIGHT!");
Console.ReadLine();

// Battle loop
while (player.Hitpoint > 0 && enemy.Hitpoint > 0)
{
    player.DealDamage(enemy);
    Console.WriteLine($"{player.Name} attacks for {player.TotalDamage} damage - {enemy.Name}'s {enemy.Defense} armor value. {enemy.Name} have {enemy.Hitpoint} hitpoints left.");
    Console.ReadLine();
    if (enemy.Hitpoint >= 1)
    {
        enemy.DealDamage(player);
        Console.WriteLine($"{enemy.Name} attacks for {enemy.TotalDamage} damage - {player.Name}'s {player.Defense} armor value. {player.Name} have {player.Hitpoint} hitpoints left.");
        Console.ReadLine();

        if (player.Hitpoint < 1)
            Console.WriteLine($"{enemy.Name} WINS");
    }
    else
    {
        // If main player wins, he will consume bread recovering him hitpoints. Then his weapon is unequiped and destroyed
        Console.WriteLine($"{player.Name} WINS with {player.Hitpoint} hitpoints left. Consuming bread...");
        var consumable = player.Inventory.Items.Find(x => x.Name == "Bread");
        if(consumable == null)
            Console.WriteLine("Item not exist");
        else
            player.UseItem(consumable);
        player.UnEquipGear(player.EquipedWeapon);
        Console.Write($"After consuming bread, {player.Name} have {player.Hitpoint} hitpoints");
        if (player.EquipedWeapon.Equipable == null)
            Console.Write(" and have no weapon equiped");
        else
            Console.Write($" and have {player.EquipedWeapon.Equipable.Name} equiped.");
    }
}
Console.ReadLine();        