﻿using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToCharacterBuilderScreen()
    {
        Application.LoadLevel("CharacterBuildScene");
    }

    public void goToIAScene()
    {
        Application.LoadLevel("IAProgScene");
    }
}
