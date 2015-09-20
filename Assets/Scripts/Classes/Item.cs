using UnityEngine;
using System.Collections;
using System;

//TODO  : Generate name based on bonus and effect
//TODO :  Add effects depending on skills
public class Item
{
    /* Item's Variables */
    private int attackValue;
    private float attackSpeed;
    private int armor;
    private int level;

    private int strenBonus, intelBonus, agiBonus, vitalBonus, attackBonus, spellBonus, manaBonus,   healthBonus;
    private float attackSpeedBonus, castTimeBonus, regenManaBonus, regenHealthBonus, dodgeBonus, critBonus; // for speed : between 0 and 1, it will reduce the delay after an attack or a cast is done

   // private Data.SlotType slotType;
    private Data.ItemType itemType;
    private Data.ItemQuality itemQuality;
    private ItemData itemData;

    public Item(int _level, int _magicFind)
    {

        
        strenBonus = 0;
        intelBonus = 0;
        agiBonus = 0;
        vitalBonus = 0;
        attackBonus = 0;
        spellBonus = 0;
        manaBonus = 0;
        healthBonus = 0;
        attackSpeedBonus = 0;
        castTimeBonus = 0;
        regenManaBonus = 0;
        regenHealthBonus = 0;
        dodgeBonus = 0;
        critBonus = 0;

        level = _level;

        GenerateItem(_level, _magicFind);
    }

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
        float levelFloat = Level;
        int slotTypeInt, itemTypeInt, itemQualityInt, numberOfBonus=0, randomBonus;
        int NormalRange = 70- magicFind, MagicRange = 90- (magicFind/2); // when random 0-100 more than MagicRange the item is legendary
        
        //ITEMSLOT
        slotTypeInt = UnityEngine.Random.Range(0, Data.SlotTypeCount); // item slot type : HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS  
        //slotType = (Data.SlotType)slotTypeInt;
        //Debug.Log("slotTypeInt " + slotTypeInt + "   " + SlotType);

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
        ItemType = (Data.ItemType)itemTypeInt;
        //Debug.Log("itemTypeInt " + itemTypeInt);

        // Normal loot : 70% normal 25% magic 5% legendary donc en float : < 0.7 normal, 0.7< magic <0.95, 0.95< legendary
        // Loot+10% : N 0.6 <M 0.90 <L  : N-10, M-5, L-5
        
        itemQualityInt = UnityEngine.Random.Range(0, 100); // Qualite de l'item : normal, magic, legendaire
        //Debug.Log("itemQualityInt " + itemQualityInt + "   MagicRange " + MagicRange);

        if (itemQualityInt > MagicRange)// the item is legendary
        {
            ItemQuality = Data.ItemQuality.LEGENDARY;
            numberOfBonus = UnityEngine.Random.Range(3, 5);
            //EFFECT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!TODO
        }
        else if (itemQualityInt > NormalRange)// the item is magical
        {
            ItemQuality = Data.ItemQuality.MAGIC;
            numberOfBonus = UnityEngine.Random.Range(2, 4);
        }
        else
            ItemQuality = Data.ItemQuality.NORMAL;

        for(int i=0; i<numberOfBonus; i++)
        {
            randomBonus = UnityEngine.Random.Range(0, Data.BonusTypeCount);

            switch ((Data.BonusType)randomBonus)
            {
                case Data.BonusType.STREN:
                    StrenBonus += UnityEngine.Random.Range((int) (0.80 * Level), Level);
                    break;
                case Data.BonusType.INTEL:
                    IntelBonus += UnityEngine.Random.Range((int)(0.80 * Level), Level);
                    break;
                case Data.BonusType.AGI:
                    AgiBonus += UnityEngine.Random.Range((int)(0.80 * Level), Level);
                    break;
                 case Data.BonusType.VITAL:
                    VitalBonus += UnityEngine.Random.Range((int)(0.80 * Level), Level);
                    break;
                case Data.BonusType.ATTACK:
                    AttackBonus += UnityEngine.Random.Range(Level, 2 * Level);
                    break;
                case Data.BonusType.SPELL:
                    SpellBonus += UnityEngine.Random.Range(Level, 2 * Level);
                    break;
                case Data.BonusType.MANA:
                    ManaBonus += UnityEngine.Random.Range(8 * Level, 10 * Level);
                    break;
                case Data.BonusType.REGENMANA:
                    RegenManaBonus += UnityEngine.Random.Range(0.15f * levelFloat, 0.2f * levelFloat); //  at lvl 100 : 20 -> 0.2/lvl max
                    break;
                case Data.BonusType.DODGE:
                    DodgeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;
                case Data.BonusType.CRIT:
                    CritBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;
                case Data.BonusType.REGENHEALTH:
                    RegenHealthBonus += UnityEngine.Random.Range(0.15f * levelFloat, 0.2f * levelFloat); 
                    break;
                case Data.BonusType.HEALTH:
                    HealthBonus += UnityEngine.Random.Range(8*Level, 10*Level);//at lvl 100 : 1000 -> 10/lvl max
                    break;

                case Data.BonusType.ATTACKSPEED:
                    AttackSpeedBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
                case Data.BonusType.CASTTIME:
                    CastTimeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
            }
        }
        
        if (itemTypeInt == Data.ItemType.SHIELD.GetHashCode())
        {
            Armor = UnityEngine.Random.Range(8 * Level, 10 * Level);
            DodgeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
        }
        else if (itemTypeInt == Data.ItemType.ARMOR.GetHashCode())
        {
            Armor = UnityEngine.Random.Range(8 * Level, 10 * Level);
        }
        else if (itemTypeInt == Data.ItemType.WEAPON.GetHashCode())
        {
            if(slotTypeInt == Data.SlotType.ONEHAND.GetHashCode())
            {
                AttackValue = UnityEngine.Random.Range(8 * Level, 10 * Level);
                AttackSpeed = UnityEngine.Random.Range(0.9f, 1.1f);
            }
            else
            {
                AttackValue = UnityEngine.Random.Range(40 * Level, 50 * Level);
                AttackSpeed = UnityEngine.Random.Range(1.9f, 2.1f);
            }
        }


        itemData = new ItemData("placeholder", slotTypeInt, "", (Data.SlotType)slotTypeInt);
    }

    /////////////////GETTERS AND SETTERS//////////////////////////////
    public int AttackValue
    {
        get
        {
            return attackValue;
        }

        set
        {
            attackValue = value;
        }
    }

    public float AttackSpeed
    {
        get
        {
            return attackSpeed;
        }

        set
        {
            attackSpeed = value;
        }
    }

    public int Armor
    {
        get
        {
            return armor;
        }

        set
        {
            armor = value;
        }
    }

    public string Name
    {
        get
        {
            return itemData.ItemName;
        }

    }

    public string Description
    {
        get
        {
            return itemData.Description;
        }

    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int StrenBonus
    {
        get
        {
            return strenBonus;
        }

        set
        {
            strenBonus = value;
        }
    }

    public int IntelBonus
    {
        get
        {
            return intelBonus;
        }

        set
        {
            intelBonus = value;
        }
    }

    public int AgiBonus
    {
        get
        {
            return agiBonus;
        }

        set
        {
            agiBonus = value;
        }
    }

    public int VitalBonus
    {
        get
        {
            return vitalBonus;
        }

        set
        {
            vitalBonus = value;
        }
    }

    public int AttackBonus
    {
        get
        {
            return attackBonus;
        }

        set
        {
            attackBonus = value;
        }
    }

    public int SpellBonus
    {
        get
        {
            return spellBonus;
        }

        set
        {
            spellBonus = value;
        }
    }

    public int ManaBonus
    {
        get
        {
            return manaBonus;
        }

        set
        {
            manaBonus = value;
        }
    }

    public int HealthBonus
    {
        get
        {
            return healthBonus;
        }

        set
        {
            healthBonus = value;
        }
    }

    public float AttackSpeedBonus
    {
        get
        {
            return AttackSpeedBonus1;
        }

        set
        {
            AttackSpeedBonus1 = value;
        }
    }

    public float AttackSpeedBonus1
    {
        get
        {
            return attackSpeedBonus;
        }

        set
        {
            attackSpeedBonus = value;
        }
    }

    public float CastTimeBonus
    {
        get
        {
            return castTimeBonus;
        }

        set
        {
            castTimeBonus = value;
        }
    }

    public float RegenManaBonus
    {
        get
        {
            return regenManaBonus;
        }

        set
        {
            regenManaBonus = value;
        }
    }

    public float RegenHealthBonus
    {
        get
        {
            return regenHealthBonus;
        }

        set
        {
            regenHealthBonus = value;
        }
    }

    public float DodgeBonus
    {
        get
        {
            return dodgeBonus;
        }

        set
        {
            dodgeBonus = value;
        }
    }

    public float CritBonus
    {
        get
        {
            return critBonus;
        }

        set
        {
            critBonus = value;
        }
    }

    public Data.SlotType SlotType
    {
        get
        {
            return itemData.slotType;
        }

        set
        {
            itemData.slotType = value;
        }
    }

    public Data.ItemType ItemType
    {
        get
        {
            return itemType;
        }

        set
        {
            itemType = value;
        }
    }

    public Data.ItemQuality ItemQuality
    {
        get
        {
            return itemQuality;
        }

        set
        {
            itemQuality = value;
        }
    }

    public int SpriteID
    {

        get
        {
            return itemData.SpriteId;
        }

        set
        {
            itemData.SpriteId = value;
        }

    }
}
