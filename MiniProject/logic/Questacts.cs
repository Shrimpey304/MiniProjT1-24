using SpiderSlayers;
using System;

public class StartQuests
{
    public void CheckAndStartQuest()
    {
        int currentPlayerLocationID = WorldInit.player.PlayerMapPosition; //get player current postion 
        Location currentPlayerLocation = World.LocationByID(currentPlayerLocationID); //get location
        
        if (currentPlayerLocation.QuestAvailableHere != null)
        {
             Console.WriteLine($"Quest available: {currentPlayerLocation.QuestAvailableHere.QuestName}");
             Console.WriteLine("ahhhdsgkjadfbg");
        }
    }

}
