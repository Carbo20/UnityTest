using System;
using UnityEngine;


/// <summary>
/// To know how enemy secondary stats should look like don't forget to check the STATS calc document
/// NB : concerning the primary stats, an enemy shouldn't have those as they are not useful in anyway to balance the game nor are they useful from a gameplay standpoint.  TO DISCUSS
/// </summary>
public class Enemy
{
    /* Principal Enemy variable*/
    private bool isBoss; //TODO add it to the creation of the enemy
    private int level;
    private int armor;
    private int hp;
    private int hpMax;
    private int mana;
    private int manaMax;
    private int strenght;
    private int inteligence;
    private int agility;
    private int vitality;

    /* Secondary Enemy variable*/
    private int damage;
    private int spellDamage;
    private int dodge;
    private int critical;
    private int speed;

    private bool isReady;
    private bool isDead;
    private bool isCasting;

    private int magicFind;
    private int numberOfItemLootedMax;
    private int bonusGold;

    private int numberOfSkills;

    public Enemy(int _level, int _hp, int _mana, int _strenght, int _inteligence, int _agility, int _vitality, int _armor)
    {
        bonusGold = 1;// TODO temporary just a reminder it now exists and should be used
        numberOfItemLootedMax = 2;// TODO temporary just a reminder it now exists and should be used
        magicFind = 0;  // TODO temporary just a reminder it now exists and should be used
        isBoss = false; // TODO temporary just a reminder it now exists and should be used
        Level = _level;
        hp = _hp;
        hpMax = _hp;
        mana = _mana;
        manaMax = _mana;
        strenght = _strenght;
        inteligence = _inteligence;
        agility = _agility;
        vitality = _vitality;
        armor = _armor;

        damage = 5;

        isReady = false;
        isDead = false;
        isCasting = false;
    }

    public void TakeDamage(int damage, int heroLevel)
    {
        float damageReduc;
        int trueDamage;

        Debug.Log("Enemy hp : " + hp);

        // TODO : don't forget to take dodge into account wherever takeDamage is called
        /*[TODO] Put TakeDamage Animation here*/

        damageReduc = (float)Math.Min(80, Armor/ heroLevel) / 100;
        trueDamage = (int)(damage * (1 - damageReduc));

        Hp = Hp - trueDamage;
        if (Hp <= 0)
        {
            Death();
        }
    }

    public void UseMana(int manaAmount)
    {
        /*[TODO]Put LostMana animation here*/
        mana = mana - manaAmount;
    }

    public int DoDamage()
    {
        return damage;
    }

    private void Death()
    {
        isDead = true;

        //loot gold
        Data.inventory.LootGold(level, isBoss, bonusGold);

        //loot item(s)
        int numberOfItemLooted = UnityEngine.Random.Range(0, numberOfItemLootedMax+1);
        Data.inventory.LootItem(numberOfItemLooted, magicFind, level);
        

        //give xp            // TODO use GetXpFromEnemy(int level, Boolean isBoss) from hero
    }


    /*** Getter and Setter ***/

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Mana
    {
        get
        {
            return mana;
        }

        set
        {
            mana = value;
        }
    }

    public int Strenght
    {
        get
        {
            return strenght;
        }

        set
        {
            strenght = value;
        }
    }

    public int Inteligence
    {
        get
        {
            return inteligence;
        }

        set
        {
            inteligence = value;
        }
    }

    public int Agility
    {
        get
        {
            return agility;
        }

        set
        {
            agility = value;
        }
    }

    public int Vitality
    {
        get
        {
            return vitality;
        }

        set
        {
            vitality = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public int SpellDamage
    {
        get
        {
            return spellDamage;
        }

        set
        {
            spellDamage = value;
        }
    }

    public int Dodge
    {
        get
        {
            return dodge;
        }

        set
        {
            dodge = value;
        }
    }

    public int Critical
    {
        get
        {
            return critical;
        }

        set
        {
            critical = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public bool IsReady
    {
        get
        {
            return isReady;
        }

        set
        {
            isReady = value;
        }
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }

        set
        {
            isDead = value;
        }
    }

    public bool IsCasting
    {
        get
        {
            return isCasting;
        }

        set
        {
            isCasting = value;
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

    public bool IsBoss
    {
        get
        {
            return isBoss;
        }

        set
        {
            isBoss = value;
        }
    }

    public int MagicFind
    {
        get
        {
            return magicFind;
        }

        set
        {
            magicFind = value;
        }
    }

    public int NumberOfItemLootedMax
    {
        get
        {
            return numberOfItemLootedMax;
        }

        set
        {
            numberOfItemLootedMax = value;
        }
    }

    public int BonusGold
    {
        get
        {
            return bonusGold;
        }

        set
        {
            bonusGold = value;
        }
    }

    public bool IsBoss1
    {
        get
        {
            return isBoss;
        }

        set
        {
            isBoss = value;
        }
    }

    public int HpMax
    {
        get
        {
            return hpMax;
        }

        set
        {
            hpMax = value;
        }
    }

    public int ManaMax
    {
        get
        {
            return manaMax;
        }

        set
        {
            manaMax = value;
        }
    }

    public bool IsBoss2
    {
        get
        {
            return isBoss;
        }

        set
        {
            isBoss = value;
        }
    }

    public int NumberOfSkills
    {
        get
        {
            return numberOfSkills;
        }

        set
        {
            numberOfSkills = value;
        }
    }
}
