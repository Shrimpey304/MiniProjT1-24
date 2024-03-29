using System.Security.Principal;

namespace SpiderSlayers;

public class Inventory{
    public List<Item> Items = new List<Item>() {};
    public List<CountedItem> Stackables = new List<CountedItem>() {};
    public List<Weapon> WeaponInventory = new();
    public int Gold;

    public Inventory(){
        this.Gold = 0;
    }

    public void AddItem(Item item){
        this.Items.Add(item);
    }

    public void AddStackable(Item addingItem, int amount)
    {
        bool found = false;

        foreach (CountedItem listItem in Stackables)
        {
            if (listItem.Item.ItemName == addingItem.ItemName)
            {
                listItem.Count += amount;
                found = !found;
                break; // gaat eruit als item in inventory zit
            }
        }

        if (!found) // als item nog niet in inventory zit
        {
            Stackables.Add(new CountedItem(addingItem, amount)); //maakt nieuw item aan
        }
    }

    public void AddGold(int amount)
    {
        this.Gold += amount;
    }

    public void ShowInv()
    {
        Console.WriteLine($"Gold: {this.Gold}");

        Console.WriteLine("Weapons:");
        int counter = 0;
        foreach (Weapon weapon in WeaponInventory)
        {
            Console.WriteLine($"[{++counter}] - {weapon.WeaponName} ({weapon.WeaponDescription})");
        }

        Console.WriteLine("\n-------------------\nGear:");
        counter = 0;
        foreach (Item item in Items)
        {
            Console.WriteLine($"[{++counter}] - {item.ItemName} ({item.ItemDescription})");
        }

        Console.WriteLine("\n-------------------\nMiscellaenious items:");
        counter = 0;
        foreach (CountedItem stackable in Stackables)
        {
            Console.WriteLine($"[{++counter}] - {stackable.Count}x {stackable.Item.ItemName} ({stackable.Item.ItemDescription})");
        }
    }
}
