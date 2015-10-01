using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// AUTHOR : Lucky
///                             
/// </summary>
[Serializable()]
public class Item
{
    /* Item's Variables */
    private int attackValue;
    private int armor;
    private int level;
    private float cdAttack;

    private int strenBonus, intelBonus, agiBonus, vitalBonus, attackBonus, spellBonus, manaBonus,   healthBonus;
    private float cdAttackBonus, castTimeBonus, regenManaBonus, regenHealthBonus, dodgeBonus, critBonus;

    private Data.ItemType itemType;
    private Data.ItemQuality itemQuality;
    private ItemData itemData;
    private Data.LegendaryEffect legendaryEffect;


    ///////////////// Private data No getter No setter  BEGIN
    private int maxMagicFind = 70;
    private int itemDrop;
    private int iconTypeId = -1;
    private float levelFloat;
    private int itemTypeInt = -1, itemQualityInt, numberOfBonus = 0, randomBonus;
    private int NormalRange;
    private int MagicRange;

    //Normal stats for items
    private int armorPerLevelMin = 8, armorPerLevelMax = 10;
    private int attack1HPerLevelMin = 8, attack1HPerLevelMax = 10;
    private float cdAttack1HMin = 1.75f, cdAttack1HMax = 2.25f;
    private int attack2HPerLevelMin = 40, attack2HPerLevelMax = 50;
    private float cdAttack2HMin = 2.625f, cdAttack2HMax = 3.375f;

    // Semi-random number of bonuses and semi-random amout of bonus
    private float strPerLevelMin = 0.80f, strPerLevelMax = 1;
    private float intPerLevelMin = 0.80f, intPerLevelMax = 1;
    private float agiPerLevelMin = 0.80f, agiPerLevelMax = 1;
    private float vitalPerLevelMin = 0.80f, vitalPerLevelMax = 1;
    private int attackPerLevelMin = 1, attackPerLevelMax = 2;
    private int spellPerLevelMin = 1, spellPerLevelMax = 2;
    private int manaPerLevelMin = 8, manaPerLevelMax = 10;
    private int healthPerLevelMin = 8, healthPerLevelMax = 10;
    //float dodgePerLevelMin, dodgePerLevelMax;                 // CF in generate
    //float critPerLevelMin, critPerLevelMax;                   // CF in generate
    private float regenManaPerLevelMin = 0.15f, regenManaPerLevelMax = 0.2f;
    private float regenHealthPerLevelMin = 0.15f, regenHealthPerLevelMax = 0.2f;
    //float cdAttackPerLevelMin, cdAttackPerLevelMax;           // CF BELOW
    //float castTimePerLevelMin, castTimePerLevelMax;           // CF BELOW

    // Peculiar restrictions
    private float maxDodgePerItem = 0.07f;
    private float maxCastTimeBonusPerItem = 0.07f;
    private float maxCdAttackBonusPerItem = 0.07f;
    private float maxCritBonusPerItem = 0.07f;
    private float maxDodgeBonusPerItem = 0.07f;

    // Drop rates
    private int dropArmor = 50; // Drop rates 0-50 : armor & 50-75 : weapon 1h & 75-99 : weapon 2h
    private int dropRangeArmor ;
    private int dropHead;
    private int dropChest;
    private int dropHands;
    private int dropLegs;
    private int dropFeet;

    private int drop1HWeapon = 75;
    private int dropShield = 54;
    ///////////////// Private data No getter No setter  END

    public Item()
    {
        attackValue = 0;
        armor = 0;
        cdAttack = 0;

        strenBonus = 0;
        intelBonus = 0;
        agiBonus = 0;
        vitalBonus = 0;
        attackBonus = 0;
        spellBonus = 0;
        manaBonus = 0;
        healthBonus = 0;
        cdAttackBonus = 0;
        castTimeBonus = 0;
        regenManaBonus = 0;
        regenHealthBonus = 0;
        dodgeBonus = 0;
        critBonus = 0;
        LegendaryEffect = Data.LegendaryEffect.NONE;
        level = 1;
        GenerateItem(level, 0);
        itemData = new ItemData();
    }

    public Item(int _level, int _magicFind)
    {
        attackValue = 0;
        armor = 0;
        cdAttack = 0;

        strenBonus = 0;
        intelBonus = 0;
        agiBonus = 0;
        vitalBonus = 0;
        attackBonus = 0;
        spellBonus = 0;
        manaBonus = 0;
        healthBonus = 0;
        cdAttackBonus = 0;
        castTimeBonus = 0;
        regenManaBonus = 0;
        regenHealthBonus = 0;
        dodgeBonus = 0;
        critBonus = 0;
        LegendaryEffect = Data.LegendaryEffect.NONE;

        level = _level;

        GenerateItem(_level, _magicFind);
    }

    public Item(int _level, int _magicFind, Data.IconType typeOfItemDropped)
    {
        attackValue = 0;
        armor = 0;
        cdAttack = 0;

        strenBonus = 0;
        intelBonus = 0;
        agiBonus = 0;
        vitalBonus = 0;
        attackBonus = 0;
        spellBonus = 0;
        manaBonus = 0;
        healthBonus = 0;
        cdAttackBonus = 0;
        castTimeBonus = 0;
        regenManaBonus = 0;
        regenHealthBonus = 0;
        dodgeBonus = 0;
        critBonus = 0;
        LegendaryEffect = Data.LegendaryEffect.NONE;

        level = _level;

        GenerateItem(_level, _magicFind, typeOfItemDropped);
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
        magicFind = Math.Min(magicFind, maxMagicFind);
        magicFind = Math.Max(0, magicFind);
        levelFloat = _level;
        NormalRange = 70 - magicFind;
        MagicRange = 90 - (magicFind / 2); // When random 0-100 more than MagicRange the item is legendary

        // Drop rates 0-50 : armor & 50-75 : weapon 1h & 75-99 : weapon 2h
        dropRangeArmor = dropArmor / 5;
        dropHead = dropRangeArmor;
        dropChest = dropHead + dropRangeArmor;
        dropHands = dropChest + dropRangeArmor;
        dropLegs = dropHands + dropRangeArmor;
        dropFeet = dropLegs + dropRangeArmor;

        itemDrop = UnityEngine.Random.Range(0, 100); 

        if (itemDrop < dropArmor)////////ARMOR
        {
            itemTypeInt = Data.ItemType.ARMOR.GetHashCode();

            //0-10 HEAD, 10-20 CHEST, 20-30 HANDS, 30-40 LEGS, 40-50 FEET 
            if (itemDrop < dropHead)
                iconTypeId = Data.IconType.HEAD.GetHashCode();
            else if (itemDrop < dropChest)
                iconTypeId = Data.IconType.CHEST.GetHashCode();
            else if (itemDrop < dropHands)
                iconTypeId = Data.IconType.HANDS.GetHashCode();
            else if (itemDrop < dropLegs)
                iconTypeId = Data.IconType.LEGS.GetHashCode();
            else if (itemDrop < dropFeet)
                iconTypeId = Data.IconType.FEET.GetHashCode();

            Armor = UnityEngine.Random.Range(Level * armorPerLevelMin, Level * armorPerLevelMax);
        }
        else if (itemDrop >= dropArmor && itemDrop < drop1HWeapon)//1H
        {
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
                CdAttack = UnityEngine.Random.Range(cdAttack1HMin, cdAttack1HMax);
                iconTypeId = UnityEngine.Random.Range(Data.IconType.AXE.GetHashCode(), Data.IconType.WAND.GetHashCode() + 1); // Random among all 1hweapons from iconType 
            }
        }
        else if (itemDrop >= drop1HWeapon)    /////////////////// 2H
        {
            itemTypeInt = Data.ItemType.WEAPON.GetHashCode();

            AttackValue = UnityEngine.Random.Range(Level * attack2HPerLevelMin, Level * attack2HPerLevelMax);
            CdAttack = UnityEngine.Random.Range(cdAttack2HMin, cdAttack2HMax);
            iconTypeId = UnityEngine.Random.Range(Data.IconType.SWORD2H.GetHashCode(), Data.IconType.SPEAR.GetHashCode() + 1); // Random among all 2hweapons from iconType 
        }
        ItemType = (Data.ItemType)itemTypeInt;

        itemQualityInt = UnityEngine.Random.Range(0, 100); // Qualite de l'item : normal, magic, legendaire

        if (itemQualityInt > MagicRange)// the item is legendary
        {
            ItemQuality = Data.ItemQuality.LEGENDARY;
            numberOfBonus = UnityEngine.Random.Range(3, 5);
            LegendaryEffect = (Data.LegendaryEffect) UnityEngine.Random.Range(Data.LegendaryEffect.NONE.GetHashCode()+1, Data.LegendaryEffect.LAST.GetHashCode());
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
                    DodgeBonus += Math.Min(maxDodgeBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;
                case Data.BonusType.CRIT:
                    CritBonus += Math.Min(maxCritBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;

                case Data.BonusType.REGENMANA:
                    RegenManaBonus += UnityEngine.Random.Range(levelFloat* regenManaPerLevelMin, levelFloat* regenManaPerLevelMax); //  at lvl 100 : 20 -> 0.2/lvl max
                    break;
                case Data.BonusType.REGENHEALTH:
                    RegenHealthBonus += UnityEngine.Random.Range(regenHealthPerLevelMin * levelFloat, regenHealthPerLevelMax * levelFloat);
                    break;
                case Data.BonusType.ATTACKSPEED:
                    CdAttackBonus += Math.Min(maxCdAttackBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
                case Data.BonusType.CASTTIME:
                    CastTimeBonus += Math.Min(maxCastTimeBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
            }
        }

        int randomItemDataId;
        randomItemDataId = UnityEngine.Random.Range(0, Data.listOfItems[iconTypeId].Count);

        itemData = Data.listOfItems[iconTypeId][randomItemDataId];
    }

    /// <summary>
    /// Second version of GenerateItem in wich we can CHOOSE the type of item generated
    /// </summary>
    /// <param name="level"></param>
    /// <param name="magicFind">Between 0 and 70, carefull with that one</param>
    void GenerateItem(int _level, int magicFind, Data.IconType typeOfItemDropped)
    {
        magicFind = Math.Min(magicFind, maxMagicFind);
        magicFind = Math.Max(0, magicFind);
        levelFloat = _level;
        NormalRange = 70 - magicFind;
        MagicRange = 90 - (magicFind / 2); // When random 0-100 more than MagicRange the item is legendary

        iconTypeId = (int)typeOfItemDropped;

        if (typeOfItemDropped >= Data.IconType.HEAD && typeOfItemDropped < Data.IconType.SHIELD)////////// ARMOR
        {
            itemTypeInt = Data.ItemType.ARMOR.GetHashCode();
            Armor = UnityEngine.Random.Range(Level * armorPerLevelMin, Level * armorPerLevelMax);
        }
        else if (typeOfItemDropped == Data.IconType.SHIELD)/////////////////////////////////////////////// 1H SHIELD
        {
            itemTypeInt = Data.ItemType.SHIELD.GetHashCode();
            Armor = UnityEngine.Random.Range(Level * armorPerLevelMin, Level * armorPerLevelMax);
            DodgeBonus += Math.Min(maxDodgePerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
            iconTypeId = Data.IconType.SHIELD.GetHashCode();
        }
        else if (typeOfItemDropped >= Data.IconType.AXE && typeOfItemDropped <= Data.IconType.WAND)/////// OTHER 1H
        {
            itemTypeInt = Data.ItemType.WEAPON.GetHashCode();
            AttackValue = UnityEngine.Random.Range(Level * attack1HPerLevelMin, Level * attack1HPerLevelMax);
            CdAttack = UnityEngine.Random.Range(cdAttack1HMin, cdAttack1HMax);
        }
        
        else if (typeOfItemDropped >= Data.IconType.SWORD2H)    //////////////////////////////////////////// 2H
        {
            itemTypeInt = Data.ItemType.WEAPON.GetHashCode();
            AttackValue = UnityEngine.Random.Range(Level * attack2HPerLevelMin, Level * attack2HPerLevelMax);
            CdAttack = UnityEngine.Random.Range(cdAttack2HMin, cdAttack2HMax);
        }
        ItemType = (Data.ItemType)itemTypeInt;

        itemQualityInt = UnityEngine.Random.Range(0, 100); // Qualite de l'item : normal, magic, legendaire

        if (itemQualityInt > MagicRange)// the item is legendary
        {
            ItemQuality = Data.ItemQuality.LEGENDARY;
            numberOfBonus = UnityEngine.Random.Range(3, 5);
            LegendaryEffect = (Data.LegendaryEffect)UnityEngine.Random.Range(Data.LegendaryEffect.NONE.GetHashCode() + 1, Data.LegendaryEffect.LAST.GetHashCode());
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
                    StrenBonus += UnityEngine.Random.Range((int)(strPerLevelMin * Level), (int)(Level * strPerLevelMax));
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
                    AttackBonus += UnityEngine.Random.Range(Level * attackPerLevelMin, Level * attackPerLevelMax);
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
                    DodgeBonus += Math.Min(maxDodgeBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;
                case Data.BonusType.CRIT:
                    CritBonus += Math.Min(maxCritBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100);// between 0 and 0.07
                    break;

                case Data.BonusType.REGENMANA:
                    RegenManaBonus += UnityEngine.Random.Range(levelFloat * regenManaPerLevelMin, levelFloat * regenManaPerLevelMax); //  at lvl 100 : 20 -> 0.2/lvl max
                    break;
                case Data.BonusType.REGENHEALTH:
                    RegenHealthBonus += UnityEngine.Random.Range(regenHealthPerLevelMin * levelFloat, regenHealthPerLevelMax * levelFloat);
                    break;
                case Data.BonusType.ATTACKSPEED:
                    CdAttackBonus += Math.Min(maxCdAttackBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
                case Data.BonusType.CASTTIME:
                    CastTimeBonus += Math.Min(maxCastTimeBonusPerItem, (UnityEngine.Random.Range(levelFloat / 16, levelFloat / 14)) / 100); // between 0 and 0.07
                    break;
            }
        }

        int randomItemDataId;
        randomItemDataId = UnityEngine.Random.Range(0, Data.listOfItems[iconTypeId].Count);

        itemData = Data.listOfItems[iconTypeId][randomItemDataId];
    }



    /////////////////GETTERS AND SETTERS//////////////////////////////

    public ItemData ItemData
    {
        get { return itemData; }
        set { itemData = value; }
    }

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

    public float CdAttack
    {
        get
        {
            return cdAttack;
        }

        set
        {
            cdAttack = value;
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

    public float CdAttackBonus
    {
        get
        {
            return cdAttackBonus;
        }

        set
        {
            cdAttackBonus = value;
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

    public Data.LegendaryEffect LegendaryEffect
    {
        get
        {
            return legendaryEffect;
        }

        set
        {
            legendaryEffect = value;
        }
    }
}
