using Game;

Console.Write("Enter your name: ");

// Vytvoření objektů zbraní a jídla
Weapon sword = new Weapon("Sword", 10, 3);
Weapon bow = new Weapon("Bow", 6, 2);
Weapon dagger = new Weapon("Dagger", 3, 1);
Weapon mace = new Weapon("Mace", 11, 4);
Food bread = new Food("Bread", 1, 10);

// Vytvoření objektů herních postav player a enemy. Při vytvoření těchto postav se s nimi vytvoří i jejich inventáře
Player player = new Player(Console.ReadLine()??"Player", 10, 100, baseDamage: 1);
Player enemy = new Player("Enemy", 10, 100, baseDamage: 1);

// Přiřazení vytvořených objektů zbraní a jídla do inventářů
player.Inventory.AddItem(sword);
player.Inventory.AddItem(bow);
enemy.Inventory.AddItem(dagger);
enemy.Inventory.AddItem(mace);
player.Inventory.AddItem(bread);

// Nasazení zbraní na postavy (přesun z inventáře na postavu)
// Nyní možnost přes dvě metody (nutno vyřešit)
//mace.EquipItem(enemy);
player.EquipWeapon(sword);
player.UnEquipWeapon();
player.EquipWeapon(bow);

// Výpis charakteristik postav a výbavy
Console.WriteLine($"\nYour hero: {player.Name}\nHitPoints: {player.Hitpoint}\nEquiped weapon: {player.EquipedWeapon?.Name}\nWeight: XXXXXX/{player.MaxWeight}");
Console.WriteLine($"\nYour enemy: {enemy.Name}\nHitPoints: {enemy.Hitpoint}\nEquiped weapon: {enemy.EquipedWeapon?.Name}");
Console.WriteLine("\nFIGHT!");
Console.ReadLine();

// Smyčka boje
while (player.Hitpoint > 0 && enemy.Hitpoint > 0)
{
    player.Attack(enemy);
    Console.WriteLine($"{player.Name} attacks for {player.TotalDamage} damage. {enemy.Name} have {enemy.Hitpoint} hitpoints left.");
    Console.ReadLine();
    if (enemy.Hitpoint >= 1)
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
        consumable?.UseItem();  //metoda zatím není implementována
        if(consumable == null)
        {
            Console.WriteLine("Item not exist");
        }
        //player.UnEquipWeapon(player.EquipedWeapon);
        Console.Write($"After consuming bread, {player.Name} have {player.Hitpoint} hitpoints");
        if (player.EquipedWeapon == null)
            Console.Write(" and have no weapon equiped");
        else
            Console.Write($" and have {player.EquipedWeapon.Name} equiped.");
    }
}

Console.ReadLine();
        