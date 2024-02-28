using SpiderSlayers;
using System;

public class StartQuests
{

    static Location currentPlayerLocation = World.LocationByID(WorldInit.player.PlayerMapPosition); //get location
    static Quest ThisQuest = currentPlayerLocation.QuestAvailableHere;


    public void CheckAndStartQuest()
    {
        
        if (currentPlayerLocation.QuestAvailableHere != null)
        {
            Console.WriteLine($"Quest available: {ThisQuest.QuestName}");
            Thread.Sleep(5000);
            currentPlayerLocation.QuestAccepted = true;
        }
    }


    public void ShowQuest(){

        Console.WriteLine($"{ThisQuest.QuestName}: {ThisQuest.QuestDescription}");
        foreach(CountedItem item in ThisQuest.QuestCompletionItems){

            Console.WriteLine($"Requires: {item.Item.ItemName} "); // add item inventory

        }

    }

}
