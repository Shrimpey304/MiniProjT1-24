namespace SpiderSlayers;

public class Quest{

    public int ?ID{get; set;}
    public string ?QuestName{get; set;}
    public string ?QuestDescription{get; set;}

    public Quest(int id, string name, string desc){
        ID = id;
        QuestName = name;
        QuestDescription = desc;
    }


    public static void hi(){
        Console.WriteLine("afafa");
    }
}