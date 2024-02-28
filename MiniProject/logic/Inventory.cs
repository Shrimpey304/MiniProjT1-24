using System.Security.Principal;

namespace SpiderSlayers;

public class Inventory{
    public List<Item> Items = new List<Item>() {};
    public List<CountedItem> Stackables = new List<CountedItem>() {};
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
                break;
            }
        }

        if (!found)
        {
            Stackables.Add(new CountedItem(addingItem));
            foreach (CountedItem listItem in Stackables)
            {
                if (listItem.Item.ItemName == addingItem.ItemName)
                {
                    listItem.Count += amount;
                    break;
                }
            }
        }
    }

    public void AddGold(int amount)
    {
        this.Gold += amount;
    }
}
