namespace SpiderSlayers;

public class Inventory{
    public List<Item> Items = new List<Item>() {};
    public List<CountedItem> Stackables = new List<CountedItem>() {};
    public int Gold;

    public Inventory(){
        this.Gold = 0;
    }
}
// BLABLA