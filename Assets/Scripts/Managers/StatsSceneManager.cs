using UnityEngine;
using System.Collections;

public class StatsSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public void CallbackButtonContinue()
    {
        //Switch the current scene to the menu
        Application.LoadLevel("loadingScene");
    }


    void SaveStats()
    {

    }
	// Update is called once per frame
	void Update () {
	
	}


}
