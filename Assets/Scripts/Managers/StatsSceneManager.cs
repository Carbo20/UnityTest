using UnityEngine;
using System.Collections;

public class StatsSceneManager : MonoBehaviour {

    private GameObject text;
    private TextMesh statsValuesText;
    private int xpValue;

    // Use this for initialization
    void Start () {
        GameObject textBox = Instantiate(Resources.Load("Prefabs/Text")) as GameObject;
        statsValuesText = textBox.GetComponent<TextMesh>();
        xpValue = 15;
    }
	
    public void CallbackButtonContinue()
    {
        //Switch the current scene to the menu
        Application.LoadLevel("loadingScene");
    }


    void SaveStats()
    {
        //TODO print Text with stats numbers
        statsValuesText.text =  xpValue.ToString();
    }
	// Update is called once per frame
	void Update () {
	
	}


}
