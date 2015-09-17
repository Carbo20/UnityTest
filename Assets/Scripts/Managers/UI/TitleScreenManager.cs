using UnityEngine;
using System.Collections;

public class TitleScreenManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("kikoo");
        if (Input.touchCount > 0)
        {
            Debug.Log("lool");
            Application.LoadLevel("MainMenu");
        }
	}
}
