using UnityEngine;
using System.Collections;

public class Item
{
    /* Item's Variables */
    private int attackValues;
    private float attackSpeed;
    private int armor;
    Sprite icon;
    string name;
    string description;

    int strenBonus, intelBonus, agiBonus, vitalBonus, attackBonus, spellBonus, manaBonus, regenManaBonus, dodgeBonus, critBonus, regenHealthBonus, healthBonus;
    float attackSpeedBonus, castTimeBonus; // represented by a %, it will reduce the delay after an attack or a cast is done

    Data.SlotType slotType;

    enum BonusType { STREN, INTEL, AGI, VITAL, ATTACK, SPELL, MANA, REGENMANA, DODGE, CRIT, REGENHEALTH, HEALTH, ATTACKSPEED, CASTTIME };

    //public enum SlotType { HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS };
    
    void GenerateItem(int level, int magicFind)
    {
        int itemSlotType, itemType, itemQuality;
        //int rand = UnityEngine.Random.Range(0, max); max exclu  // value au lieu de range pour les float
        //rand pour determiner quel type d'item va drop : emplacement + type d'item (hache, épée,...)
        //rand pour determiner quel QUALITE d'item ce sera : Normal : 0 bonus, magic : 1 à 2 bonus, legendaire 3 à 4 bonus + un effet
        //rands pour déterminer quels BONUS aura l'item
        //rands sur chaque bonus en fonction du lvl pour déterminer la VALEUR du bonus
        //si la qualité de l'item est légendaire on ajoute un effet particulier
        //on génére le nom de l'objet de manière automatique

        itemSlotType = UnityEngine.Random.Range(0, Data.ItemTypeCount); // Type de slot d'item /SlotType : HEAD, CHEST, HANDS, LEGS, FEET, ONEHAND, TWOHANDS    ///PB : 2 chance sur 7 d'avoir une arme et 5 / 7 d'avoir une armure
        Debug.Log("itemSlotType " + itemSlotType);

        if(itemSlotType == Data.SlotType.ONEHAND.GetHashCode())
        {

        }

        itemType = UnityEngine.Random.Range(0, 3); // Type de l'item : weapon, armor ou shield
        itemQuality = UnityEngine.Random.Range(0, 3); // Qualite de l'item : normal, magic, legendaire
        Debug.Log("itemQuality " + itemQuality);

        if(item)




    }



}
