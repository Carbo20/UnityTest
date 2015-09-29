using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IASceneManager : MonoBehaviour
{

    private int nbButtonUnlocked = Data.iaData.nbOrder;

    private Dropdown[] categoryDropdown = new Dropdown[8];
    //private GameObject panelLocker;

    private int indexButtonMax;
    private int line;
    
    private GameObject[] gObjHealthBis = new GameObject[8];
    private GameObject[] gObjManaBis = new GameObject[8];
    private GameObject[] gObjHealthBisEn = new GameObject[8];
    private GameObject[] gObjManaBisEn = new GameObject[8];

    private GameObject[] gObjCast = new GameObject[8];
    private GameObject[] gObjEnemiesNb = new GameObject[8];
    private GameObject[] gObjEnemyClass = new GameObject[8];

    private GameObject[] gObjPourcentValue = new GameObject[8];
    private GameObject[] gObjSign = new GameObject[8];

    public Text textDrop;

    private float switchCatCount;
    private IaData.IaCondition conditionNb;
    private GameObject gObjEnemiesNbBis;
    private RectTransform rectTransform;
    private float top;
    private int additionalButtons;
    private GameObject textAlert;
    private int nbConditionChosen;

    // Use this for initialization
    void Start()
    {
        nbConditionChosen = 0;
        indexButtonMax = 8;
        switchCatCount = 0;

        textAlert = GameObject.Find("TextAlert");

        for (int ind=0; ind< indexButtonMax; ind++)
        { 
            gObjHealthBis[ind] = GameObject.Find("CondHealthBis" + ind);
            gObjManaBis[ind] = GameObject.Find("CondManaBis" + ind);
            
            gObjHealthBisEn[ind] = GameObject.Find("CondHealthBisEn" + ind);
            gObjManaBisEn[ind] = GameObject.Find("CondManaBisEn" + ind);

            gObjCast[ind] = GameObject.Find("CondCast" + ind);
            gObjEnemiesNb[ind] = GameObject.Find("CondEnemiesNb" + ind);
            gObjEnemyClass[ind] = GameObject.Find("CondEnemyClass" + ind);

            gObjPourcentValue[ind] = GameObject.Find("PourcentValue" + ind);
            gObjSign[ind] = GameObject.Find("Sign" + ind);
        }
       
        initAll();

        //panelLocker = GameObject.Find("PanelLocker");

        //textDrop = gameObject.GetComponent<Text>();
        //textDrop.text = "Unlock at lvl 10";
        if (nbButtonUnlocked > 3)
        {//ResizePanelLocker(nbButtonUnlocked);
            for (int i = nbButtonUnlocked+1; i < indexButtonMax + 1; i++)
            {
                //GameObject.Find("categoryDropdown(" + i + ")").GetComponent<Dropdown>().itemText = textDrop;
                //GameObject.Find("categoryDropdown(" + i + ")").GetComponent<Dropdown>().options[0].text = "Unlock at lvl 10";
                GameObject.Find("categoryDropdown(" + i + ")").GetComponent<Dropdown>().interactable = false;
            }
        }
        else
        {
            for (int i = 4; i < indexButtonMax + 1; i++)
            {
                //GameObject.Find("categoryDropdown(" + i + ")").GetComponent<Dropdown>().options[0].text = "Unlock at lvl 10";
                GameObject.Find("categoryDropdown(" + i + ")").GetComponent<Dropdown>().interactable = false;
            }
        }
    }


    void initAll()
    {
        textAlert.SetActive(false);


        for (int ind = 0; ind < nbButtonUnlocked; ind++)
        {

            if (Data.iaData.idCondition[ind] != IaData.IaCondition.NULL)
            {
                nbConditionChosen++;
            }
        }

        for (int ind= nbButtonUnlocked; ind<indexButtonMax ;ind++)
        {
            gObjHealthBis[ind].SetActive(false);
            gObjManaBis[ind].SetActive(false);
            gObjHealthBisEn[ind].SetActive(false);
            gObjManaBisEn[ind].SetActive(false);

            gObjCast[ind].SetActive(false);
            gObjEnemiesNb[ind].SetActive(false);
            gObjEnemyClass[ind].SetActive(false);

            gObjPourcentValue[ind].SetActive(false);
            gObjSign[ind].SetActive(false);

            

        }
        if (nbConditionChosen == 0)
        { 
            for (int ind = 0; ind < nbButtonUnlocked; ind++)
            {
                gObjHealthBis[ind].SetActive(false);
                gObjManaBis[ind].SetActive(false);
                gObjHealthBisEn[ind].SetActive(false);
                gObjManaBisEn[ind].SetActive(false);

                gObjCast[ind].SetActive(false);
                gObjEnemiesNb[ind].SetActive(false);
                gObjEnemyClass[ind].SetActive(false);

                gObjPourcentValue[ind].SetActive(false);
                gObjSign[ind].SetActive(false);
                
            }
        }
    }

    void initLine(int ind)
    {
        gObjHealthBis[ind].SetActive(false);
        gObjManaBis[ind].SetActive(false);
        gObjHealthBisEn[ind].SetActive(false);
        gObjManaBisEn[ind].SetActive(false);

        gObjCast[ind].SetActive(false);
        gObjEnemiesNb[ind].SetActive(false);
        gObjEnemyClass[ind].SetActive(false);

        gObjPourcentValue[ind].SetActive(false);
        gObjSign[ind].SetActive(false);
    }
    /*
    public void ResizePanelLocker(int _indexButtonUnlocked)
    {//-130 => 4 buttons availables   -160 => 5 buttons
        additionalButtons = _indexButtonUnlocked - 3;//substract the 3 buttons unlocked by default to have the nb of additional buttons
        top = -100 + (additionalButtons * -30);// Offset of 30 for each button unlocked
        rectTransform = panelLocker.GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, top);

    }
    */
    public void CallbackApplyAndFarm()
    {
        
        for (int line = 0; line < nbButtonUnlocked; line++)
        {
            int indName = line + 1;
            categoryDropdown[line] = GameObject.Find("categoryDropdown(" + indName + ")").GetComponent<Dropdown>();
            //Player's Health
            if (categoryDropdown[line].value == 1)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.HEALTH;

                //Stock value of %
                Data.iaData.value[line] = (gObjPourcentValue[line].GetComponent<Dropdown>().value)*10;

                
                //Test which sign has been chosen
                if (gObjSign[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
                //Stock which spell has been chosen
                Debug.Log("PAR ICI : " + Data.heroData.skillAvailable[0]);
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[gObjHealthBis[line].GetComponent<Dropdown>().value];

            }

            //Player's Mana
            if (categoryDropdown[line].value == 2)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.MANA;

                //Stock value of %
                Data.iaData.value[line] = gObjPourcentValue[line].GetComponent<Dropdown>().value*10;

                //Test which sign has been chosen
                if (gObjSign[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
                //Stock which spell has been chosen
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[gObjManaBis[line].GetComponent<Dropdown>().value];
            }

            if (categoryDropdown[line].value == 3)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYHEALTH;

                //Stock value of %
                Data.iaData.value[line] = gObjPourcentValue[line].GetComponent<Dropdown>().value*10;

                //Test which sign has been chosen
                if (gObjSign[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }

                //Stock which spell has been chosen
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[gObjHealthBisEn[line].GetComponent<Dropdown>().value];
            }


            if (categoryDropdown[line].value == 4)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYMANA;

                //Stock value of %
                Data.iaData.value[line] = gObjPourcentValue[line].GetComponent<Dropdown>().value*10;

                //Test which sign has been chosen
                if (gObjSign[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }

                //Stock which spell has been chosen
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[gObjManaBisEn[line].GetComponent<Dropdown>().value];
            }

            if (categoryDropdown[line].value == 5)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYCAST;

                //Set value table to -1 (null) for the only category who don't have this kind of value 
                Data.iaData.value[line] = -1;

                //Stock which spell has been chosen
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[GameObject.Find("CondCast" + line + "/Dropdown").GetComponent<Dropdown>().value];

            }

            if (categoryDropdown[line].value == 6)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYNB;

                //Stock the enemy nb chosen
                Data.iaData.value[line] = GameObject.Find("CondEnemiesNb" + line + "/enemyNb").GetComponent<Dropdown>().value;
                //Stock which spell the player will use
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[GameObject.Find("CondEnemiesNb" + line + "/playerSpells").GetComponent<Dropdown>().value];

            }

            if (categoryDropdown[line].value == 7)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYCLASS;

                //Stock the enemy class chosen
                Data.iaData.value[line] = GameObject.Find("CondEnemyClass" + line + "/enemyClass").GetComponent<Dropdown>().value;
                //Stock which spell the player will use
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[GameObject.Find("CondEnemyClass" + line + "/playerSpells").GetComponent<Dropdown>().value];
            }

            if (categoryDropdown[line].value == 0)
            {

                Data.iaData.idCondition[line] = IaData.IaCondition.NULL;
            }
        }
        //Switch the current scene to the menu
        if (switchCatCount < 1)
        {
            //TODO print text "Choose one condition or more please"
            textAlert.SetActive(true);
        }
        else
        {
            Application.LoadLevel("mainScene");
        }

    }



    public void CallbackDropdownChanged(int _line)
    {


        categoryDropdown[_line-1] = GameObject.Find("categoryDropdown(" + _line + ")").GetComponent<Dropdown>();

            //dropdown line : from 1 to 8 => we shift from 0 to 7
            line = _line - 1;

            //Player's Health
            if (categoryDropdown[line].value == 1)
            {

                initLine(line);
                
                switchCatCount++;
                gObjSign[line].SetActive(true);
                gObjHealthBis[line].SetActive(true);
                gObjPourcentValue[line].SetActive(true);
                            
            }

            //Player's Mana
            if (categoryDropdown[line].value == 2)
            {

                initLine(line);
                
                switchCatCount++;
                gObjSign[line].SetActive(true);
                gObjManaBis[line].SetActive(true);
                gObjPourcentValue[line].SetActive(true);

        }

            //Enemy's Health
            if (categoryDropdown[line].value == 3)
            {
                initLine(line);

                gObjSign[line].SetActive(true);
                gObjHealthBisEn[line].SetActive(true);
                gObjPourcentValue[line].SetActive(true);
                switchCatCount++;
                            
            }

            //Enemy's Mana
            if (categoryDropdown[line].value == 4)
            {
                initLine(line);

                gObjSign[line].SetActive(true);
                gObjManaBisEn[line].SetActive(true);
                gObjPourcentValue[line].SetActive(true);
                switchCatCount++;

            }

            //Enemy casting
            if (categoryDropdown[line].value == 5)
            {
                initLine(line);

                switchCatCount++;
                gObjCast[line].SetActive(true);
                            
            }

            //Enemies Nb
            if (categoryDropdown[line].value == 6)
            {
                initLine(line);

                switchCatCount++;
                gObjEnemiesNb[line].SetActive(true);
                
            }

            //Enemy's Class       
            if (categoryDropdown[line].value == 7)
            {

                initLine(line);

                switchCatCount++;
                gObjEnemyClass[line].SetActive(true);
            
            }

            //Default Category
            if (categoryDropdown[line].value == 0)
            {
                
                initLine(line);

                
            

            }

}

    // Update is called once per frame
    void Update()
    {
        

    }   

}