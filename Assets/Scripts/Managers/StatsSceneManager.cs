using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsSceneManager : MonoBehaviour {

    private GameObject text;
    private TextMesh statsValuesText;
    private int xpValue;

    // Use this for initialization
    void Start () {


        Text xp = GameObject.Find("Experience").GetComponent<Text>();
        xp.text = FarmingStats.xp.ToString() + "xp";

        Text killed = GameObject.Find("Killed").GetComponent<Text>();
        killed.text = FarmingStats.eKill.ToString();

        Text dInflicted = GameObject.Find("DInflicted").GetComponent<Text>();
        dInflicted.text = FarmingStats.dInflicted.ToString();

        Text dEndured = GameObject.Find("DEndured").GetComponent<Text>();
        dEndured.text = FarmingStats.dEndured.ToString();

        Text skill = GameObject.Find("Skill").GetComponent<Text>();
        skill.text = FarmingStats.skillUsed.ToString();

        Text item = GameObject.Find("Item").GetComponent<Text>();
        item.text = FarmingStats.itemUsed.ToString();

        Text level = GameObject.Find("Level").GetComponent<Text>();
        level.text = FarmingStats.level.ToString();

        Text time = GameObject.Find("Time").GetComponent<Text>();
        TimeConvertion(time, FarmingStats.time);


    }
	
    private void TimeConvertion(Text timeText, float time)
    {
        int sec = (int)time % 60;
        int min = (int)time / 60 % 60;
        int hour = (int)time / 3600;

        timeText.text = hour + "h : " + min + "min : " + sec + "sec";
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
