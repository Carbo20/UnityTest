using System.Collections.Generic;

public class Inventory {

    public List<List<Item>> items;
    public Item HeadItem;
    public Item ChestItem;
    public Item HandsItem;
    public Item LegsItem;
    public Item FeetItem;
    public Item RightHandItem;
    public Item LeftHandItem;
    public bool gotTwoHandWeapon;
    public bool fillRightHand;

    public Inventory()
    {
        items = new List<List<Item>>();
        for (int i = 0; i < Data.SlotTypeCount; i++)
            items.Add(new List<Item>());

        gotTwoHandWeapon = false;
        fillRightHand = true;
    }

    public void Equip(Item it)
    {
        switch (it.SlotType)
        {

            case Data.SlotType.HEAD: HeadItem = it; break;
            case Data.SlotType.CHEST: ChestItem = it; break;
            case Data.SlotType.HANDS: HandsItem = it; break;
            case Data.SlotType.LEGS: LegsItem = it; break;
            case Data.SlotType.FEET: FeetItem = it; break;
            case Data.SlotType.TWOHANDS :
                gotTwoHandWeapon = true;
                RightHandItem = null;
                LeftHandItem = it;
                break;
            case Data.SlotType.ONEHAND :
                if (gotTwoHandWeapon)
                {
                    LeftHandItem = null;
                    RightHandItem = it;
                }
                else
                {
                    if (RightHandItem == null) RightHandItem = it;
                    else if (LeftHandItem == null) LeftHandItem = it;
                    else if (fillRightHand) { RightHandItem = it; fillRightHand = false; }
                    else { LeftHandItem = it; fillRightHand = true; }
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
