using SpiderSlayers;

public class Equip
{

    public void Equip_item()
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

}
