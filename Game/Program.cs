using Game;

Console.Write("Enter your name: ");

// Instantiate Weapon and Food classes
Weapon sword = new("Sword", 10, 3);
Weapon bow = new("Bow", 6, 2);
Weapon dagger = new("Dagger", 3, 1);
Weapon mace = new("Mace", 11, 4);
Food bread = new("Bread", 1, 10);

// Instantiate Player classes. Inventory classes are instantiated within Player class
Player player = new(Console.ReadLine()??"Player", 10, 100, strength: 1);
Player enemy = new("Enemy", 10, 100, strength: 1);

// Assign created weapons and food to inventories of created players
player.Inventory.AddItem(sword);
player.Inventory.AddItem(bow);
player.Inventory.AddItem(bread);
enemy.Inventory.AddItem(dagger);
enemy.Inventory.AddItem(mace);

// Equip weapons on players
player.EquipWeapon(sword);
enemy.EquipWeapon(dagger);

// Write in console stats of both players
Console.WriteLine($"\nYour hero: {player.Name}\nHitPoints: {player.Hitpoint}\nEquiped weapon: {player.EquipedWeapon?.Name}\nTotal damage: {player.TotalDamage}\nWeight: XXXXXX/{player.MaxWeight}");
Console.WriteLine($"\nYour enemy: {enemy.Name}\nHitPoints: {enemy.Hitpoint}\nEquiped weapon: {enemy.EquipedWeapon?.Name}");
Console.WriteLine("\nFIGHT!");
Console.ReadLine();

// Battle loop
while (player.Hitpoint > 0 && enemy.Hitpoint > 0)
{
    player.DealDamage(enemy);
    Console.WriteLine($"{player.Name} attacks for {player.TotalDamage} damage. {enemy.Name} have {enemy.Hitpoint} hitpoints left.");
    Console.ReadLine();
    if (enemy.Hitpoint >= 1)
    {
        enemy.DealDamage(player);
        Console.WriteLine($"{enemy.Name} attacks for {enemy.TotalDamage} damage. {player.Name} have {player.Hitpoint} hitpoints left.");
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
        player.UnEquipWeapon();
        player.Inventory.DestroyItem(sword);
        Console.Write($"After consuming bread, {player.Name} have {player.Hitpoint} hitpoints");
        if (player.EquipedWeapon == null)
            Console.Write(" and have no weapon equiped");
        else
            Console.Write($" and have {player.EquipedWeapon.Name} equiped.");
    }
}

Console.ReadLine();
        