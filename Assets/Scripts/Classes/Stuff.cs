using UnityEngine;
using System.Collections;

public class Stuff
{
    /* Stuff Variable */
    private int attackValues;
    private int attackSpeed;
    private int armor;
    Sprite icon;
    string name;
    string description;
    BonusType strenBonus, intelBonus, agiBonus, healthBonus, spellBonus, critBonus, dodgeBonus, regenHealthBonus, regenManaBonus, attackBonus, manaBonus;
    
    /* Stuff Enum */
    enum BonusType { strenBonus, intelBonus, agiBonus, healthBonus, spellBonus, critBonus, dodgeBonus, regenHealthBonus, regenManaBonus, attackBonus, manaBonus }
    enum SlotType { head, oneHand, twoHands, feet, chest, legs, hands };
       
}
