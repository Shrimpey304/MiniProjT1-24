namespace SpiderSlayers;

public class CountedItem
{
    public Item Item { get; set; }
    public int Count { get; set; }

    public CountedItem(Item item)
    {
        Item = item;
        Count = 0;
    }
}