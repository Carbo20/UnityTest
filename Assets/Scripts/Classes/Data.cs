using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data {

    public enum SlotType { HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS };
    public static int SlotTypeCount = 7;

    public enum ItemType { WEAPON, SHIELD, ARMOR };
    public static int ItemTypeCount = 3;

    public enum ItemQuality { NORMAL, MAGIC, LEGENDARY };
    public static int ItemQualityCount = 3;

    public static int inventorySlotPerItemType = 49;

    public static Inventory inventory = new Inventory();

    public enum BonusType { STREN, INTEL, AGI, VITAL, ATTACK, SPELL, MANA, REGENMANA, DODGE, CRIT, REGENHEALTH, HEALTH, ATTACKSPEED, CASTTIME };
    public static int BonusTypeCount = 14;
    
    public int nbBonusMaxPerItem = 5;

    public enum IconType { HEAD, CHEST, HANDS, LEGS, FEET, SHIELD, AXE, SWORD, DAGGER, MACE, WAND, SWORD2H, AXE2H, STAFF, SPEAR }; //1h weapon must be between axe and wand, 2h between sword2h and spear
    public static int IconTypeCount = 15;
    public static int numberOf1H = 5; // not counting shields
    public static int numberOf2H = 4;
    public static bool test=true;

    //[TODO] To complete enum of action

    public enum SkillType {ATTACK, USEITEM, TESTSKILL, FIREBALL } //Complete with all the skill

    //TODO liste d'objet

    public static List<List<ItemData>> listOfItems = new List<List<ItemData>>(); //ordered on IconType 
    public static List<Sprite> sprites;

    public static HeroData heroData = new HeroData();

    public static int showItemId = 5;

    public static IaData iaData = new IaData();

    public static int HeroStatsCount = 6;
    public static int nbOrder;
    
    
}
