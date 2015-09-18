using UnityEngine;
using System.Collections;
using System;

public class Item
{
    /* Item's Variables */
    private int attackValue;
    private float attackSpeed;
    private int armor;
    Sprite icon;
    private string name;
    private string description;
    private int level;

    private int strenBonus =0, intelBonus=0, agiBonus=0, vitalBonus=0, attackBonus=0, spellBonus=0, manaBonus=0,   healthBonus=0;
    private float attackSpeedBonus =0, castTimeBonus=0, regenManaBonus = 0, regenHealthBonus = 0, dodgeBonus = 0, critBonus = 0; // for speed : between 0 and 1, it will reduce the delay after an attack or a cast is done

    Data.SlotType slotType;
    Data.ItemType itemType;
    Data.ItemQuality itemQuality;

    enum BonusType { STREN, INTEL, AGI, VITAL, ATTACK, SPELL, MANA, REGENMANA, DODGE, CRIT, REGENHEALTH, HEALTH, ATTACKSPEED, CASTTIME };
    int BonusTypeCount = 14;

    //public enum SlotType { HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS };

    /// <summary>
    /// int rand = UnityEngine.Random.Range(0, max); max excluded  // value instead of range for float
    /// rand to determine wich item type  is gonna drop
    /// rand to determine wich  quality  the item will be : Normal : 0 bonus, magic : 2 to 3 bonus, legendary 3 to 4 bonus + an effect
    /// rands to determine wich BONUS will be presents
    /// if legendary add an effect
    /// name is generated automaticaly
    /// </summary>
    /// <param name="level"></param>
    /// <param name="magicFind">Between 0 and 70, carefull with that one</param>
    void GenerateItem(int _level, int magicFind)
    {
        level = _level;
        float levelFloat = level;
        int slotTypeInt, itemTypeInt, itemQualityInt, numberOfBonus=0, randomBonus;
        int NormalRange = 70- magicFind, MagicRange = 90- (magicFind/2); // when random 0-100 more than MagicRange the item is legendary
        
        //ITEMSLOT
        slotTypeInt = UnityEngine.Random.Range(0, Data.ItemTypeCount); // item slot type : HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS  
        Debug.Log("slotTypeInt " + slotTypeInt);
        slotType = (Data.SlotType)slotTypeInt;

        //itemTypeInt
        if (slotTypeInt == Data.SlotType.ONEHAND.GetHashCode()) // if the item type is 1h we rand between weapon and shield
        {
            int temp = UnityEngine.Random.Range(0, 2);
            if (temp == 0)
                itemTypeInt = Data.ItemType.WEAPON.GetHashCode();//weapon
            else
                itemTypeInt = Data.ItemType.SHIELD.GetHashCode();//shield
        }
        else if (slotTypeInt == Data.SlotType.TWOHANDS.GetHashCode())
            itemTypeInt = Data.ItemType.WEAPON.GetHashCode();//weapon
        else
            itemTypeInt = Data.ItemType.ARMOR.GetHashCode();//Armor
        itemType = (Data.ItemType)itemTypeInt;
        Debug.Log("itemTypeInt " + itemTypeInt);

        // Normal loot : 70% normal 25% magic 5% legendary donc en float : < 0.7 normal, 0.7< magic <0.95, 0.95< legendary
        // Loot+10% : N 0.6 <M 0.90 <L  : N-10, M-5, L-5
        
        itemQualityInt = UnityEngine.Random.Range(0, 100); // Qualite de l'item : normal, magic, legendaire
        Debug.Log("itemQualityInt " + itemQualityInt + "   MagicRange " + MagicRange);

        if (itemQualityInt > MagicRange)// the item is legendary
        {
            itemQuality = Data.ItemQuality.LEGENDARY;
            numberOfBonus = UnityEngine.Random.Range(3, 5);
            //EFFECT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!TODO
        }
        else if (itemQualityInt > NormalRange)// the item is magical
        {
            itemQuality = Data.ItemQuality.MAGIC;
            numberOfBonus = UnityEngine.Random.Range(2, 4);
        }
        else
            itemQuality = Data.ItemQuality.NORMAL;

        for(int i=0; i<numberOfBonus; i++)
        {
            randomBonus = UnityEngine.Random.Range(0, BonusTypeCount);

            switch ((BonusType)randomBonus)
            {
                case BonusType.STREN:
                    strenBonus += UnityEngine.Random.Range((int)0.80 * level, level);
                    break;
                case BonusType.INTEL:
                    intelBonus += UnityEngine.Random.Range((int)0.80 * level, level);
                    break;
                case BonusType.AGI:
                    agiBonus += UnityEngine.Random.Range((int)0.80 * level, level);
                    break;
                 case BonusType.VITAL:
                    vitalBonus += UnityEngine.Random.Range((int)0.80*level, level);
                    break;
                case BonusType.ATTACK:
                    attackBonus += UnityEngine.Random.Range(level, 2 * level);
                    break;
                case BonusType.SPELL:
                    spellBonus += UnityEngine.Random.Range(level, 2 * level);
                    break;
                case BonusType.MANA:
                    manaBonus += UnityEngine.Random.Range(8 * level, 10 * level);
                    break;
                case BonusType.REGENMANA:
                    regenManaBonus += UnityEngine.Random.Range(0.15f * levelFloat, 0.2f * levelFloat); //  at lvl 100 : 20 -> 0.2/lvl max
                    break;
                case BonusType.DODGE:
                    dodgeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;
                case BonusType.CRIT:
                    critBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;
                case BonusType.REGENHEALTH:
                    regenHealthBonus += UnityEngine.Random.Range(0.15f * levelFloat, 0.2f * levelFloat); 
                    break;
                case BonusType.HEALTH:
                    healthBonus += UnityEngine.Random.Range(8*level, 10*level);//at lvl 100 : 1000 -> 10/lvl max
                    break;

                case BonusType.ATTACKSPEED:
                    attackSpeedBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
                case BonusType.CASTTIME:
                    castTimeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
            }
        }
        
        if (itemTypeInt == Data.ItemType.SHIELD.GetHashCode())
        {
            armor = UnityEngine.Random.Range(8 * level, 10 * level);
            dodgeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
        }
        else if (itemTypeInt == Data.ItemType.ARMOR.GetHashCode())
        {
            armor = UnityEngine.Random.Range(8 * level, 10 * level);
        }
        else if (itemTypeInt == Data.ItemType.WEAPON.GetHashCode())
        {
            if(slotTypeInt == Data.SlotType.ONEHAND.GetHashCode())
            {
                attackValue = UnityEngine.Random.Range(8 * level, 10 * level);
                attackSpeed = UnityEngine.Random.Range(0.9f, 1.1f);
            }
            else
            {
                attackValue = UnityEngine.Random.Range(40 * level, 50 * level);
                attackSpeed = UnityEngine.Random.Range(1.9f, 2.1f);
            }
        }

    }
}
