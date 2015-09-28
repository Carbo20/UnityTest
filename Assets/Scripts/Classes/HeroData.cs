using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[Serializable()]
public class HeroData {

    /* Principal Hero variable*/
    public int hpMax;
    public int manaMax;

    public int regenHp;
    public int regenMana;

    public int armor;

    public int strenght;
    public int intelligence;
    public int agility;
    public int vitality;

    /* Secondary Hero variable*/
    public int speed;
    public int damage;
    public int spellDamage;
    public float dodge;
    public float critical;

    public float cdAttackBase;
    public float cdAttackModified;
    public float cdAttackBonusTotal;

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
        nbIAOrderAvailable = 3;
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
