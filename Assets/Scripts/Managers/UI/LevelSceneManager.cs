using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSceneManager : MonoBehaviour {

    LevelManager lm;
    GameObject pauseMenu, pauseButton;
    GameObject[] conditons;
    RectTransform rectTransform;
    private bool isconditionPanelExpanded;
    private bool isConditionActive;
    private int activeCondition;
    private float activeContitionTimeElapsed;
    private float activeConditionTime;
    public Sprite unactiveConditionSprite, activeConditionSprite;
	// Use this for initialization
	void Start () {
        initConditionPanel();

        isconditionPanelExpanded = false;
        isConditionActive = false;
        activeConditionTime = .5f;

        rectTransform = GameObject.Find("ConditionPanel").GetComponent<RectTransform>();
        Debug.Log("min " + rectTransform.offsetMin + " max " + rectTransform.offsetMax);
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        pauseMenu = GameObject.Find("Canvas/MenuPausePanel");
        pauseButton = GameObject.Find("Canvas/PauseButton");
        
        pauseMenu.SetActive(false);

	}

    private void initConditionPanel()
    {
        conditons = new GameObject[Data.iaData.nbOrderMax];
        for (int i = 0; i < Data.iaData.nbOrderMax; i++)
        {
            conditons[i] = GameObject.Find("Condition" + i);
            Debug.Log(conditons[i]);
        }

        //hide locked conditions
        for (int i = Data.iaData.nbOrder; i < Data.iaData.nbOrderMax; i++)
        {
            conditons[i].SetActive(false);
        }

        //init conditions text
        for (int i = 0; i < Data.iaData.nbOrder; i++)
        {
            string txt = "";
            //ia condition
            switch (Data.iaData.idCondition[i])
            {
                case IaData.IaCondition.HEALTH:
                    txt += "MY HP ";
                    break;
                case IaData.IaCondition.MANA:
                    txt += "MY MANA ";
                    break;
                case IaData.IaCondition.ENEMYHEALTH:
                    txt += "ENEMY HEALTH ";
                    break;
                case IaData.IaCondition.ENEMYMANA:
                    txt += "ENEMY MANA ";
                    break;
                case IaData.IaCondition.ENEMYCAST:
                    txt += " ENEMY CAST ";
                    break;
                case IaData.IaCondition.ENEMYNB:
                    txt += "ENEMY NB ";
                    break;
                case IaData.IaCondition.ENEMYCLASS:
                    txt += "ENEMY CLASS ";
                    break;
            }

            //ia signe
            if (Data.iaData.idSigne[i] == 0) txt += "> ";
            else if (Data.iaData.idSigne[i] == 1) txt += "< ";

            if (Data.iaData.idCondition[i] != IaData.IaCondition.ENEMYCAST && Data.iaData.idCondition[i] != IaData.IaCondition.ENEMYCLASS)
                txt += Data.iaData.value[i] + " ";

            txt += "=> Use  " + Data.iaData.idSkill[i].ToString();

            conditons[i].GetComponentsInChildren<Text>()[0].text = txt;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isConditionActive)
        {
            if (activeContitionTimeElapsed < activeConditionTime)
            {
                activeContitionTimeElapsed += Time.deltaTime;
            }
            else
            {
                conditons[activeCondition].GetComponentsInChildren<Image>()[0].sprite = unactiveConditionSprite;
                isConditionActive = false;
            }
        }
	}

    public void triggerCondition(int i)
    {
        activeCondition = i;
        conditons[activeCondition].GetComponentsInChildren<Image>()[0].sprite = activeConditionSprite;
        isConditionActive = true;
        activeContitionTimeElapsed = 0;
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

    public void expandConditionPanel()
    {
        if (isconditionPanelExpanded)
        {
            rectTransform.offsetMax = new Vector2(321.5f, -83.6f);
            rectTransform.offsetMin = new Vector2(802.5f, 69.5f);
            isconditionPanelExpanded = false;
        }
        else
        {
            rectTransform.offsetMax = new Vector2(0.5f, -83.6f);
            rectTransform.offsetMin = new Vector2(480.5f, 69.5f);
            isconditionPanelExpanded = true ;
        }
    }

    public void QuitFarmingButtonPushed()
    {
        Application.LoadLevel("StatsScene");
    }
}
