namespace SpiderSlayers;

public class WorldInit{

    public void TestStart(){
        GetLocationCompass(World.LocationByID(2));
    }

    public void GetLocationCompass(Location location){

        
        string North = "\tN\n\t|\n\t|\n\t|";
        string West = "W------";
        string East = "------E";
        string South = "\t|\n\t|\n\t|\n\tS";
        
        Tuple<string, string, string, string> Compass = Tuple.Create<string, string, string, string>(null!, null!, null!, null!);

        if (location.LocationToNorth is not null){
            Compass = Tuple.Create(North, Compass.Item2, Compass.Item3, Compass.Item4);
        }

        if (location.LocationToWest is not null){
            Compass = Tuple.Create(Compass.Item1, West, Compass.Item3, Compass.Item4);
        }

        if (location.LocationToEast is not null){
            Compass = Tuple.Create(Compass.Item1, Compass.Item2, East, Compass.Item4);
        }

        if (location.LocationToSouth is not null){
            Compass = Tuple.Create(Compass.Item1, Compass.Item2, Compass.Item3, South);
        }

        Console.WriteLine($"{Compass.Item1}");
        Console.WriteLine($"{Compass.Item2}   {Compass.Item3}");
        Console.WriteLine($"{Compass.Item4}");

    }

}