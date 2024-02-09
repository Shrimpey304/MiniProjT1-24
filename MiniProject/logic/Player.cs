namespace SpiderSlayers;

public class Player{

    public int PlayerLevel {get; set;}
    public int PlayerMapPosition {get; set;} //Location ID
    public List<Item> ?inventory {get; set;}

    public Player(){

        PlayerLevel = 1;
        PlayerMapPosition = 1;
        inventory = new();
        
    }

}