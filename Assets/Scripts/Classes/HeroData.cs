using UnityEngine;
using System.Collections;

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

    public float cdAttack;
    public int nbSkillAvailable;

    public int xp;
    public int xpForNextLevel;
    public int level;

    public Data.SkillType[] skillAvailable;

    public HeroData()
    {
        nbSkillAvailable = 6;
        skillAvailable = new Data.SkillType[nbSkillAvailable];
    }
}
