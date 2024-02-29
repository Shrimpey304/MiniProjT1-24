using SpiderSlayers;

public static class Equip
{

    public static Item SelectedItem;
    public static Weapon SelectedWeapon;


    public static void Equip_item()
    {

        Console.WriteLine("What item do you want to equip? ");
        // string equiped_request = Console.ReadLine();
        int counter = 0;
        foreach (Item item in World.player.inventory.Items)
        {

            Console.WriteLine($"[{++counter}] - {item.ItemName}");
        }
        string user_input = Console.ReadLine();
        try{

            int user_input_Converted = Convert.ToInt32(user_input);
            Item SelectedItems = World.player.inventory.Items[user_input_Converted - 1];

        }catch(Exception e){
            Console.WriteLine("invalid input");
            Thread.Sleep(2000);
            Equip_item();
        }

    }

    public static Weapon SelectedItems;

    public static void Equip_Weapon()
    {
        
        Console.WriteLine("What item do you want to equip? ");

        // string equiped_request = Console.ReadLine();
        int counter = 0;
        foreach (Weapon weapon in WorldInit.player.inventory.WeaponInventory)
        {

            Console.WriteLine($"[{++counter}] - {weapon.WeaponName}");
        }
        string user_input = Console.ReadLine();
        try{

            int user_input_Converted = Convert.ToInt32(user_input);
            SelectedItems = WorldInit.player.inventory.WeaponInventory[user_input_Converted - 1];
            
        }catch(Exception e){
            Console.WriteLine("invalid input");
            Thread.Sleep(2000);
            Equip_Weapon();
        }

    }

}
