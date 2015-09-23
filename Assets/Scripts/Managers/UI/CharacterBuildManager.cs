using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterBuildManager : MonoBehaviour {

    Data.SlotType selectedSlotType;
    int selectedItem;
    //public List<Sprite> sprites;
    public Sprite redCrossSprite;
    RectTransform contentRectTransform;
    Text LVLTxt, ATKTxt, ATStxt, DEFTxt;
    Color lowerSTATColor, upperSTATColor, equalSTATColor;
    private GameObject heroStat, heroEquip;
    private Text LVLStat, XPStat, HPStat, MANAStat, STRStat, INTStat, AGIStat, VITStat, DMGStat, SPDMGStat, DODStat, CRITStat, SPEStat, ARMORStat;
    bool heroStatTextLoad;
    bool heroStatsDraws;
    //just for test
    Item it;
    
    //

	// Use this for initialization
	void Start () {
        heroStatTextLoad = false;
        selectedSlotType = Data.SlotType.HEAD;
        selectedItem = 0;
        contentRectTransform = GameObject.Find("Content").GetComponent<RectTransform>();
        initTextGameObject();
        heroStat = GameObject.Find("Canvas/Canvas/HeroStats");
        
        heroEquip = GameObject.Find("Hero");
        lowerSTATColor = Color.red;
        upperSTATColor = Color.green;
        equalSTATColor = Color.black;
        heroStatsDraws = false;
        //just for test
        for (int i = 0; i < 100; i++)
        {
            it = new Item(UnityEngine.Random.Range(1, 101), 0);
            Data.inventory.items[it.SlotType.GetHashCode()].Add(it);
        }

        //


        updateItemList();
        updateItemDescription();
        updateHeroEquipement();
        updateHeroStats();
	}

    void initTextGameObject()
    {
        LVLTxt = GameObject.Find("LVLValueText").GetComponent<Text>();
        ATKTxt = GameObject.Find("ATKValueText").GetComponent<Text>();
        ATStxt = GameObject.Find("ATSValueText").GetComponent<Text>();
        DEFTxt = GameObject.Find("DEFValueText").GetComponent<Text>();

        if (!heroStatTextLoad && heroStatsDraws)
        {
            LVLStat = GameObject.Find("LevelValue").GetComponent<Text>();
            XPStat = GameObject.Find("XPValue").GetComponent<Text>();
            HPStat = GameObject.Find("HPValue").GetComponent<Text>();
            MANAStat = GameObject.Find("MANAValue").GetComponent<Text>();
            STRStat = GameObject.Find("STRENGHTValue").GetComponent<Text>();
            INTStat = GameObject.Find("INTELValue").GetComponent<Text>();
            AGIStat = GameObject.Find("AGILITYValue").GetComponent<Text>();
            VITStat = GameObject.Find("VITALITYValue").GetComponent<Text>();
            DMGStat = GameObject.Find("DAMAGEValue").GetComponent<Text>();
            SPDMGStat = GameObject.Find("SPELLDMGValue").GetComponent<Text>();
            DODStat = GameObject.Find("DODGEValue").GetComponent<Text>();
            CRITStat = GameObject.Find("CRITValue").GetComponent<Text>();
            SPEStat = GameObject.Find("SPEEDValue").GetComponent<Text>();
            ARMORStat = GameObject.Find("ARMORValue").GetComponent<Text>();

            heroStatTextLoad = true;
        }
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
    /// Callback that change the type of the items draw in the scroll view
    /// </summary>
    /// <param name="i">SlotType ID</param>
    public void ChangeSelectedType(int i)
    {
        selectedSlotType = (Data.SlotType) i;
        SelectFirstItem();
        updateItemList();
        updateItemDescription();
        contentRectTransform.offsetMax = new Vector2(contentRectTransform.offsetMax.x, 0);
        contentRectTransform.offsetMin = new Vector2(contentRectTransform.offsetMin.x, -271);
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
                GameObject.Find("Slot (" + i + ")/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[selectedSlotType.GetHashCode()][i].SpriteID];

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


            switch (selectedSlotType)
            {
                case Data.SlotType.HEAD:

                    if (Data.inventory.HeadItemID == -1)
                    {
                        LVLTxt.color = upperSTATColor;
                        ATKTxt.color = upperSTATColor;
                        ATStxt.color = upperSTATColor;
                        DEFTxt.color = upperSTATColor;
                        break;
                    }

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].Level)
                        LVLTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].Level)
                        LVLTxt.color = lowerSTATColor;
                    else
                        LVLTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].AttackValue)
                        ATKTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].AttackValue)
                        ATKTxt.color = lowerSTATColor;
                    else
                        ATKTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].CdAttack)
                        ATStxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].CdAttack)
                        ATStxt.color = lowerSTATColor;
                    else
                        ATStxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].Armor)
                        DEFTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HeadItemID].Armor)
                        DEFTxt.color = lowerSTATColor;
                    else
                        DEFTxt.color = equalSTATColor;
                    break;

                case Data.SlotType.CHEST:

                    if (Data.inventory.ChestItemID == -1)
                    {
                        LVLTxt.color = upperSTATColor;
                        ATKTxt.color = upperSTATColor;
                        ATStxt.color = upperSTATColor;
                        DEFTxt.color = upperSTATColor;
                        break;
                    }

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].Level)
                        LVLTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].Level)
                        LVLTxt.color = lowerSTATColor;
                    else
                        LVLTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].AttackValue)
                        ATKTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].AttackValue)
                        ATKTxt.color = lowerSTATColor;
                    else
                        ATKTxt.color = equalSTATColor;
                    
                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].CdAttack)
                        ATStxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].CdAttack)
                        ATStxt.color = lowerSTATColor;
                    else
                        ATStxt.color = equalSTATColor;
                                        
                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].Armor)
                        DEFTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.ChestItemID].Armor)
                        DEFTxt.color = lowerSTATColor;
                    else
                        DEFTxt.color = equalSTATColor;
                    break;

                case Data.SlotType.HANDS:

                    if (Data.inventory.HandsItemID == -1)
                    {
                        LVLTxt.color = upperSTATColor;
                        ATKTxt.color = upperSTATColor;
                        ATStxt.color = upperSTATColor;
                        DEFTxt.color = upperSTATColor;
                        break;
                    }

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].Level)
                        LVLTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].Level)
                        LVLTxt.color = lowerSTATColor;
                    else
                        LVLTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].AttackValue)
                        ATKTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].AttackValue)
                        ATKTxt.color = lowerSTATColor;
                    else
                        ATKTxt.color = equalSTATColor;
                    
                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].CdAttack)
                        ATStxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].CdAttack)
                        ATStxt.color = lowerSTATColor;
                    else
                        ATStxt.color = equalSTATColor;
                    
                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].Armor)
                        DEFTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.HandsItemID].Armor)
                        DEFTxt.color = lowerSTATColor;
                    else
                        DEFTxt.color = equalSTATColor;
                    break;

                case Data.SlotType.LEGS:

                    if (Data.inventory.LegsItemID == -1)
                    {
                        LVLTxt.color = upperSTATColor;
                        ATKTxt.color = upperSTATColor;
                        ATStxt.color = upperSTATColor;
                        DEFTxt.color = upperSTATColor;
                        break;
                    }

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].Level)
                        LVLTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].Level)
                        LVLTxt.color = lowerSTATColor;
                    else
                        LVLTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].AttackValue)
                        ATKTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].AttackValue)
                        ATKTxt.color = lowerSTATColor;
                    else
                        ATKTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].CdAttack)
                        ATStxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].CdAttack)
                        ATStxt.color = lowerSTATColor;
                    else
                        ATStxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].Armor)
                        DEFTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LegsItemID].Armor)
                        DEFTxt.color = lowerSTATColor;
                    else
                        DEFTxt.color = equalSTATColor;
                    break;

                case Data.SlotType.FEET:

                    if (Data.inventory.FeetItemID == -1)
                    {
                        LVLTxt.color = upperSTATColor;
                        ATKTxt.color = upperSTATColor;
                        ATStxt.color = upperSTATColor;
                        DEFTxt.color = upperSTATColor;
                        break;
                    }

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].Level)
                        LVLTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].Level)
                        LVLTxt.color = lowerSTATColor;
                    else
                        LVLTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].AttackValue)
                        ATKTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].AttackValue)
                        ATKTxt.color = lowerSTATColor;
                    else
                        ATKTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].CdAttack)
                        ATStxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].CdAttack)
                        ATStxt.color = lowerSTATColor;
                    else
                        ATStxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].Armor)
                        DEFTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.FeetItemID].Armor)
                        DEFTxt.color = lowerSTATColor;
                    else
                        DEFTxt.color = equalSTATColor;
                    break;

                case Data.SlotType.ONEHAND:
                case Data.SlotType.TWOHANDS:

                    if (Data.inventory.LeftHandItemID == -1)
                    {
                        LVLTxt.color = upperSTATColor;
                        ATKTxt.color = upperSTATColor;
                        ATStxt.color = upperSTATColor;
                        DEFTxt.color = upperSTATColor;
                        break;
                    }

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].Level)
                        LVLTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Level < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].Level)
                        LVLTxt.color = lowerSTATColor;
                    else
                        LVLTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].AttackValue)
                        ATKTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].AttackValue)
                        ATKTxt.color = lowerSTATColor;
                    else
                        ATKTxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].CdAttack)
                        ATStxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].CdAttack)
                        ATStxt.color = lowerSTATColor;
                    else
                        ATStxt.color = equalSTATColor;

                    if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor > Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].Armor)
                        DEFTxt.color = upperSTATColor;
                    else if (Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].Armor < Data.inventory.items[selectedSlotType.GetHashCode()][Data.inventory.LeftHandItemID].Armor)
                        DEFTxt.color = lowerSTATColor;
                    else
                        DEFTxt.color = equalSTATColor;

                    break;
            }
            GameObject.Find("ATKValueText").GetComponent<Text>().text = Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].AttackValue.ToString();
            GameObject.Find("ATSValueText").GetComponent<Text>().text = Data.inventory.items[selectedSlotType.GetHashCode()][selectedItem].CdAttack.ToString();
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

    /// <summary>
    /// Function that update the hero equipement area
    /// </summary>
    private void updateHeroEquipement()
    {
        if (heroStatsDraws) return;
        //update HEAD SLOT
        if (Data.inventory.HeadItemID != -1)
        {
            GameObject.Find("HeadSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("HeadSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.HEAD.GetHashCode()][Data.inventory.HeadItemID].SpriteID];
        }
        else
        {
            GameObject.Find("HeadSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update CHEST SLOT
        if (Data.inventory.ChestItemID != -1)
        {
            GameObject.Find("ChestSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("ChestSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.CHEST.GetHashCode()][Data.inventory.ChestItemID].SpriteID];
        }
        else
        {
            GameObject.Find("ChestSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update HANDS SLOT
        if (Data.inventory.HandsItemID != -1)
        {
            GameObject.Find("HandsSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("HandsSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.HANDS.GetHashCode()][Data.inventory.HandsItemID].SpriteID];
        }
        else
        {
            GameObject.Find("HandsSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update LEGS SLOT
        if (Data.inventory.LegsItemID != -1)
        {
            GameObject.Find("LegsSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("LegsSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.LEGS.GetHashCode()][Data.inventory.LegsItemID].SpriteID];
        }
        else
        {
            GameObject.Find("LegsSlot/Icon").GetComponent<Image>().enabled = false;
        }

        //update FEET SLOT
        if (Data.inventory.FeetItemID != -1)
        {
            GameObject.Find("FeetSlot/Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("FeetSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.FEET.GetHashCode()][Data.inventory.FeetItemID].SpriteID];
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
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.TWOHANDS.GetHashCode()][Data.inventory.LeftHandItemID].SpriteID];
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
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.ONEHAND.GetHashCode()][Data.inventory.LeftHandItemID].SpriteID];
            }
            else
            {
                GameObject.Find("LeftHandSlot/Icon").GetComponent<Image>().enabled = false;
            }

            if (Data.inventory.RightHandItemID != -1)
            {
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().enabled = true;
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().sprite = Data.sprites[Data.inventory.items[Data.SlotType.ONEHAND.GetHashCode()][Data.inventory.RightHandItemID].SpriteID];
            }
            else
            {
                GameObject.Find("RightHandSlot/Icon").GetComponent<Image>().enabled = false;
            }
        }


    }

    /// <summary>
    /// Function that update the hero stats area
    /// </summary>
    private void updateHeroStats()
    {
        if (!heroStatsDraws) return;
        
        if(!heroStatTextLoad)   
            initTextGameObject();

        LVLStat.text = Data.heroData.level.ToString();
        XPStat.text = Data.heroData.xp + " / " + Data.heroData.xpForNextLevel;
        HPStat.text = Data.heroData.hpMax.ToString();
        MANAStat.text = Data.heroData.manaMax.ToString();
        STRStat.text = Data.heroData.strenght.ToString();
        INTStat.text = Data.heroData.intelligence.ToString();
        AGIStat.text = Data.heroData.agility.ToString();
        VITStat.text = Data.heroData.vitality.ToString();
        DMGStat.text = Data.heroData.damage.ToString();
        SPDMGStat.text = Data.heroData.spellDamage.ToString();
        DODStat.text = Data.heroData.dodge.ToString();
        CRITStat.text = Data.heroData.critical.ToString();
        SPEStat.text = Data.heroData.cdAttackBase.ToString();
        ARMORStat.text = Data.heroData.armor.ToString();

    }

    /// <summary>
    /// Callback called when the user touche the left part of the screen for draws the stats of the hero or show his equipement
    /// </summary>
    public void changeLeftPartOfTheScreen()
    {
        if (heroStatsDraws)
        {
            heroStat.SetActive(false);
            heroEquip.SetActive(true);
            heroStatsDraws = false;
        }
        else
        {
            heroStat.SetActive(true);
            heroEquip.SetActive(false);
            heroStatsDraws = true;
        }
        updateHeroEquipement();
        updateHeroStats();
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
            updateItemDescription();
            updateHeroStats();
        }
    }
}
