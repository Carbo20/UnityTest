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

    public enum IconType { SHIELD, AXE, SWORD, DAGGER, MACE, WAND, SWORD2H, AXE2H, STAFF, SPEAR, HEAD, CHEST, HANDS, LEGS, FEET };
    public static int IconTypeCount = 15;

    //TODO liste d'objet

    public List<List<ItemData>> listOfItems; //ordered on IconType

    public static HeroData heroData = new HeroData();

    public enum IaCondition { STREN, INTEL, AGI, VITAL, HEALTH, MANA};

    public static int HeroStatsCount = 6;
    
}
