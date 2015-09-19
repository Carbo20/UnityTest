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

    /// <summary>
    /// Equip d'item it de type st
    /// </summary>
    /// <param name="st">Type de l'item</param>
    /// <param name="it">index de l'item</param>
    public void Equip(Data.SlotType st, int it)
    {
        switch (st)
        {

            case Data.SlotType.HEAD: HeadItemID = it; break;
            case Data.SlotType.CHEST: ChestItemID = it; break;
            case Data.SlotType.HANDS: HandsItemID = it; break;
            case Data.SlotType.LEGS: LegsItemID = it; break;
            case Data.SlotType.FEET: FeetItemID = it; break;
            case Data.SlotType.TWOHANDS:
                gotTwoHandWeapon = true;
                RightHandItemID = -1;
                LeftHandItemID = it;
                break;
            case Data.SlotType.ONEHAND:
                if (gotTwoHandWeapon)
                {
                    LeftHandItemID = -1;
                    RightHandItemID = it;
                }
                else
                {
                    if (RightHandItemID == it || LeftHandItemID == it) break;
                    if (RightHandItemID == -1) RightHandItemID = it;
                    else if (LeftHandItemID == -1) LeftHandItemID = it;
                    else if (fillRightHand) { RightHandItemID = it; fillRightHand = false; }
                    else { LeftHandItemID = it; fillRightHand = true; }
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
