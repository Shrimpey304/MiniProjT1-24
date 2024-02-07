using System.Runtime.Intrinsics.Arm;

namespace SpiderSlayers;

public class Quest{

    public int ?ID{get; set;}
    public string ?QuestName{get; set;}
    public string ?QuestDescription{get; set;}
    public int something1{get; set;}
    public int something2{get; set;}
    public Item QuestRequired{get; set;}
    public Weapon QuestReward{get; set;}
    public List<CountedItem> QuestCompletionItems { get; private set; }


    public Quest(int id, string name, string desc, int s1, int s2, Item Qrequired, Weapon Qreward){
        ID = id;
        QuestName = name;
        QuestDescription = desc;
        something1 = s1;
        something2 = s2;
        QuestRequired = Qrequired;
        QuestReward = Qreward;
        QuestCompletionItems = new List<CountedItem>();
    }

    public static void hi(){
        Console.WriteLine("afafa");
    }
}

public static class CountedItemExtension
{
    public static void AddCountedItem(this List<CountedItem> questCompletionItems, CountedItem item)
    {
        questCompletionItems.Add(item);
    }
}