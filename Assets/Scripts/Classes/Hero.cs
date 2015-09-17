using System;

public class Hero {

    /* Principal Hero variable*/
    private int hp;
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

    public Hero(int hp,int mana,int strenght,int inteligence, int agility, int vitality)
    {
        this.hp = hp;
        this.mana = mana;
        this.strenght = strenght;
        this.inteligence = inteligence;
        this.agility = agility;
        this.vitality = vitality;

        xp = 0;
        level = 1;
        xpForNextLevel = 50; // [TODO] Maybe we have to search into a list wich amount of xp we need for the next lvl
        isReady = false;
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
}
