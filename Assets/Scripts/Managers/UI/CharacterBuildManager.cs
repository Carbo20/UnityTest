using UnityEngine;
using System.Collections;
using System;

public class CharacterBuildManager : MonoBehaviour {

    Data.SlotType SelectedSlotType;
    int SelectedItem;

	// Use this for initialization
	void Start () {
        SelectedSlotType = Data.SlotType.HEAD;
        SelectedItem = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void goBack()
    {
        Application.LoadLevel("MainMenu");
    }

    public void HeadTypeSelected()
    {
        SelectedSlotType = Data.SlotType.HEAD;
    }

    public void ChestTypeSelected()
    {
        SelectedSlotType = Data.SlotType.CHEST;
    }

    public void HandsTypeSelected()
    {
        SelectedSlotType = Data.SlotType.HANDS;
    }

    public void LegsTypeSelected()
    {
        SelectedSlotType = Data.SlotType.LEGS;
    }

    public void FeetTypeSelected()
    {
        SelectedSlotType = Data.SlotType.FEET;
    }

    public void OneHandTypeSelected()
    {
        SelectedSlotType = Data.SlotType.ONEHAND;
    }

    public void TwoHandsTypeSelected()
    {
        SelectedSlotType = Data.SlotType.TWOHANDS;
    }
}
