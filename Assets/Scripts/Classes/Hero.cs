using UnityEngine;
using System;
using UnityEngine.UI;

public class Hero
{

    /* Principal Hero variable*/
    private int hp;
    private int mana;

    private bool isReady;
    private bool isDead;
    private Slider HealthSlider;
    private Slider xpSlider, hpSlider, manaSlider;
    private Text levelText;
    public Hero(int _hp, int _mana, int _strenght, int _inteligence, int _agility, int _vitality)
    {
        hp = _hp;
        
        mana = _mana;
        isReady = false;
        isDead = false;
        initGameobject();
        updateAllUI();
    }

    private void initGameobject()
    {
        xpSlider  = GameObject.Find("XPSlider").GetComponent<Slider>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        hpSlider  = GameObject.Find("HeroHPSlider").GetComponent<Slider>();
        manaSlider = GameObject.Find("HeroManaSlider").GetComponent<Slider>();
    }


    /// <summary>
    /// Uses the reduction of damage from the armor         // TODO : don't forget to take dodge into account wherever takeDamage is called
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="ennemyLevel"></param>
    public void TakeDamage(int damage, int ennemyLevel)
    {
        float damageReduc;
        int trueDamage;

        
        /*[TODO] Put TakeDamage Animation here*/

        damageReduc = (float)Math.Min(80, Data.heroData.armor / ennemyLevel)/100;
        trueDamage = (int)(damage * (1f - damageReduc));
        //Debug.Log("trueDamage :" + trueDamage + "  damage  " + damage + "   (1 - damageReduc/100) " + (1 - damageReduc / 100) + " damageReduc   "  + damageReduc*100 + " Data.heroData.armor  " + Data.heroData.armor + "  ennemyLevel " + ennemyLevel);

        if (Hp - trueDamage > 0)
        {
            Hp = Hp - trueDamage;
            Debug.Log("dammage :" + trueDamage);
            Debug.Log("hp :" + Hp);
        }
        else
        {
            hp = 0;
            Death();
        }
        updateAllUI();
    }

    /// <summary>
    /// Used to decide if a physical is gonna do damage or not
    /// </summary>
    /// <returns></returns>
    public Boolean IsDodge()
    {
        int randomDodge;
        randomDodge = UnityEngine.Random.Range(0, 100);
        float chancesOfDodge = (Data.heroData.dodge * (1f + Data.heroData.dodgePerAgil * Data.heroData.agility));

        if (randomDodge < chancesOfDodge)
            return true;

        return false;
    }

    /// <summary>
    /// Used to decide if a hit is a critical or not
    /// </summary>
    /// <returns></returns>
    public Boolean IsCritical()
    {
        int randomCrit = UnityEngine.Random.Range(0, 100);
        float chancesOfCrit = (Data.heroData.critical * (1f + Data.heroData.criticalPerAgil * Data.heroData.agility));

        if (randomCrit < chancesOfCrit)
            return true;
        return false;
    }

    /// <summary>
    /// Attack damage of the hero
    /// </summary>
    /// <param name="isItACrit"></param>
    /// <returns></returns>
    public int DoDammage(bool isItACrit)
    {
        int damageSent;

        if (isItACrit)
            damageSent = (int)(Data.heroData.damage * Data.heroData.damagePerStrength * Data.heroData.strenght * Data.heroData.critMultiplier) ;
        else
        {
            Debug.Log(" damageSentBefore = " + Data.heroData.damage);
            Debug.Log(" Data.heroData.damage * (1f + Data.heroData.damagePerStrength * Data.heroData.strenght) " + Data.heroData.damage * (1f + Data.heroData.damagePerStrength * Data.heroData.strenght));
            Debug.Log(" (int)(Data.heroData.damage * (1f + Data.heroData.damagePerStrength * Data.heroData.strenght)) " +(int)(Data.heroData.damage * (1f + Data.heroData.damagePerStrength * Data.heroData.strenght)));
            damageSent = (int)(Data.heroData.damage * (1f + Data.heroData.damagePerStrength * Data.heroData.strenght));
            Debug.Log(" damageSentAfter = " + damageSent);
        }

        return damageSent;
    }

    public int DoDamageMagic(int damageMagic)
    {
        int damageSent;

        damageSent = (int)(damageMagic * (1f+(Data.heroData.spellDamage*(1f+Data.heroData.spellDamagePerIntel*Data.heroData.intelligence))));
        return damageSent;
    }

    public void UseMana(int manaAmount)
    {
        /*[TODO]Put LostMana animation here*/
        mana = mana - manaAmount;
    }

    /// <summary>
    /// Total regen mana of the hero, to be used every x second(s)
    /// </summary>
    public void RegenMana()
    {
        // TODO animation here if needed
        int amountOfManaRecovered = (int)( Data.heroData.regenMana * (1f + Data.heroData.regenManaPerIntel*Data.heroData.intelligence));

        if (mana + amountOfManaRecovered < ManaMax)
            mana = mana + amountOfManaRecovered;
        else mana = ManaMax;
    }

    public void RegainMana(int manaAmount)
    {
        /*[TODO]Put RegainMana animation here*/
        if (mana + manaAmount < ManaMax) mana = mana + manaAmount;
        else mana = ManaMax;
    }

    /// <summary>
    /// Total regen mana of the hero, to be used every x second(s)
    /// </summary>
    public void RegenHp()
    {
        // TODO animation here if needed
        int amountOfHpRecovered = (int)(Data.heroData.regenHp * (1f + Data.heroData.regenHpPerVital * Data.heroData.vitality));

        if (Hp + amountOfHpRecovered < HpMax)
            Hp = Hp + amountOfHpRecovered;
        else Hp = HpMax;
    }

    public void RegainHp(int hpAmount)
    {
        if (Hp + hpAmount < HpMax) Hp = Hp + hpAmount;
        else Hp = HpMax;
        updateAllUI();
    }

    private void Death()
    {
        isDead = true;
        //[TODO] Put the death animation here
        //[TODO] if we have to do something when the hero die  // YES lose stuff
    }

    public void GetXp(int xp)
    {
        if (Data.heroData.level == Data.levelMax) return;
        /*[TODO] Put GetXp animation here*/
        Data.heroData.xp = Data.heroData.xp + xp;
        if (Data.heroData.xp >= Data.heroData.xpForNextLevel)
        {
            LevelUP();
        }
        UpdateXPBar();
    }

    public int XpFromEnemy(int level, Boolean isBoss)
    {
        int xp;
        if (!isBoss)
            xp = (int) ( ((level * (level - 1) * 10) + 100) / Data.numberOfStdEnemyForLvl1 * (1 + level * Data.riseInNumberOfEnemyToNextLvl) );
        else
            xp = (int)(((level * (level - 1) * 10) + 100) / Data.numberOfBossEnemyForLvl1 * (1 + level * Data.riseInNumberOfEnemyToNextLvl)); 

        return xp;
    }

    public void LevelUP()
    {
        if (Data.heroData.level == Data.levelMax) return;

        Data.heroData.LevelUP();
        
        if (Data.heroData.level % Data.iaData.nbLvlRequireToAquireNewOrder == 0)
        {
            if (Data.iaData.nbOrder < Data.iaData.nbOrderMax)
                Data.iaData.nbOrder++;
            Debug.Log("Slot d'ia gagné! (" + Data.iaData.nbOrder + ")");
        }
        updateAllUI();
    }

    private void updateAllUI()
    {
        //UpdateHealthBar();
        UpdateLevelText();
        UpdateXPBar();
        UpdateHPBar();
    }

    private void UpdateXPBar()
    {
        xpSlider.wholeNumbers = true;
        if (Data.heroData.level == 1)
            xpSlider.minValue = 0;
        else
            xpSlider.minValue = Data.heroData.GetXPForLevelCumulated(Data.heroData.level - 1);
        xpSlider.maxValue = Data.heroData.GetXPForLevelCumulated(Data.heroData.level);
        xpSlider.value = Data.heroData.xp;
    }

    private void UpdateLevelText()
    {
        levelText.text = Data.heroData.level.ToString();
    }

    private void UpdateHPBar()
    {
        hpSlider.wholeNumbers = true;
        hpSlider.minValue = 0;
        hpSlider.maxValue = Data.heroData.hpMax;
        hpSlider.value = hp;
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
