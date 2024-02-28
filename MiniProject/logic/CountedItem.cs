namespace SpiderSlayers;

public class CountedItem
{
    public Item Item { get; set; }
    public int Count { get; set; }

    public CountedItem(Item item, int count)
    {
        Item = item;
        Count = count;
    }
}