using UnityEngine;
using System;
using UnityEngine.UI;

public class Hero {

    /* Principal Hero variable*/
    private int hp;
    private int mana;

    private bool isReady;
    private bool isDead;
    private Slider HealthSlider;
    

    public Hero(int _hp,int _mana,int _strenght,int _inteligence, int _agility, int _vitality)
    {
        hp = _hp;
        Data.heroData.hpMax = _hp;
        mana = _mana;
        Data.heroData.manaMax = _mana;
        Data.heroData.strenght = _strenght;
        Data.heroData.intelligence = _inteligence;
        Data.heroData.agility = _agility;
        Data.heroData.vitality = _vitality;
        Data.heroData.cdAttackBase = 3;

        Data.heroData.xp = 0;
        Data.heroData.level = 1;
        Data.heroData.xpForNextLevel = 50; // [TODO] Maybe we have to search into a list wich amount of xp we need for the next lvl
        isReady = false;
        isDead = false;
        HealthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        HealthSlider.maxValue = Data.heroData.hpMax;
        hp = (hp / 2) - 1;
    }

    public void TakeDamage(int damage)
    {

        /*[TODO] Put TakeDamage Animation here*/
        if (hp - damage > 0)
        {
            Hp = Hp - damage;
            UpdateHealthBar();
            Debug.Log("hp :" + Hp);
        }
        else
        {
            hp = 0;
            UpdateHealthBar();
            Death();
        }
    }

    public int DoDammage(int damage)
    {
        int value = damage; //[TODO] Use the formula here
        return value;
    }

    public void UseMana(int manaAmount)
    {
        /*[TODO]Put LostMana animation here*/
        mana = mana - manaAmount;
    }

    public void RegainMana(int manaAmount)
    {
        /*[TODO]Put RegainMana animation here*/
        if (mana + manaAmount < ManaMax) mana = mana + manaAmount;
        else mana = ManaMax;
    }

    public void RegainHp(int hpAmount)
    {
        if (Hp + hpAmount < HpMax) Hp = Hp + hpAmount;
        else Hp = HpMax;
        UpdateHealthBar();
    }

    private void Death()
    {
        isDead = true;
        //[TODO] Put the death animation here
        //[TODO] if we have to do something when the hero die
    }

    public void GetXp(int xp)
    {
        /*[TODO] Put GetXp animation here*/
        Data.heroData.xp = Data.heroData.xp + xp;
        if (xp >= Data.heroData.xpForNextLevel)
        {
            LevelUP();
        }
    }

    public void LevelUP()
    {
        Data.heroData.LevelUP();
    }

    private void UpdateHealthBar()
    {
        HealthSlider.value = Hp;
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

    public float Dodge
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

    public float Critical
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
