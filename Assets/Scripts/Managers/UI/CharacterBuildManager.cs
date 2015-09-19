using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterBuildManager : MonoBehaviour {

    Data.SlotType selectedSlotType;
    int selectedItem;
    public List<Sprite> sprites;
    public Sprite redCrossSprite;
    //just for test
    Item it;
    //
	// Use this for initialization
	void Start () {
        selectedSlotType = Data.SlotType.HEAD;
        selectedItem = 0;

        //just for test
        for (int i = 0; i < 60; i++)
        {
            it = new Item(UnityEngine.Random.Range(1, 101), 0);
            it.SpriteID = it.SlotType.GetHashCode();
            Data.inventory.items[it.SlotType.GetHashCode()].Add(it);
        }

        //
        
        updateItemList();
        updateItemDescription();
        updateHeroEquipement();
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// Function call when the user click on the back button
    /// </summary>
    public void goBack()
    {
        Application.LoadLevel("MainMenu");
    }

    /// <summary>
    /// Function call when the user select the head item type
    /// </summary>
    public void HeadTypeSelected()
    {
        selectedSlotType = Data.SlotType.HEAD;
        SelectFirstItem();
        updateItemList();
        updateItemDescription();
    }

    /// <summary>
    /// Function call when the user select the chest item type
    /// </summary>
    public void ChestTypeSelected()
    {
        selectedSlotType = Data.SlotType.CHEST;
        SelectFirstItem();
        updateItemList();
        updateItemDescription();
    }

    /// <summary>
    /// Function call when the user select the hands item type
    /// </summary>
    public void HandsTypeSelected()
    {
        selectedSlotType = Data.SlotType.HANDS;
        SelectFirstItem();
        updateItemList();
        updateItemDescription();
    }

    /// <summary>
    /// Function call when the user select the legs item type
    /// </summary>
    public void LegsTypeSelected()
    {
        selectedSlotType = Data.SlotType.LEGS;
        SelectFirstItem();
        updateItemList();
        updateItemDescription();
    }

    /// <summary>
    /// Function call when the user select the feet item type
    /// </summary>
    public void FeetTypeSelected()
    {
        selectedSlotType = Data.SlotType.FEET;
        SelectFirstItem(); 
        updateItemList();
        updateItemDescription();
    }

    /// <summary>
    /// Function call when the user select the one hand item type
    /// </summary>
    public void OneHandTypeSelected()
    {
        selectedSlotType = Data.SlotType.ONEHAND;
        SelectFirstItem();
        updateItemList();
        updateItemDescription();
    }

    /// <summary>
    /// Function call when the user select the two hands item type
    /// </summary>
    public void TwoHandsTypeSelected()
    {
        selectedSlotType = Data.SlotType.TWOHANDS;
        SelectFirstItem();
        updateItemList();
        updateItemDescription();
    }

    /// <summary>
    /// Function that reset the selectedItem to zero when the user change the item type
    /// </summary>
    private void SelectFirstItem()
    {
        if (selectedItem != 0)
        {
            GameObject.Find("Slot (" + selectedItem + ")").GetComponent<Toggle>().isOn = false;
            GameObject.Find("Slot (0)").GetComponent<Toggle>().isOn = true;
            selectedItem = 0;
        }
        
    }

    /// <summary>
    /// Function call when the user select an item and update the SelectedItem variable
    /// </summary>
    /// <param name="i">index of the selected item</param>
    public void ChangeSelectedItem(int i)
    {
        selectedItem = i;
        updateItemDescription();
    }

    /// <summary>
    /// Function that update the item list area
    /// </summary>
    private void updateItemList()
    {
        int i;

        for (i = 0; i < Data.inventorySlotPerItemType; i++)
        {
            if (i < Data.inventory.items[selectedSlotType.GetHashCode()].Count)
            {
                GameObject.Find("Slot (" + i + ")/Icon").GetComponent<Image>().enabled = true;
                GameObject.Find("Slot (" + i + ")/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].SpriteID];

                switch (selectedSlotType)
                {
                    case Data.SlotType.HEAD :
                        if (i == Data.inventory.HeadItemID) 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = true;
                        else 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
                        break;
                    case Data.SlotType.CHEST:
                        if (i == Data.inventory.ChestItemID) 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = true;
                        else
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
                        break;
                    case Data.SlotType.HANDS:
                        if (i == Data.inventory.HandsItemID) 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = true;
                        else 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
                        break;
                    case Data.SlotType.LEGS:
                        if (i == Data.inventory.LegsItemID) 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = true;
                        else 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
                        break;
                    case Data.SlotType.FEET:
                        if (i == Data.inventory.FeetItemID)
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = true;
                        else 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
                        break;
                    case Data.SlotType.ONEHAND:
                        if (!Data.inventory.gotTwoHandWeapon && (i == Data.inventory.RightHandItemID || i == Data.inventory.LeftHandItemID))
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = true;
                        else 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
                        break;
                    case Data.SlotType.TWOHANDS:
                        if (Data.inventory.gotTwoHandWeapon && i == Data.inventory.LeftHandItemID) 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = true;
                        else 
                            GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
                        break;

                }

            }
            else
            {
                GameObject.Find("Slot (" + i + ")/Icon").GetComponent<Image>().enabled = false;
                GameObject.Find("Slot (" + i + ")/EquipedIcon").GetComponent<Image>().enabled = false;
            }
        }
    }

    /// <summary>
    /// Function that update the item description area
    /// </summary>
    private void updateItemDescription()
    {
        if (Data.inventory.items[selectedSlotType.GetHashCode()].Count > selectedItem)
        {
            GameObject.Find("ItemNameText").GetComponent<Text>().text = Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Name;
            GameObject.Find("LVLValueText").GetComponent<Text>().text = Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level.ToString();
            GameObject.Find("ATKValueText").GetComponent<Text>().text = Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue.ToString();
            GameObject.Find("ATSValueText").GetComponent<Text>().text = Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackSpeed.ToString();
            GameObject.Find("DEFValueText").GetComponent<Text>().text = Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor.ToString();
        }
        else
        {
            GameObject.Find("ItemNameText").GetComponent<Text>().text = "";
            GameObject.Find("LVLValueText").GetComponent<Text>().text = "";
            GameObject.Find("ATKValueText").GetComponent<Text>().text = "";
            GameObject.Find("ATSValueText").GetComponent<Text>().text = "";
            GameObject.Find("DEFValueText").GetComponent<Text>().text = "";
        }
    }

    private void updateHeroEquipement()
    {
        //update HEAD SLOT
        if (Data.inventory.HeadItemID != -1)
        {
            GameObject.Find("HeadSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("HeadSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.HEAD.GetHashCode()][Data.inventory.HeadItemID].SpriteID];
        }
        else
        {
            GameObject.Find("HeadSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update CHEST SLOT
        if (Data.inventory.ChestItemID != -1)
        {
            GameObject.Find("ChestSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("ChestSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.CHEST.GetHashCode()][Data.inventory.ChestItemID].SpriteID];
        }
        else
        {
            GameObject.Find("ChestSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update HANDS SLOT
        if (Data.inventory.HandsItemID != -1)
        {
            GameObject.Find("HandsSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("HandsSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.HANDS.GetHashCode()][Data.inventory.HandsItemID].SpriteID];
        }
        else
        {
            GameObject.Find("HandsSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update LEGS SLOT
        if (Data.inventory.LegsItemID != -1)
        {
            GameObject.Find("LegsSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("LegsSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.LEGS.GetHashCode()][Data.inventory.LegsItemID].SpriteID];
        }
        else
        {
            GameObject.Find("LegsSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update FEET SLOT
        if (Data.inventory.FeetItemID != -1)
        {
            GameObject.Find("FeetSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("FeetSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.FEET.GetHashCode()][Data.inventory.FeetItemID].SpriteID];
        }
        else
        {
            GameObject.Find("FeetSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update two hand weapon NOTE: TWO HAND Weapon is always in the LEFT HAND
        if (Data.inventory.gotTwoHandWeapon)
        {
            if (Data.inventory.LeftHandItemID != -1)
            {
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().enabled = true;
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().sprite = redCrossSprite;

                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().enabled = true;
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.TWOHANDS.GetHashCode()][Data.inventory.LeftHandItemID].SpriteID];
            }
            else
            {
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().enabled = false;
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().enabled = false;
            }
        }
        else
        {

            if (Data.inventory.LeftHandItemID != -1)
            {
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().enabled = true;
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.ONEHAND.GetHashCode()][Data.inventory.LeftHandItemID].SpriteID];
            }
            else
            {
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().enabled = false;
            }

            if (Data.inventory.RightHandItemID != -1)
            {
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().enabled = true;
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().sprite = sprites[Data.inventory.items[Data.SlotType.ONEHAND.GetHashCode()][Data.inventory.RightHandItemID].SpriteID];
            }
            else
            {
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().enabled = false;
            }
        }


    }

    /// <summary>
    /// Callback du bouton Equip
    /// </summary>
    public void EquipButtonPushed()
    {
        if (Data.inventory.items[selectedSlotType.GetHashCode()].Count > selectedItem)
        {
            Data.inventory.Equip(selectedSlotType, selectedItem);
            updateHeroEquipement();
            updateItemList();
        }
    }
}
