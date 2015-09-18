using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CharacterBuildManager : MonoBehaviour {

    Data.SlotType selectedSlotType;
    int selectedItem;
    
	// Use this for initialization
	void Start () {
        selectedSlotType = Data.SlotType.HEAD;
        selectedItem = 0;
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
    }

    /// <summary>
    /// Function call when the user select the chest item type
    /// </summary>
    public void ChestTypeSelected()
    {
        selectedSlotType = Data.SlotType.CHEST;
        SelectFirstItem();
    }

    /// <summary>
    /// Function call when the user select the hands item type
    /// </summary>
    public void HandsTypeSelected()
    {
        selectedSlotType = Data.SlotType.HANDS;
        SelectFirstItem();
    }

    /// <summary>
    /// Function call when the user select the legs item type
    /// </summary>
    public void LegsTypeSelected()
    {
        selectedSlotType = Data.SlotType.LEGS;
        SelectFirstItem();
    }

    /// <summary>
    /// Function call when the user select the feet item type
    /// </summary>
    public void FeetTypeSelected()
    {
        selectedSlotType = Data.SlotType.FEET;
        SelectFirstItem();
    }

    /// <summary>
    /// Function call when the user select the one hand item type
    /// </summary>
    public void OneHandTypeSelected()
    {
        selectedSlotType = Data.SlotType.ONEHAND;
        SelectFirstItem();
    }

    /// <summary>
    /// Function call when the user select the two hands item type
    /// </summary>
    public void TwoHandsTypeSelected()
    {
        selectedSlotType = Data.SlotType.TWOHANDS;
        SelectFirstItem();
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
    }

    private void updateItemList()
    {
        int i;

        for (i = 0; i < Data.inventorySlotPerItemType; i++)
        {
            switch (selectedSlotType)
            {
                case Data.SlotType.HEAD: 
                    break;
                case Data.SlotType.CHEST: 
                    break;
                case Data.SlotType.HANDS: 
                    break;
                case Data.SlotType.LEGS: 
                    break;
                case Data.SlotType.FEET: 
                    break;
                case Data.SlotType.ONEHAND: 
                    break;
                case Data.SlotType.TWOHANDS: 
                    break;

            }
        }
    }
}
