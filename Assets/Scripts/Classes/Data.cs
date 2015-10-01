using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class made to store data that would be useful at any given time during the game.
/// 
/// IMPORTANT FACT CONCERNING ENUM : if you had a value to an enum make sure to add it inside its own sub-class
///     ex: if you add a 1-handed weapon add it between AXE and WAND
/// </summary>
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


    public enum SkillType {NULL, ATTACK, USEITEM, TESTSKILL, FIREBALL, HEAL} //Complete with all the skill

    public enum EnemySkillType {ATTACK, FIREBALL, DIVIDE, HARDSKIN, STOMP, BITE, BLEED, RAGE, GLUE, POISON, MINISTUN, SPIKE, BUTTSTOMP } // Complete with all the monster skill

    //[TODO] Complete the list of legendary effects
    public enum LegendaryEffect { NONE, FIREBALL1, FIREBAL2, LAST}; // NONE and LAST don't have any effect

    public static List<List<ItemData>> listOfItems = new List<List<ItemData>>(); //ordered on IconType 
    public static List<Sprite> sprites;

    public static HeroData heroData = new HeroData();
    public static int levelMax = 100;


    public static int showItemId = 5;
    public static int nbOrder;
    public static IaData iaData = new IaData();

    public static int HeroStatsCount = 6;

    public static int normalItemValueLvl1 = 50;
    public static int magicItemValueMultiplier = 4;
    public static int legendaryItemValueMultiplier = 10;

    public static float standardEnemyGoldMultiplier = 0.20f;
    public static float bossEnemyGoldMultiplier = 2;

    public static int maxStatUpgradePerLevel = 3;


    public static int numberOfStdEnemyForLvl1 = 10;
    public static int numberOfBossEnemyForLvl1 = 1;
    public static float riseInNumberOfEnemyToNextLvl = 0.05f;


}