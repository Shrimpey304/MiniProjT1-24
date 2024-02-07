namespace SpiderSlayers;

public class Monster{

    public int ?ID{get; set;}
    public string ?MonsterName{get; set;}
    public string ?MonsterDescription{get; set;}
    public int MonsterHP{get; set;}
    public int MonsterMinDamage{get; set;}
    public int MonsterMaxDamage{get; set;}
    public LootTable Loot { get; set; }


    public Monster(int id, string name, string desc, int hp, int mindam, int maxdam){
        ID = id;
        MonsterName = name;
        MonsterDescription = desc;
        MonsterHP = hp;
        MonsterMinDamage = mindam;
        MonsterMaxDamage = maxdam;
        Loot = new LootTable();
    }

    public static void hi(){
        Console.WriteLine("afafa");
    }
}