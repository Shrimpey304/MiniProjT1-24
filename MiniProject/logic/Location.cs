namespace SpiderSlayers;

public class Location{

    public int ID{get; set;}
    public string ?LocationName{get; set;}
    public string ?LocationDescription{get; set;}
    public Item ?LocationRequiredItem{get; set;}
    public string ?something1{get; set;}
    public string ?something2{get; set;}
    public Dictionary<string, Action> optionsAndActions {get; set;}
    public Quest ?QuestAvailableHere;
    public bool QuestAccepted;
    public Monster ?MonsterLivingHere;
    public Location ?LocationToNorth;
    public Location ?LocationToSouth;
    public Location ?LocationToEast;
    public Location ?LocationToWest;


    public Location(int id, string name, string desc, Item reqItem, string s1, string s2){
        ID = id;
        LocationName = name;
        LocationDescription = desc;
        LocationRequiredItem = reqItem;
        something1 = s1;
        something2 = s2;
        optionsAndActions = new Dictionary<string, Action>();
        QuestAccepted = false;
    }
}