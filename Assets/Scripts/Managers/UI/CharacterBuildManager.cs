using UnityEngine;
using System.Collections;

public class CharacterBuildManager : MonoBehaviour {

    Data.SlotType SelectedSlotType;

	// Use this for initialization
	void Start () {
        SelectedSlotType = Data.SlotType.head;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goBack()
    {
        Application.LoadLevel("MainMenu");
    }
}
