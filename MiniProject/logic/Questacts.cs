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

            foreach(CountedItem invCounted in WorldInit.player.inventory.Stackables)
                Console.WriteLine($"Requires: {item.Item.ItemName} {invCounted.Count}/{item.Count}"); // add item inventory

        }

    }

}
