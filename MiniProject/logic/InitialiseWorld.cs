using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SpiderSlayers;

public static class WorldInit
    {
        public static Player player = new();

        public static void Start()
        {
            TransferPlayer(player);

            Location currentLocation = World.LocationByID(World.player.PlayerMapPosition);
            foreach (Weapon weapon in World.Weapons){

                if (weapon.WeaponName == "Fists" && !player.inventory.WeaponInventory.Contains(weapon)){

                    World.player.inventory.WeaponInventory.Add(weapon);
                }

            }
            RunCheckboxMenu(currentLocation.optionsAndActions);
        }

        public static void TransferPlayer(Player player){
            World.TransferPlayer(player);
        }

        public static void openInventory()
        {
            Console.WriteLine("opened inv");
            player.inventory.ShowInv();
        }

        private static Random randomGenerator = new Random();

        public static Weapon equipedWeapon;
        public static void Fight()
        {
            if(World.LocationByID(World.player.PlayerMapPosition).MonsterLivingHere is not null){
    
                Monster currentMonster = World.LocationByID(World.player.PlayerMapPosition).MonsterLivingHere;
                Equip.Equip_Weapon();

                equipedWeapon = Equip.SelectedItems;

                while(currentMonster.MonsterHP >= 0){

                //get damage values
                int playerDamage = randomGenerator.Next(equipedWeapon.WeaponMinDamage, equipedWeapon.WeaponMaxDamage + 1);
                int monsterDamage = randomGenerator.Next(currentMonster.MonsterMinDamage, currentMonster.MonsterMaxDamage + 1);

                //take damage
                World.player.HP -= monsterDamage;
                currentMonster.MonsterHP -= playerDamage;

                //show damage
                if (playerDamage == 0){Console.WriteLine("You missed!");}
                Console.WriteLine($"Player deals {playerDamage} damage to the monster.");
                Console.WriteLine($"{currentMonster.MonsterName} {monsterDamage} damage to the player.");
                Console.WriteLine($"Your current HP: {WorldInit.player.HP}");
                Thread.Sleep(1500);

                //check for W or L

                    if (World.player.HP <= 0)
                    {
                        Console.WriteLine("YOU DIED, start over");
                        Thread.Sleep(6000);
                        World.QuitGame();
                    }
                    else if(currentMonster.MonsterHP <= 0)
                    {
                        player.inventory.AddGold(randomGenerator.Next(2, 5));

                        if (currentMonster.MonsterName == "rat")
                        {
                            bool weaponPresent = false;
                            foreach (Weapon weapon in player.inventory.WeaponInventory)
                            {
                                if (weapon.WeaponName == "Rusty sword")
                                {
                                    weaponPresent = true;
                                }
                            }
                            if (!weaponPresent)
                            {
                                player.inventory.WeaponInventory.Add(World.Weapons[0]);
                            }
                        }
                        else if (currentMonster.MonsterName == "snake")
                        {
                            bool weaponPresent = false;
                            foreach (Weapon weapon in player.inventory.WeaponInventory)
                            {
                                if (weapon.WeaponName == "Club")
                                {
                                    weaponPresent = true;
                                }
                            }
                            if (!weaponPresent)
                            {
                                player.inventory.WeaponInventory.Add(World.Weapons[1]);
                            }
                        }
                        else if (currentMonster.MonsterName == "giant spider")
                        {
                            bool weaponPresent = false;
                            foreach (Weapon weapon in player.inventory.WeaponInventory)
                            {
                                if (weapon.WeaponName == "Squire sword")
                                {
                                    weaponPresent = true;
                                }
                            }
                            if (!weaponPresent)
                            {
                                player.inventory.WeaponInventory.Add(World.Weapons[2]);
                            }
                        }

                        Console.WriteLine("enemy felt");
                        Thread.Sleep(3000);
                        RunCheckboxMenu(World.LocationByID(World.player.PlayerMapPosition).optionsAndActions);
                    }

                }

                Console.WriteLine($"Congrats you have defeated the {currentMonster.MonsterName}");
                Thread.Sleep(3000);
                RunCheckboxMenu(World.LocationByID(World.player.PlayerMapPosition).optionsAndActions);

            }else{

                Console.WriteLine("it seems there are no monsters here, you are safe");
                Thread.Sleep(3000);
                RunCheckboxMenu(World.LocationByID(World.player.PlayerMapPosition).optionsAndActions);

            }

        }


        public static void Run()
        {
            Console.WriteLine("ran away");
        }

        public static void GetLocationCompass(Location location)
        {
            string North = "\tN\n\t|\n\t|\n\t|";
            string West = "W------";
            string East = "------E";
            string South = "\t|\n\t|\n\t|\n\tS";

            Tuple<string, string, string, string> Compass = Tuple.Create<string, string, string, string>(null!, null!, null!, null!);

            if (location.LocationToNorth is not null)
            {
                Compass = Tuple.Create(North, Compass.Item2, Compass.Item3, Compass.Item4);
            }

            if (location.LocationToWest is not null)
            {
                Compass = Tuple.Create(Compass.Item1, West, Compass.Item3, Compass.Item4);
            }

            if (location.LocationToEast is not null)
            {
                Compass = Tuple.Create(Compass.Item1, Compass.Item2, East, Compass.Item4);
            }

            if (location.LocationToSouth is not null)
            {
                Compass = Tuple.Create(Compass.Item1, Compass.Item2, Compass.Item3, South);
            }

            Console.WriteLine($"{Compass.Item1}");
            Console.WriteLine($"{Compass.Item2}   {Compass.Item3}");
            Console.WriteLine($"{Compass.Item4}");
        }

        public static void TellPosition(Location location)
        {
            string currentLocationDesc = location.LocationDescription!;
            string currentLocationName = location.LocationName!;

            Console.WriteLine($"you have arrived in {currentLocationName}");
            Console.WriteLine($"{currentLocationDesc}");
        }

        static void RunCheckboxMenu(Dictionary<string, Action> optionsAndActions)
        {
            int selectedIndex = 0;
            List<string> options = new List<string>(optionsAndActions.Keys);
            bool[] selectedOptions = new bool[options.Count];

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Current Location: {World.LocationByID(World.player.PlayerMapPosition).LocationName}\n\n");

                Console.WriteLine("press 'enter' to select option");

                for (int i = 0; i < options.Count; i++)
                {
                    Console.Write(selectedIndex == i ? "[x] " : "[ ] ");
                    Console.WriteLine(options[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Count;
                        break;

                    case ConsoleKey.Enter:
                        PerformAction(optionsAndActions[options[selectedIndex]]);
                        break;
                }
            }
        }



        static void PerformAction(Action action)
        {
            Console.Clear();
            action.Invoke();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        

        public static void MoveCharacter(Location location){

            List<Location> Directions = new()
            {
                location.LocationToNorth,
                location.LocationToEast,
                location.LocationToSouth,
                location.LocationToWest
            };

            Dictionary<int, Location> LocationChoise = new();

            int optionsIndex = 0;

            Console.WriteLine("Travel to:");

            foreach(Location loc in Directions){
                if(loc is not null){
                    Console.WriteLine($"{optionsIndex + 1}: {loc.LocationName}");
                    LocationChoise.Add(optionsIndex +1, loc);
                    optionsIndex ++;
                }
            }
            player.RegenerateHP();

            Console.WriteLine("Where do you want to go");

            string inp = Console.ReadLine().Trim();
            int intInp;
            bool isOnlyNumber = int.TryParse(inp, out intInp);

            if(isOnlyNumber){
                if(LocationChoise.ContainsKey(intInp)){

                    Location selectedLoc = LocationChoise[intInp];
                    int selectedLocID = selectedLoc.ID;
                    player.PlayerMapPosition = selectedLocID;

                    Console.WriteLine($"Traveling to: {selectedLoc.LocationName}");
                    Thread.Sleep(2000);
                    StartQuests.CheckAndStartQuest();
                    Start();
                }
            }else{
                Console.WriteLine("Please only input a number");
                Console.Clear();
                Thread.Sleep(1000);
                MoveCharacter(location);
            }
        }
    }

// Tim was here
// fuck off tim
// :3
// Aidan is here :P
// helo