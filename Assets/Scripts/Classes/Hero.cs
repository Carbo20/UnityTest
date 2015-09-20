﻿using UnityEngine;
using System;

public class Hero {

    /* Principal Hero variable*/
    private int hpMax;
    private int hp;
    private int manaMax;
    private int mana;
    private int strenght;
    private int inteligence;
    private int agility;
    private int vitality;

    /* Secondary Hero variable*/
    private int damage;
    private int spellDamage;
    private int dodge;
    private int critical;
    private int speed;

    private int xp;
    private int xpForNextLevel;
    private int level;

    private bool isReady;
    private bool isDead;
    

    public Hero(int _hp,int _mana,int _strenght,int _inteligence, int _agility, int _vitality)
    {
        hp = _hp;
        hpMax = _hp;
        mana = _mana;
        strenght = _strenght;
        inteligence = _inteligence;
        agility = _agility;
        vitality = _vitality;

        xp = 0;
        level = 1;
        xpForNextLevel = 50; // [TODO] Maybe we have to search into a list wich amount of xp we need for the next lvl
        isReady = false;
        isDead = false;

        hp = (hp / 2) - 1;
    }

    public void TakeDamage(int damage)
    {
        Hp = Hp - damage;
        if(Hp < 0)
        {
            Death();
        }
    }

    public int DoDammage(int damage)
    {
        int value = damage; //[TODO] Use the formula here
        return value;
    }

    private void Death()
    {
        isDead = true;
        //[TODO] if we have to do something when the hero die
    }

    public void GetXp(int xp)
    {
        this.xp = this.xp + xp;
        if(xp >= xpForNextLevel)
        {
            GetLevel();
        }
    }

    public void GetLevel()
    {
        level++;
        //[TODO] Do some stuff after a lvl up, stats up or something like this
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
}
