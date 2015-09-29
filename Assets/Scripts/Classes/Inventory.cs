using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Par default les armes à deux mains sont équipées dans la main gauche
/// </summary>
[Serializable()]
public class Inventory {

    public List<List<Item>> items;
    public int gold;

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

    public void AddItem(Item it)
    {
        items[(int)it.ItemData.slotType].Add(it);
    }

    private  void unequipItem(Item it)
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

        // Maj cdAttackBase
        if (it.SlotType == Data.SlotType.ONEHAND)
        {
            if (RightHandItemID == -1 && LeftHandItemID == -1) // No weapons
                Data.heroData.cdAttackBase = 3;
            else if (RightHandItemID == -1 && LeftHandItemID != -1)
                Data.heroData.cdAttackBase = items[Data.SlotType.ONEHAND.GetHashCode()][LeftHandItemID].CdAttack;
            else if(RightHandItemID != -1 && LeftHandItemID == -1)
                Data.heroData.cdAttackBase = items[Data.SlotType.ONEHAND.GetHashCode()][RightHandItemID].CdAttack;
        }

        Data.heroData.cdAttackBonusTotal -= it.CdAttackBonus;
        Data.heroData.UpdateCdAttackModified();

        Data.heroData.legendaryEffectAvailable.Remove(it.LegendaryEffect);
       
    }

    private void equipItem(Item it)
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

        // Maj cdAttackBase
        if (it.SlotType == Data.SlotType.ONEHAND)
        {
            if (RightHandItemID == -1 && LeftHandItemID == -1) // No weapons
                Data.heroData.cdAttackBase = 3;
            else if (LeftHandItemID != -1 && (RightHandItemID == -1 || items[Data.SlotType.ONEHAND.GetHashCode()][RightHandItemID].CdAttack == 0))
                Data.heroData.cdAttackBase = items[Data.SlotType.ONEHAND.GetHashCode()][LeftHandItemID].CdAttack;
            else if (RightHandItemID != -1 && (LeftHandItemID == -1 || items[Data.SlotType.ONEHAND.GetHashCode()][LeftHandItemID].CdAttack == 0))
                Data.heroData.cdAttackBase = items[Data.SlotType.ONEHAND.GetHashCode()][RightHandItemID].CdAttack;
            else if (RightHandItemID != -1 && LeftHandItemID != -1)
                    Data.heroData.cdAttackBase = (items[Data.SlotType.ONEHAND.GetHashCode()][LeftHandItemID].CdAttack + items[Data.SlotType.ONEHAND.GetHashCode()][RightHandItemID].CdAttack) / 2;   
        }
        else if(it.SlotType == Data.SlotType.TWOHANDS)
            Data.heroData.cdAttackBase = items[Data.SlotType.TWOHANDS.GetHashCode()][LeftHandItemID].CdAttack;


        Data.heroData.cdAttackBonusTotal += it.CdAttackBonus;
        Data.heroData.UpdateCdAttackModified();

        Data.heroData.legendaryEffectAvailable.Add(it.LegendaryEffect);

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
                    unequipItem(items[(int)Data.SlotType.HEAD][HeadItemID]);
                HeadItemID = it; 
                equipItem(items[(int)Data.SlotType.HEAD][HeadItemID]);
                break;
            case Data.SlotType.CHEST:
                if (ChestItemID != -1)
                    unequipItem(items[(int)Data.SlotType.CHEST][ChestItemID]);
                ChestItemID = it;
                equipItem(items[(int)Data.SlotType.CHEST][ChestItemID]);
                break;
            case Data.SlotType.HANDS:
                if (HandsItemID != -1)
                    unequipItem(items[(int)Data.SlotType.HANDS][HandsItemID]);
                HandsItemID = it; 
                equipItem(items[(int)Data.SlotType.HANDS][HandsItemID]);
                break;
            case Data.SlotType.LEGS: 
                if(LegsItemID != -1)
                    unequipItem(items[(int)Data.SlotType.LEGS][LegsItemID]);                    
                LegsItemID = it;
                equipItem(items[(int)Data.SlotType.LEGS][LegsItemID]);
                break;
            case Data.SlotType.FEET: 
                if(FeetItemID != -1)
                    unequipItem(items[(int)Data.SlotType.FEET][FeetItemID]);
                FeetItemID = it;
                equipItem(items[(int)Data.SlotType.FEET][FeetItemID]);
                break;
            case Data.SlotType.TWOHANDS:
                if (!gotTwoHandWeapon)
                {
                    if (RightHandItemID != -1) unequipItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                    if (LeftHandItemID != -1) unequipItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                }
                else
                    if (LeftHandItemID != -1) unequipItem(items[(int)Data.SlotType.TWOHANDS][LeftHandItemID]);
                gotTwoHandWeapon = true;
                RightHandItemID = -1;
                LeftHandItemID = it;
                equipItem(items[(int)Data.SlotType.TWOHANDS][LeftHandItemID]);
                break;
            case Data.SlotType.ONEHAND:
                if (gotTwoHandWeapon)
                {
                    if (LeftHandItemID != -1) unequipItem(items[(int)Data.SlotType.TWOHANDS][LeftHandItemID]);
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
                        unequipItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                        RightHandItemID = it;
                        equipItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                        fillRightHand = false;
                    }
                    else 
                    {
                        unequipItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                        LeftHandItemID = it;
                        equipItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                        fillRightHand = true; 
                    }
                }
                gotTwoHandWeapon = false;
                break;
        }

    }

    /// <summary>
    /// Desequip l'item it de type st
    /// </summary>
    /// <param name="st">Type de l'item</param>
    /// <param name="it">indice d'item</param>
    public void Unequip(Data.SlotType st, int it)
    {
        switch (st)
        {
            case Data.SlotType.HEAD:
                if (HeadItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.HEAD][HeadItemID]);
                    HeadItemID = -1;
                }
                break;
            case Data.SlotType.CHEST:
                if (ChestItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.CHEST][ChestItemID]);
                    ChestItemID = -1;
                }
                break;
            case Data.SlotType.HANDS:
                if (HandsItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.HANDS][HandsItemID]);
                    HandsItemID = -1;
                }
                break;
            case Data.SlotType.LEGS:
                if (LegsItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.LEGS][LegsItemID]);
                    LegsItemID = -1;
                }
                break;
            case Data.SlotType.FEET:
                if (FeetItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.FEET][FeetItemID]);
                    FeetItemID = -1;
                }
                break;
            case Data.SlotType.ONEHAND:
                if (!gotTwoHandWeapon && RightHandItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.ONEHAND][RightHandItemID]);
                    RightHandItemID = -1;
                }
                else if (!gotTwoHandWeapon && LeftHandItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.ONEHAND][LeftHandItemID]);
                    LeftHandItemID = -1;
                }
                break;
            case Data.SlotType.TWOHANDS:
                if (gotTwoHandWeapon && LeftHandItemID == it)
                {
                    unequipItem(items[(int)Data.SlotType.TWOHANDS][LeftHandItemID]);
                    LeftHandItemID = -1;
                }
                break;
        }
    }

    public void LootItem (int numberOfItemLooted, int magicFind, int level)
    {
        for (int i = 0; i < numberOfItemLooted; i++)
        {
            Item it = new Item(level, magicFind);
            Data.inventory.AddItem(it);
            Data.inventory.SaveInventory();
            Debug.Log("item looted : " + it.Name + " (" + it.SlotType.ToString() + ") lvl:" + it.Level);
        }
    }

    public void LootGold(int level, Boolean isBoss, int bonus)
    {
        if(!isBoss)
            gold += (int) (Data.normalItemValueLvl1 * level * Data.standardEnemyGoldMultiplier);
        else
            gold += (int)(Data.normalItemValueLvl1 * level * Data.bossEnemyGoldMultiplier);
    }

    public int ItemValue(int level, Data.ItemQuality itemQuality)
    {
        if(itemQuality == Data.ItemQuality.NORMAL)
            return Data.normalItemValueLvl1 * level;

        if (itemQuality == Data.ItemQuality.MAGIC)
            return Data.normalItemValueLvl1 * level * Data.magicItemValueMultiplier;

        return Data.normalItemValueLvl1 * level * Data.legendaryItemValueMultiplier;
    }

    public void SaveInventory()
     {

         Stream stream = File.Create(Application.persistentDataPath + "/inventory");
         BinaryFormatter serializer = new BinaryFormatter();
         serializer.Serialize(stream, this);
         stream.Close();
         Debug.Log("inventaire sauvegardé dans " + Application.persistentDataPath + "/inventory");
     }

     public void LoadInventory()
     {
         string path = Application.persistentDataPath + "/inventory";
         if (File.Exists(path))
         {
             Stream stream = File.OpenRead(path);
             BinaryFormatter deserializer = new BinaryFormatter();
             Data.inventory = (Inventory)deserializer.Deserialize(stream);
             stream.Close();
         }
     }
     
}
