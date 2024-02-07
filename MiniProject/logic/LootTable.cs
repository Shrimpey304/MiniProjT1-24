namespace SpiderSlayers;

public class LootTable
{
    public List<Item> Items { get; set; }

    public LootTable()
    {
        Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }
}