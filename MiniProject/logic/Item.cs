namespace SpiderSlayers;

public class Item{

    public int ?ID{get; set;}
    public string ?ItemName{get; set;}
    public string ?ItemDescription{get; set;}


    public Item(int id, string name, string desc){
        ID = id;
        ItemName = name;
        ItemDescription = desc;
    }

}