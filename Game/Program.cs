using Game;

Console.Write("Enter your name: ");

// Vytvoření objektů herních postav player a enemy. Při vytvoření těchto postav se s nimi vytvoří i jejich inventáře
Player player = new Player(Console.ReadLine(), 10, baseDamage: 1);
Player enemy = new Player("Enemy", 10, baseDamage: 1);

// Vytvoření objektů zbraní a jídla. Objekty se vytvoří přímo v inventářích zvolených postav
Weapon sword = new Weapon(player.Inventory, "Sword", 10, 3);
Weapon dagger = new Weapon(enemy.Inventory, "Dagger", 3, 1);
Food bread = new Food(player.Inventory, "Bread", 1, 10);

// Nasazení zbraní na postavy (přesun z inventáře na postavu)
dagger.EquipItem();
sword.EquipItem();

// Výpis charakteristik postav a výbavy
Console.WriteLine($"\nYour hero: {player.Name}\nHitPoints: {player.Hitpoint}\nEquiped weapon: {player.EquipedWeapon.Name}");
Console.WriteLine($"\nYour enemy: {enemy.Name}\nHitPoints: {enemy.Hitpoint}\nEquiped weapon: {enemy.EquipedWeapon.Name}");
Console.WriteLine("\nFIGHT!");
Console.ReadLine();

// Smyčka boje
while (player.Hitpoint > 0 && enemy.Hitpoint > 0)
{
    player.Attack(enemy);
    Console.WriteLine($"{player.Name} attacks for {player.TotalDamage} damage. {enemy.Name} have {enemy.Hitpoint} hitpoints left.");
    Console.ReadLine();
    if (enemy.Hitpoint > 1)
    {
        enemy.Attack(player);
        Console.WriteLine($"{enemy.Name} attacks for {enemy.TotalDamage} damage. {player.Name} have {player.Hitpoint} hitpoints left.");
        Console.ReadLine();

        if (player.Hitpoint < 1)
            Console.WriteLine($"{enemy.Name} WINS");
    }
    else
    {
        // Pokud vyhraje hráč, automaticky se po boji spotřebuje jídlo z inventáře, tím se doplní Hitpointy a dále se sundá zbraň z postavy do inventáře                    
        Console.WriteLine($"{player.Name} WINS with {player.Hitpoint} hitpoints left. Consuming bread...");
        var consumable = player.Inventory.Items.Find(x => x.Name == "Bread");
        consumable.UseItem();
        player.EquipedWeapon.UnEquipItem();
        Console.Write($"After consuming bread, {player.Name} have {player.Hitpoint} hitpoints");
        if (player.EquipedWeapon is null)
            Console.Write(" and have no weapon equiped");
        else
            Console.Write($" and have {player.EquipedWeapon} equiped");
    }
}
Console.ReadLine();
        