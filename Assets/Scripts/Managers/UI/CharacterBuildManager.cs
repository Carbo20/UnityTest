using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterBuildManager : MonoBehaviour {

    Data.SlotType selectedSlotType;
    int selectedItem;
    public List<Sprite> sprites;
    //just for test
    Item it;

	// Use this for initialization
	void Start () {
        selectedSlotType = Data.SlotType.HEAD;
        selectedItem = 0;

        for (int i = 0; i < 20; i++)
        {
            it = new Item(UnityEngine.Random.Range(0, 101), 0);
            it.SpriteID = it.SlotType.GetHashCode();
            Data.inventory.items[it.SlotType.GetHashCode()].Add(it);
        }



        updateItemList();
        updateItemDescription();
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
    }

    /// <summary>
    /// Function call when the user select the chest item type
    /// </summary>
    public void ChestTypeSelected()
    {
        selectedSlotType = Data.SlotType.CHEST;
        SelectFirstItem();
        updateItemList();
    }

    /// <summary>
    /// Function call when the user select the hands item type
    /// </summary>
    public void HandsTypeSelected()
    {
        selectedSlotType = Data.SlotType.HANDS;
        SelectFirstItem();
        updateItemList();
    }

    /// <summary>
    /// Function call when the user select the legs item type
    /// </summary>
    public void LegsTypeSelected()
    {
        selectedSlotType = Data.SlotType.LEGS;
        SelectFirstItem();
        updateItemList();
    }

    /// <summary>
    /// Function call when the user select the feet item type
    /// </summary>
    public void FeetTypeSelected()
    {
        selectedSlotType = Data.SlotType.FEET;
        SelectFirstItem(); 
        updateItemList();
    }

    /// <summary>
    /// Function call when the user select the one hand item type
    /// </summary>
    public void OneHandTypeSelected()
    {
        selectedSlotType = Data.SlotType.ONEHAND;
        SelectFirstItem();
        updateItemList();
    }

    /// <summary>
    /// Function call when the user select the two hands item type
    /// </summary>
    public void TwoHandsTypeSelected()
    {
        selectedSlotType = Data.SlotType.TWOHANDS;
        SelectFirstItem();
        updateItemList();
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
            }
            else
            {
                GameObject.Find("Slot (" + i + ")/Icon").GetComponent<Image>().enabled = false;
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
}
