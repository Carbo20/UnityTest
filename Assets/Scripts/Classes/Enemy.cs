using System;
using UnityEngine;

public class Enemy
{

    /* Principal Enemy variable*/
    private int level;
    private int hp;
    private int mana;
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

    public Enemy(int _level, int _hp, int _mana, int _strenght, int _inteligence, int _agility, int _vitality)
    {
        Level = _level;
        hp = _hp;
        mana = _mana;
        strenght = _strenght;
        inteligence = _inteligence;
        agility = _agility;
        vitality = _vitality;

        damage = 27;

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

        // Armor/heroLevel
        damageReduc = Data.heroData.armor / heroLevel;
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

        if (true) //TODO: conditions de loot
        {
            Item it = new Item(level, 1); //TODO: level de l'item et magicFind
            Data.inventory.AddItem(it);
            Data.inventory.SaveInventory();
            Debug.Log("item looted : " + it.Name + " (" + it.SlotType.ToString() + ") lvl:" + it.Level);
        }
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
}
