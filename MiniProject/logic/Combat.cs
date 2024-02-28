using SpiderSlayers;
using System;

public class Combat
{
    static Location currentPlayerLocation = World.LocationByID(WorldInit.player.PlayerMapPosition); //get location
    static Monster LoadMonster = currentPlayerLocation.MonsterLivingHere;

    public void CheckForMonster()
    {
        if(currentPlayerLocation.MonsterLivingHere !=null)
        {
            Console.WriteLine($"{LoadMonster.MonsterName}'s have apeard. select fight.");
        }
    }
}