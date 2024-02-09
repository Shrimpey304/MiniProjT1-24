namespace SpiderSlayers;

public class Weapon{

    public int ?ID{get; set;}
    public string ?WeaponName{get; set;}
    public string ?WeaponDescription{get; set;}
    public int WeaponMinDamage{get; set;}
    public int WeaponMaxDamage{get; set;}


    public Weapon(int id, string name, string desc, int mindam, int maxdam){
        ID = id;
        WeaponName = name;
        WeaponDescription = desc;
        WeaponMinDamage = mindam;
        WeaponMaxDamage = maxdam;
    }

}