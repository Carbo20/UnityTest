using UnityEngine;
using System;

public class Hero {

    /* Principal Hero variable*/
    private int hp;
    private int mana;

    private bool isReady;
    private bool isDead;
    

    public Hero(int _hp,int _mana,int _strenght,int _inteligence, int _agility, int _vitality)
    {
        hp = _hp;
        Data.heroData.hpMax = _hp;
        mana = _mana;
        Data.heroData.strenght = _strenght;
        Data.heroData.intelligence = _inteligence;
        Data.heroData.agility = _agility;
        Data.heroData.vitality = _vitality;

        Data.heroData.xp = 0;
        Data.heroData.level = 1;
        Data.heroData.xpForNextLevel = 50; // [TODO] Maybe we have to search into a list wich amount of xp we need for the next lvl
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
        Data.heroData.xp = Data.heroData.xp + xp;
        if (xp >= Data.heroData.xpForNextLevel)
        {
            GetLevel();
        }
    }

    public void GetLevel()
    {
        Data.heroData.level++;
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
            return Data.heroData.strenght;
        }

        set
        {
            Data.heroData.strenght = value;
        }
    }

    public int Inteligence
    {
        get
        {
            return Data.heroData.intelligence;
        }

        set
        {
            Data.heroData.intelligence = value;
        }
    }

    public int Agility
    {
        get
        {
            return Data.heroData.agility;
        }

        set
        {
            Data.heroData.agility = value;
        }
    }

    public int Vitality
    {
        get
        {
            return Data.heroData.vitality;
        }

        set
        {
            Data.heroData.vitality = value;
        }
    }

    public int Damage
    {
        get
        {
            return Data.heroData.damage;
        }

        set
        {
            Data.heroData.damage = value;
        }
    }

    public int SpellDamage
    {
        get
        {
            return Data.heroData.spellDamage;
        }

        set
        {
            Data.heroData.spellDamage = value;
        }
    }

    public int Dodge
    {
        get
        {
            return Data.heroData.dodge;
        }

        set
        {
            Data.heroData.dodge = value;
        }
    }

    public int Critical
    {
        get
        {
            return Data.heroData.critical;
        }

        set
        {
            Data.heroData.critical = value;
        }
    }

    public int Speed
    {
        get
        {
            return Data.heroData.speed;
        }

        set
        {
            Data.heroData.speed = value;
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
            return Data.heroData.hpMax;
        }

        set
        {
            Data.heroData.hpMax = value;
        }
    }

    public int ManaMax
    {
        get
        {
            return Data.heroData.manaMax;
        }

        set
        {
            Data.heroData.manaMax = value;
        }
    }
}
