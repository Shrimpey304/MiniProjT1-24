namespace SpiderSlayers;

public class Player{

    public int PlayerLevel {get; set;}
    public int PlayerMapPosition {get; set;} //Location ID
    public Inventory inventory = new Inventory();
    public int HP { get; set; }

    public Player(){

        PlayerLevel = 1;
        PlayerMapPosition = 1;
        HP = 90 + (PlayerLevel * 10);
    }

    public void RegenerateHP()
    {
        if (PlayerMapPosition == World.LOCATION_ID_HOME)
        { 
            HP = 90 + (PlayerLevel * 10);
        }
    }

}