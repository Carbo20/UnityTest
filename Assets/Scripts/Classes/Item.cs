using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// AUTHOR : Lucky
///                     TODO :  Add effects depending on skills
///                             Check for 
/// </summary>
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
    /// if legendary -> add an effect
    /// 
    /// // Normal loot : 70% normal 25% magic 5% legendary donc en float : normal < 0.7 , 0.7< magic <0.95, 0.95< legendary  ||| magicFind+10% : N 0.6 <M 0.90 <L  : N-10, M-5, L-5
    /// </summary>
    /// <param name="level"></param>
    /// <param name="magicFind">Between 0 and 70, carefull with that one</param>
    void GenerateItem(int _level, int magicFind)
    {
        int itemDrop;
        int iconTypeId = -1;
        float levelFloat = _level;
        int slotTypeInt=-1, itemTypeInt=-1, itemQualityInt, numberOfBonus = 0, randomBonus;
        int NormalRange = 70 - magicFind, MagicRange = 90 - (magicFind / 2); // when random 0-100 more than MagicRange the item is legendary

        ////ITEMSLOT
        //slotTypeInt = UnityEngine.Random.Range(0, Data.SlotTypeCount); // item slot type : HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS  
        ////slotType = (Data.SlotType)slotTypeInt;
        //Debug.Log("slotTypeInt " + slotTypeInt + "   " + SlotType);

        itemDrop = UnityEngine.Random.Range(0, 100); // 0-50 : armor & 50-75 : weapon 1h & 75-99 : weapon 2h

        if (itemDrop >= 0 && itemDrop < 50)////////ARMOR
        {
            itemTypeInt = Data.ItemType.ARMOR.GetHashCode();

            //0-10 HEAD, 10-20 CHEST, 20-30 HANDS, 30-40 LEGS, 40-50 FEET 
            if (itemDrop < 10)
            {
                slotTypeInt = Data.SlotType.HEAD.GetHashCode();
                iconTypeId = Data.IconType.HEAD.GetHashCode();
            }
            else if (itemDrop < 20)
            {
                slotTypeInt = Data.SlotType.CHEST.GetHashCode();
                iconTypeId = Data.IconType.CHEST.GetHashCode();
            }
            else if (itemDrop < 30)
            {
                slotTypeInt = Data.SlotType.HANDS.GetHashCode();
                iconTypeId = Data.IconType.HANDS.GetHashCode();
            }
            else if (itemDrop < 40)
            {
                slotTypeInt = Data.SlotType.LEGS.GetHashCode();
                iconTypeId = Data.IconType.LEGS.GetHashCode();
            }
            else if (itemDrop < 50)
            {
                slotTypeInt = Data.SlotType.FEET.GetHashCode();
                iconTypeId = Data.IconType.FEET.GetHashCode();
            }

            Armor = UnityEngine.Random.Range(8 * Level, 10 * Level);
        }
        else if (itemDrop >= 50 && itemDrop < 75)//1H
        {
            slotTypeInt = Data.SlotType.ONEHAND.GetHashCode();

            if (itemDrop < 54)      // SHIELD
            {
                itemTypeInt = Data.ItemType.SHIELD.GetHashCode();

                Armor = UnityEngine.Random.Range(8 * Level, 10 * Level);
                DodgeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                iconTypeId = Data.IconType.SHIELD.GetHashCode();
            }
            else if (itemDrop < 75)     // OTHER 1H
            {
                itemTypeInt = Data.ItemType.WEAPON.GetHashCode();

                AttackValue = UnityEngine.Random.Range(8 * Level, 10 * Level);
                AttackSpeed = UnityEngine.Random.Range(0.9f, 1.1f);
                iconTypeId = UnityEngine.Random.Range(Data.IconType.AXE.GetHashCode(), Data.IconType.WAND.GetHashCode() + 1);
            }
        }
        else if (itemDrop >= 75)    /////////////////// 2H
        {
            itemTypeInt = Data.ItemType.WEAPON.GetHashCode();
            slotTypeInt = Data.SlotType.TWOHANDS.GetHashCode();

            AttackValue = UnityEngine.Random.Range(40 * Level, 50 * Level);
            AttackSpeed = UnityEngine.Random.Range(1.9f, 2.1f);
            iconTypeId = UnityEngine.Random.Range(Data.IconType.SWORD2H.GetHashCode(), Data.IconType.SPEAR.GetHashCode() + 1);
        }
        ItemType = (Data.ItemType)itemTypeInt;

        itemQualityInt = UnityEngine.Random.Range(0, 100); // Qualite de l'item : normal, magic, legendaire

        if (itemQualityInt > MagicRange)// the item is legendary
        {
            ItemQuality = Data.ItemQuality.LEGENDARY;
            numberOfBonus = UnityEngine.Random.Range(3, 5);
            //EFFECT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!TODO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        else if (itemQualityInt > NormalRange)// the item is magical
        {
            ItemQuality = Data.ItemQuality.MAGIC;
            numberOfBonus = UnityEngine.Random.Range(2, 4);
        }
        else
            ItemQuality = Data.ItemQuality.NORMAL;


        // Semi-random number of bonuses and semi-random amout of bonus
        float strPerLevelMin = 0.80f, strPerLevelMax = 1;
        float intPerLevelMin = 0.80f, intPerLevelMax = 1;
        float agiPerLevelMin = 0.80f, agiPerLevelMax = 1;
        float vitalPerLevelMin = 0.80f, vitalPerLevelMax = 1;
        int attackPerLevelMin = 1, attackPerLevelMax = 2;
        int spellPerLevelMin = 1, spellPerLevelMax = 2;
        int manaPerLevelMin = 8, manaPerLevelMax = 10;
        int healthPerLevelMin = 8, healthPerLevelMax = 10;
        //float dodgePerLevelMin, dodgePerLevelMax;                 // CF BELOW
        //float critPerLevelMin, critPerLevelMax;                   // CF BELOW
        float regenManaPerLevelMin = 0.15f, regenManaPerLevelMax = 0.2f;
        float regenHealthPerLevelMin = 0.15f, regenHealthPerLevelMax = 0.2f;
        //float attackSpeedPerLevelMin, attackSpeedPerLevelMax;     // CF BELOW
        //float castTimePerLevelMin, castTimePerLevelMax;           // CF BELOW

        for (int i = 0; i < numberOfBonus; i++)
        {
            randomBonus = UnityEngine.Random.Range(0, Data.BonusTypeCount);

            switch ((Data.BonusType)randomBonus)
            {
                case Data.BonusType.STREN:
                    StrenBonus += UnityEngine.Random.Range((int)(strPerLevelMin * Level), (int)(Level* strPerLevelMax));
                    break;
                case Data.BonusType.INTEL:
                    IntelBonus += UnityEngine.Random.Range((int)(intPerLevelMin * Level), (int)(Level * intPerLevelMax));
                    break;
                case Data.BonusType.AGI:
                    AgiBonus += UnityEngine.Random.Range((int)(agiPerLevelMin * Level), (int)(Level * agiPerLevelMax));
                    break;
                case Data.BonusType.VITAL:
                    VitalBonus += UnityEngine.Random.Range((int)(vitalPerLevelMin * Level), (int)(Level * vitalPerLevelMax));
                    break;
                case Data.BonusType.ATTACK:
                    AttackBonus += UnityEngine.Random.Range(Level* attackPerLevelMin, Level * attackPerLevelMax);
                    break;
                case Data.BonusType.SPELL:
                    SpellBonus += UnityEngine.Random.Range(Level * spellPerLevelMin, Level * spellPerLevelMax);
                    break;
                case Data.BonusType.MANA:
                    ManaBonus += UnityEngine.Random.Range(Level * manaPerLevelMin, Level * manaPerLevelMax);
                    break;
                case Data.BonusType.HEALTH:
                    HealthBonus += UnityEngine.Random.Range(Level * healthPerLevelMin, Level * healthPerLevelMax);//at lvl 100 : 1000 -> 10/lvl max
                    break;

                case Data.BonusType.DODGE:
                    DodgeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;
                case Data.BonusType.CRIT:
                    CritBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;

                case Data.BonusType.REGENMANA:
                    RegenManaBonus += UnityEngine.Random.Range(levelFloat* regenManaPerLevelMin, levelFloat* regenManaPerLevelMax); //  at lvl 100 : 20 -> 0.2/lvl max
                    break;
                case Data.BonusType.REGENHEALTH:
                    RegenHealthBonus += UnityEngine.Random.Range(regenHealthPerLevelMin * levelFloat, regenHealthPerLevelMax * levelFloat);
                    break;
                case Data.BonusType.ATTACKSPEED:
                    AttackSpeedBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
                case Data.BonusType.CASTTIME:
                    CastTimeBonus += Math.Min(0.07f, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
            }
        }

        //SlotType { HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS };
        //ItemType { WEAPON, SHIELD, ARMOR };
        //IconType { SHIELD, AXE, SWORD, DAGGER, MACE, WAND, SWORD2H, AXE2H, STAFF, SPEAR, HEAD, CHEST, HANDS, LEGS, FEET };

        ///////////////////////////////////////////////////////Remplissage de la liste d'item, ceci est un test voué a disparaitre/////////////////////////////////////////////////////////////////////
        //pour tester DEBUT
        /*if (Data.test)
        {
            Debug.Log("here!!   A" + Data.IconTypeCount);
            for (int i = 0; i < Data.IconTypeCount; i++)
                Data.listOfItems.Add(new List<ItemData>());

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 6; j++)
                    Data.listOfItems[i].Add(new ItemData("placeholder", 3, "", (Data.SlotType)i));
            for (int i = 5; i < 11; i++)
                for (int j = 0; j < 6; j++)
                    Data.listOfItems[i].Add(new ItemData("placeholder", 3, "", Data.SlotType.ONEHAND));
            for (int i = 11; i < Data.IconTypeCount; i++)
                for (int j = 0; j < 6; j++)
                    Data.listOfItems[i].Add(new ItemData("placeholder", 3, "", Data.SlotType.TWOHANDS));
            Data.test = false;
            Debug.Log("here!!   B");
        }*/
        //pour tester FIN

        int randomItemDataId;
        randomItemDataId = UnityEngine.Random.Range(0, Data.listOfItems[iconTypeId].Count);

        itemData = Data.listOfItems[iconTypeId][randomItemDataId];
    }

   
   ///////////////////////////////////////////////FIN TEST














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
