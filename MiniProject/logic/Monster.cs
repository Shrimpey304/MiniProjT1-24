namespace SpiderSlayers;

public class Monster{

    public int ?ID{get; set;}
    public string ?MonsterName{get; set;}
    public string ?MonsterDescription{get; set;}
    public int MonsterHP{get; set;}
    public int MonsterMinDamage{get; set;}
    public int MonsterMaxDamage{get; set;}
    public int something1{get; set;}
    public int something2{get; set;}
    public LootTable Loot { get; set; }


    public Monster(int id, string name, string desc, int hp, int mindam, int maxdam, int s1, int s2){
        ID = id;
        MonsterName = name;
        MonsterDescription = desc;
        MonsterHP = hp;
        MonsterMinDamage = mindam;
        MonsterMaxDamage = maxdam;
        something1 = s1;
        something2 = s2;
        Loot = new LootTable();
    }

    public static void hi(){
        Console.WriteLine("afafa");
    }
}