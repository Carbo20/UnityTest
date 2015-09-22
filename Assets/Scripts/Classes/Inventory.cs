using System.Collections.Generic;

public class Inventory {

    public List<List<Item>> items;

    public bool gotTwoHandWeapon;
    public bool fillRightHand;
    public int HeadItemID;
    public int ChestItemID;
    public int HandsItemID;
    public int LegsItemID;
    public int FeetItemID;
    public int RightHandItemID;
    public int LeftHandItemID;

    public Inventory()
    {
        items = new List<List<Item>>();
        for (int i = 0; i < Data.SlotTypeCount; i++)
            items.Add(new List<Item>());

        gotTwoHandWeapon = false;
        fillRightHand = true;

        //un emplacement vide est symbolisé par -1
        HeadItemID      = -1;
        ChestItemID     = -1;
        HandsItemID     = -1;
        LegsItemID      = -1;
        FeetItemID      = -1;
        RightHandItemID = -1;
        LeftHandItemID  = -1;
        
    }

    public void unequipeItem(Item it)
    {
        Data.heroData.hpMax -= it.HealthBonus;
        Data.heroData.manaMax -= it.ManaBonus;
        Data.heroData.strenght -= it.StrenBonus;
        Data.heroData.intelligence -= it.IntelBonus;
        Data.heroData.agility -= it.AgiBonus;
        Data.heroData.vitality -= it.VitalBonus;
        Data.heroData.damage -= it.AttackValue;
        Data.heroData.spellDamage -= it.SpellBonus;
        Data.heroData.dodge -= it.DodgeBonus;
        Data.heroData.critical -= it.CritBonus;
        Data.heroData.armor -= it.Armor;

        Data.heroData.cdAttack -= it.CastTimeBonus;
    }


    public void equipItem(Item it)
    {

        Data.heroData.hpMax += it.HealthBonus;
        Data.heroData.manaMax += it.ManaBonus;
        Data.heroData.strenght += it.StrenBonus;
        Data.heroData.intelligence += it.IntelBonus;
        Data.heroData.agility += it.AgiBonus;
        Data.heroData.vitality += it.VitalBonus;
        Data.heroData.damage += it.AttackValue;
        Data.heroData.spellDamage += it.SpellBonus;
        Data.heroData.dodge += it.DodgeBonus;
        Data.heroData.critical += it.CritBonus;
        Data.heroData.armor += it.Armor;

        Data.heroData.cdAttack += it.CastTimeBonus;

    }
    /// <summary>
    /// Equip d'item it de type st
    /// </summary>
    /// <param name="st">Type de l'item</param>
    /// <param name="it">index de l'item</param>
    public void Equip(Data.SlotType st, int it)
    {
        switch (st)
        {

            case Data.SlotType.HEAD: 
                if (HeadItemID != -1) 
                    unequipeItem(items[(int)Data.SlotType.HEAD][HeadItemID]);
                HeadItemID = it; 
                equipItem(items[(int)Data.SlotType.HEAD][HeadItemID]);
                break;
            case Data.SlotType.CHEST:
                if (ChestItemID != -1)
                    unequipeItem(items[(int)Data.SlotType.CHEST][ChestItemID]);
                ChestItemID = it;
                equipItem(items[(int)Data.SlotType.CHEST][ChestItemID]);
                break;
            case Data.SlotType.HANDS:
                if (HandsItemID != -1)
                    unequipeItem(items[(int)Data.SlotType.HANDS][HandsItemID]);
                HandsItemID = it; 
                equipItem(items[(int)Data.SlotType.HANDS][HandsItemID]);
                break;
            case Data.SlotType.LEGS: 
                if(LegsItemID != -1)
                    unequipeItem(items[(int)Data.SlotType.LEGS][LegsItemID]);                    
                LegsItemID = it;
                equipItem(items[(int)Data.SlotType.LEGS][LegsItemID]);
                break;
            case Data.SlotType.FEET: 
                if(FeetItemID != -1)
                    unequipeItem(items[(int)Data.SlotType.FEET][FeetItemID]);
                FeetItemID = it;
                equipItem(items[(int)Data.SlotType.FEET][FeetItemID]);
                break;
            case Data.SlotType.TWOHANDS:
                if (!gotTwoHandWeapon)
                {
                    if (RightHandItemID != -1) unequipeItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                    if (LeftHandItemID != -1) unequipeItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                }
                else
                    if (LeftHandItemID != -1) unequipeItem(items[(int)Data.SlotType.TWOHANDS][LeftHandItemID]);
                gotTwoHandWeapon = true;
                RightHandItemID = -1;
                LeftHandItemID = it;
                equipItem(items[(int)Data.SlotType.TWOHANDS][LeftHandItemID]);
                break;
            case Data.SlotType.ONEHAND:
                if (gotTwoHandWeapon)
                {
                    if (LeftHandItemID != -1) unequipeItem(items[(int)Data.SlotType.TWOHANDS][LeftHandItemID]);
                    LeftHandItemID = -1;
                    RightHandItemID = it;
                    equipItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                }
                else
                {
                    if (RightHandItemID == it || LeftHandItemID == it) break;
                    if (RightHandItemID == -1)
                    {
                        RightHandItemID = it;
                        equipItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                    }
                    else if (LeftHandItemID == -1)
                    {
                        LeftHandItemID = it;
                        equipItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                    }
                    else if (fillRightHand)
                    {
                        unequipeItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                        RightHandItemID = it;
                        equipItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                        fillRightHand = false;
                    }
                    else 
                    {
                        unequipeItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                        LeftHandItemID = it;
                        equipItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                        fillRightHand = true; 
                    }
                }
                gotTwoHandWeapon = false;
                break;
        }

    }

    //TODO
    /*
     public void LoadInventoryFromXML()
     {
      
     }
     */

    //TODO
    /*
     public void SaveInventoryFromXML()
     {
      
     }
     */
}
