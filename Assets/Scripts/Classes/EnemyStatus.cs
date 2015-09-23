using UnityEngine;
using System.Collections;

public abstract class EnemyStatus : MonoBehaviour {
    
    private int hpMax;
    private int manaMax;
    private int hp;
    private int mana;

    private int regenHp;
    private int regenMana;

    private int armor;

    private int strenght;
    private int intelligence;
    private int agility;
    private int vitality;

    private int speed;
    private int damage;
    private int spellDamage;
    private float dodge;
    private float critical;

    private float cdAttack;
    private Data.EnemySkillType[] skillAvailable;

    /* We have to put the IA monster into DoAnAction wich choose wich action
    the monster will do --------------------------------------------------*/
    public abstract void InitStatus();
    public abstract Data.EnemySkillType DoAnAction();


    /* Getter and Setter */

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

    public int RegenHp
    {
        get
        {
            return regenHp;
        }

        set
        {
            regenHp = value;
        }
    }

    public int RegenMana
    {
        get
        {
            return regenMana;
        }

        set
        {
            regenMana = value;
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

    public int Intelligence
    {
        get
        {
            return intelligence;
        }

        set
        {
            intelligence = value;
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

    public float Dodge
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

    public float Critical
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

    public float CdAttack
    {
        get
        {
            return cdAttack;
        }

        set
        {
            cdAttack = value;
        }
    }

    public Data.EnemySkillType[] SkillAvailable
    {
        get
        {
            return skillAvailable;
        }

        set
        {
            skillAvailable = value;
        }
    }
}
