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

    public int speed; // Base, nough' said!
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

    public float damagePerStats; //  damage Strength modification Bonus%1
    public float armorPerStats; //  armor Strength modification Bonus%2
    public float cdAttackPerStats; // cdAttack Strength modification Bonus%3

    public float spellDamagePerStats; // spellDamage intel modification Bonus%1
    public float manaMaxPerStats; // manaMax Intel modification Bonus%2
    public float regenManaPerStats; // regenMana Intel modification Bonus%3
    public float cdSpellReducPerStats; // cdSpell Intel modification Bonus%4

    public float criticalPerStats; // critical agility modification Bonus%1
    public float dodgePerStats; // dodge agility modification Bonus%2

    public float hpMaxPerStats; // hpMax Vitality Modif Bonus%1
    public float regenHpPerStats; // regenHp Vitality Modif Bonus%2

    public float cdSpellReduc; // cdSpell Item bonus

    public float cdAttackBase; // ItemBase 
    public float cdAttackModified; // ItemBase modified by total amount of cdAttack bonus
    public float cdAttackBonusTotal; // Item bonus

    public int nbSkillAvailable;
    public int nbIAOrderAvailable;

    public int xp;
    public int xpForNextLevel;
    public int level;

    public Data.SkillType[] skillAvailable;
    public List<Data.LegendaryEffect> legendaryEffectAvailable;

    public HeroData()
    {
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
    }


    public int GetXPForLevel(int lvl)
    {
        return (lvl * (lvl - 1) * 10) + 100;
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
        speed = 10;
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
