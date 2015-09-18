using UnityEngine;
using System.Collections;

public class CharacterBuildManager : MonoBehaviour {

    Data.SlotType SelectedSlotType;

	// Use this for initialization
	void Start () {
        SelectedSlotType = Data.SlotType.HEAD;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("type: " + SelectedSlotType);
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
