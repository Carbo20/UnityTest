using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[Serializable()]
public class HeroData
{

    /* Principal Hero variable*/
    public float heroActivation;
    public int strenght; // Base + Item bonus
    public int intelligence; // Base + Item bonus
    public int agility; // Base + Item bonus
    public int vitality; // Base + Item bonus

    public int armor; // Base + Item bonus

    /* Secondary Hero variable*/
    public int hpMax; // Base + Item bonus
    public int manaMax; // Base + Item bonus

    public int regenHp; // Base + Item bonus
    public int regenMana; // Base + Item bonus

    public int damage; // Base + Weapon damage + Item bonus
    public int spellDamage; // Base + Item bonus
    public float dodge; // Base + Item bonus
    public float critical; // Base + Item bonus


    /// these float are going to up the different secondary stats by a certain percent
    /// each secondary stat receive a % bonus based on the points in their corresponding primary stat

    public float BonusPerStats1; // ex 2%
    public float BonusPerStats2; // ex 1%
    public float BonusPerStats3; // ex 0.5%
    public float BonusPerStats4; // ex 0.25%

    public float damagePerStrength; //  damage Strength modification Bonus1
    public float armorPerStrength; //  armor Strength modification Bonus2
    public float cdAttackPerStrength; // cdAttack Strength modification Bonus3

    public float spellDamagePerIntel; // spellDamage intel modification Bonus1
    public float manaMaxPerIntel; // manaMax Intel modification Bonus2
    public float regenManaPerIntel; // regenMana Intel modification Bonus3
    public float cdSpellReducPerIntel; // cdSpell Intel modification Bonus4

    public float criticalPerAgil; // critical agility modification Bonus1
    public float dodgePerAgil; // dodge agility modification Bonus2

    public float hpMaxPerVital; // hpMax Vitality Modif Bonus1
    public float regenHpPerVital; // regenHp Vitality Modif Bonus2

    public float cdSpellReduc; // cdSpell Item bonus

    public float cdAttackBase; // ItemBase 
    public float cdAttackModified; // ItemBase modified by total amount of cdAttack bonus
    public float cdAttackBonusTotal; // Item bonus

    public float critMultiplier; // % of a crit attack ex : 200%

    public int nbSkillAvailable;
    public int nbIAOrderAvailable;

    public int xp;
    public int xpForNextLevel;
    public int level;

    public Data.SkillType[] skillAvailable;
    public List<Data.LegendaryEffect> legendaryEffectAvailable;

    public HeroData()
    {
        // TODO temporary? BEGIN
        heroActivation = 2;
        critMultiplier = 2f;
        BonusPerStats1 = 0.02f; 
        BonusPerStats2 = 0.01f;
        BonusPerStats3 = 0.005f;
        BonusPerStats4 = 0.0025f;

        damagePerStrength = BonusPerStats1;
        armorPerStrength = BonusPerStats2;
        cdAttackPerStrength = BonusPerStats3;

        spellDamagePerIntel = BonusPerStats1;
        manaMaxPerIntel = BonusPerStats2;
        regenManaPerIntel = BonusPerStats3;
        cdSpellReducPerIntel = BonusPerStats4;

        criticalPerAgil = BonusPerStats1; 
        dodgePerAgil = BonusPerStats2;

        hpMaxPerVital = BonusPerStats1;
        regenHpPerVital = BonusPerStats2;

        critMultiplier = 2f;

        // TODO temporary? END
        
        //[TODO] update dat stuff!
        nbSkillAvailable = 6;
        nbIAOrderAvailable = 4;
        skillAvailable = new Data.SkillType[nbSkillAvailable];

        legendaryEffectAvailable = new List<Data.LegendaryEffect>();

        /* Initialisation of skillAvailable juste for the begining of the game */
        skillAvailable[0] = Data.SkillType.ATTACK;
        skillAvailable[1] = Data.SkillType.FIREBALL;
        skillAvailable[2] = Data.SkillType.HEAL;

    }

    public void LevelUP()
    {
        level++;
        xpForNextLevel += GetXPForLevel(level);

        //TODO it should change when classes will be added but it is here for test purposes of the progression system if any can occur:
        strenght = UnityEngine.Random.Range(1, Data.maxStatUpgradePerLevel);
        intelligence = UnityEngine.Random.Range(1, Data.maxStatUpgradePerLevel);
        agility = UnityEngine.Random.Range(1, Data.maxStatUpgradePerLevel);
        vitality = UnityEngine.Random.Range(1, Data.maxStatUpgradePerLevel);
    }

    public int GetXPForLevel(int lvl)
    {
        return (lvl * (lvl - 1) * 10) + 100;
    }

    public int GetXPForLevelCumulated(int lvl)
    {
        if (lvl == 1) return 100;
        else return GetXPForLevel(lvl) + GetXPForLevelCumulated(lvl - 1);
    }

    public void UpdateCdAttackModified()
    {
        cdAttackModified = cdAttackBase - (cdAttackBase * cdAttackBonusTotal);
    }

    public void initLvl1()
    {
        level = 1;
        xp = 0;
        xpForNextLevel = GetXPForLevel(level);
        hpMax = 20;
        manaMax = 20;
        regenHp = 0;
        regenMana = 0;
        armor = 10;
        strenght = 10;
        intelligence = 10;
        agility = 10;
        vitality = 10;
        damage = 10;
        spellDamage = 10;
        dodge = 5;
        critical = 5;
        cdAttackBase = 0;
        cdAttackModified = 0;
        cdAttackBonusTotal = 0;
        Data.iaData.nbOrder = 3;
    }

    public void LoadHeroData()
    {
        string path = Application.persistentDataPath + "/heroData";

        if (File.Exists(path))
        {
            Stream stream = File.OpenRead(path);
            BinaryFormatter deserializer = new BinaryFormatter();
            Data.heroData = (HeroData)deserializer.Deserialize(stream);
            stream.Close();
        }
        else
        {
            initLvl1();
            SaveHeroData();
        }
    }

    public void SaveHeroData()
    {
        Stream stream = File.Create(Application.persistentDataPath + "/heroData");
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(stream, this);
        stream.Close();
        Debug.Log("heroData sauvegardé dans " + Application.persistentDataPath + "/heroData");
    }
}
