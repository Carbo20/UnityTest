using UnityEngine;
using System.Collections;

public class LevelSceneManager : MonoBehaviour {

    LevelManager lm;
    GameObject pauseMenu, pauseButton;

	// Use this for initialization
	void Start () {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        pauseMenu = GameObject.Find("Canvas/MenuPausePanel");
        pauseButton = GameObject.Find("Canvas/PauseButton");
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PauseButtonPushed()
    {
        lm.SetPause(true);
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ContinueButtonPushed()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        lm.SetPause(false);
    }

    public void QuitFarmingButtonPushed()
    {
        Application.LoadLevel("StatsScene");
    }
}
