using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public int xp;
    public int xpForNextLevel;
    public int level;

    public Data.SkillType[] skillAvailable;
    public List<Data.LegendaryEffect> legendaryEffectAvailable;

    public HeroData()
    {
        //[TODO] update dat stuff!
        nbSkillAvailable = 6;
        skillAvailable = new Data.SkillType[nbSkillAvailable];

        legendaryEffectAvailable = new List<Data.LegendaryEffect>();

        /* Initialisation of skillAvailable juste for the begining of the game */
        skillAvailable[0] = Data.SkillType.ATTACK;
        skillAvailable[1] = Data.SkillType.FIREBALL;
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
}
