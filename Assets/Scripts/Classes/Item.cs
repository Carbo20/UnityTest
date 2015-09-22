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

        //Normal stats for items
        int armorPerLevelMin = 8, armorPerLevelMax = 10;
        int attack1HPerLevelMin = 8, attack1HPerLevelMax = 10;
        float attackSpeed1HMin = 1.75f, attackSpeed1HMax = 2.25f;
        int attack2HPerLevelMin = 40, attack2HPerLevelMax = 50;
        float attackSpeed2HMin = 2.625f, attackSpeed2HMax = 3.375f;

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

        // Peculiar restrictions
        float maxDodgePerItem = 0.07f;

        // Drop rates 0-50 : armor & 50-75 : weapon 1h & 75-99 : weapon 2h
        int dropArmor = 50;
        int dropRangeArmor = dropArmor / 5;
        int dropHead = dropRangeArmor;
        int dropChest = dropHead + dropRangeArmor;
        int dropHands = dropChest + dropRangeArmor;
        int dropLegs = dropHands + dropRangeArmor;
        int dropFeet = dropLegs + dropRangeArmor;

        int drop1HWeapon = 75;
        int dropShield = 54;
        itemDrop = UnityEngine.Random.Range(0, 100); 

        if (itemDrop < dropArmor)////////ARMOR
        {
            itemTypeInt = Data.ItemType.ARMOR.GetHashCode();

            //0-10 HEAD, 10-20 CHEST, 20-30 HANDS, 30-40 LEGS, 40-50 FEET 
            if (itemDrop < dropHead)
            {
                slotTypeInt = Data.SlotType.HEAD.GetHashCode();
                iconTypeId = Data.IconType.HEAD.GetHashCode();
            }
            else if (itemDrop < dropChest)
            {
                slotTypeInt = Data.SlotType.CHEST.GetHashCode();
                iconTypeId = Data.IconType.CHEST.GetHashCode();
            }
            else if (itemDrop < dropHands)
            {
                slotTypeInt = Data.SlotType.HANDS.GetHashCode();
                iconTypeId = Data.IconType.HANDS.GetHashCode();
            }
            else if (itemDrop < dropLegs)
            {
                slotTypeInt = Data.SlotType.LEGS.GetHashCode();
                iconTypeId = Data.IconType.LEGS.GetHashCode();
            }
            else if (itemDrop < dropFeet)
            {
                slotTypeInt = Data.SlotType.FEET.GetHashCode();
                iconTypeId = Data.IconType.FEET.GetHashCode();
            }

            Armor = UnityEngine.Random.Range(Level * armorPerLevelMin, Level * armorPerLevelMax);
        }
        else if (itemDrop >= dropArmor && itemDrop < drop1HWeapon)//1H
        {
            slotTypeInt = Data.SlotType.ONEHAND.GetHashCode();

            if (itemDrop < dropShield)      // SHIELD
            {
                itemTypeInt = Data.ItemType.SHIELD.GetHashCode();

                Armor = UnityEngine.Random.Range(Level * armorPerLevelMin, Level * armorPerLevelMax);
                DodgeBonus += Math.Min(maxDodgePerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                iconTypeId = Data.IconType.SHIELD.GetHashCode();
            }
            else if (itemDrop < drop1HWeapon)     // OTHER 1H
            {
                itemTypeInt = Data.ItemType.WEAPON.GetHashCode();

                AttackValue = UnityEngine.Random.Range(Level * attack1HPerLevelMin, Level * attack1HPerLevelMax);
                AttackSpeed = UnityEngine.Random.Range(attackSpeed1HMin, attackSpeed1HMax);
                iconTypeId = UnityEngine.Random.Range(Data.IconType.AXE.GetHashCode(), Data.IconType.WAND.GetHashCode() + 1); // Random among all 1hweapons from iconType 
            }
        }
        else if (itemDrop >= drop1HWeapon)    /////////////////// 2H
        {
            itemTypeInt = Data.ItemType.WEAPON.GetHashCode();
            slotTypeInt = Data.SlotType.TWOHANDS.GetHashCode();

            AttackValue = UnityEngine.Random.Range(Level * attack2HPerLevelMin, Level * attack2HPerLevelMax);
            AttackSpeed = UnityEngine.Random.Range(attackSpeed2HMin, attackSpeed2HMax);
            iconTypeId = UnityEngine.Random.Range(Data.IconType.SWORD2H.GetHashCode(), Data.IconType.SPEAR.GetHashCode() + 1); // Random among all 2hweapons from iconType 
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

        int randomItemDataId;
        randomItemDataId = UnityEngine.Random.Range(0, Data.listOfItems[iconTypeId].Count);

        itemData = Data.listOfItems[iconTypeId][randomItemDataId];
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
            return castTimeBonus;
        }

        set
        {
            castTimeBonus = value;
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
