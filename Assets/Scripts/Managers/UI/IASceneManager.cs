﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IASceneManager : MonoBehaviour
{

    private Dropdown[] categoryDropdown = new Dropdown[8];

    private int indexButtonCatMax;
    private int indexCatMax;
    private int unchosenCount;
    private int valueInputfield = -1;
    private int line;
    private Button button;

    private GameObject[] gObjHealth = new GameObject[8];
    private GameObject[] gObjHealthBis = new GameObject[8];
    private GameObject[] gObjMana = new GameObject[8];
    private GameObject[] gObjManaBis = new GameObject[8];

    private GameObject[] gObjHealthEn = new GameObject[8];
    private GameObject[] gObjHealthBisEn = new GameObject[8];
    private GameObject[] gObjManaEn = new GameObject[8];
    private GameObject[] gObjManaBisEn = new GameObject[8];

    private GameObject[] gObjCast = new GameObject[8];
    private GameObject[] gObjEnemiesNb = new GameObject[8];
    private GameObject[] gObjEnemyClass = new GameObject[8];

    private GameObject[] gObjPourcentValue = new GameObject[8];
    private GameObject[] gObjSign = new GameObject[8];

    private float switchCatCount;
    private IaData.IaCondition conditionNb;
    private GameObject gObjEnemiesNbBis;



    //Text textToChoose = "You have to choose one or more conditions and actions";

    void initAll()
    {
        indexButtonCatMax = 8;
        unchosenCount = 0;

        for (int ind = 0; ind < indexButtonCatMax; ind++)
        {
           // gObjHealth[ind].SetActive(false);
            gObjHealthBis[ind].SetActive(false);
         //   gObjMana[ind].SetActive(false);
            gObjManaBis[ind].SetActive(false);

        //    gObjHealthEn[ind].SetActive(false);
            gObjHealthBisEn[ind].SetActive(false);
        //    gObjManaEn[ind].SetActive(false);
            gObjManaBisEn[ind].SetActive(false);

            gObjCast[ind].SetActive(false);
            gObjEnemiesNb[ind].SetActive(false);
            gObjEnemyClass[ind].SetActive(false);

            
            gObjPourcentValue[ind].SetActive(false);
            gObjSign[ind].SetActive(false);
        }
    }

    void initLine(int ind)
    {
       // gObjHealth[ind].SetActive(false);
        gObjHealthBis[ind].SetActive(false);
       // gObjMana[ind].SetActive(false);
        gObjManaBis[ind].SetActive(false);

       // gObjHealthEn[ind].SetActive(false);
        gObjHealthBisEn[ind].SetActive(false);
      //  gObjManaEn[ind].SetActive(false);
        gObjManaBisEn[ind].SetActive(false);

        gObjCast[ind].SetActive(false);
        gObjEnemiesNb[ind].SetActive(false);
        gObjEnemyClass[ind].SetActive(false);

        gObjPourcentValue[ind].SetActive(false);
        gObjSign[ind].SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        for (int ind=0; ind<8; ind++)
        { 
           // gObjHealth[ind] = GameObject.Find("CondHealth"+ind);
            gObjHealthBis[ind] = GameObject.Find("CondHealthBis" + ind);
           // gObjMana[ind] = GameObject.Find("CondMana" + ind);
            gObjManaBis[ind] = GameObject.Find("CondManaBis" + ind);

           // gObjHealthEn[ind] = GameObject.Find("CondHealthEn" + ind);
            gObjHealthBisEn[ind] = GameObject.Find("CondHealthBisEn" + ind);
           // gObjManaEn[ind] = GameObject.Find("CondManaEn" + ind);
            gObjManaBisEn[ind] = GameObject.Find("CondManaBisEn" + ind);

            gObjCast[ind] = GameObject.Find("CondCast" + ind);
            gObjEnemiesNb[ind] = GameObject.Find("CondEnemiesNb" + ind);
            gObjEnemyClass[ind] = GameObject.Find("CondEnemyClass" + ind);

            gObjPourcentValue[ind] = GameObject.Find("PourcentValue" + ind);

           // categoryDropdown[ind] = null;
            gObjSign[ind] = GameObject.Find("Sign" + ind);
        }
       
        initAll();
        
    }
    public void CallbackApplyAndFarm()
    {
        Data.iaData = new IaData(indexButtonCatMax);
        
        for (int line = 0; line < indexButtonCatMax; line++)
        {
            int indName = line + 1;
            categoryDropdown[line] = GameObject.Find("categoryDropdown(" + indName + ")").GetComponent<Dropdown>();
            //Player's Health
            if (categoryDropdown[line].value == 1)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.HEALTH;

                //Stock value of %
                Data.iaData.value[line] = gObjPourcentValue[line].GetComponent<Dropdown>().value;
                Debug.Log("Data.iaData.value[line]: "+ Data.iaData.value[line]);

                
                //Test which sign has been chosen
                if (gObjSign[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
                Debug.Log("Data.iaData.idSigne[line]: " + Data.iaData.idSigne[line]);
                Debug.Log("gObjHealthBis[line].GetComponent<Dropdown>().value: "+ gObjHealthBis[line].GetComponent<Dropdown>().value);
                //Stock which spell has been chosen
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[gObjHealthBis[line].GetComponent<Dropdown>().value];

            }

            //Player's Mana
            if (categoryDropdown[line].value == 2)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.MANA;

                //Stock value of %
                Data.iaData.value[line] = gObjPourcentValue[line].GetComponent<Dropdown>().value;
                Debug.Log("Data.iaData.value[line]: " + Data.iaData.value[line]);

                //Test which sign has been chosen
                if (gObjSign[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
                Debug.Log("MANASign: " + Data.iaData.idSigne[line]);
                //Stock which spell has been chosen
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[gObjManaBis[line].GetComponent<Dropdown>().value];
            }

            if (categoryDropdown[line].value == 3)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYHEALTH;

                //Stock value of %
                Data.iaData.value[line] = gObjPourcentValue[line].GetComponent<Dropdown>().value;
                Debug.Log("Data.iaData.value[line]: " + Data.iaData.value[line]);

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
                Data.iaData.value[line] = gObjPourcentValue[line].GetComponent<Dropdown>().value;
                Debug.Log("Data.iaData.value[line]: " + Data.iaData.value[line]);

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
                Debug.Log("Data.iaData.value[line]: " + Data.iaData.value[line]);
                //Stock which spell the player will use
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[GameObject.Find("CondEnemiesNb" + line + "/playerSpells").GetComponent<Dropdown>().value];

            }

            if (categoryDropdown[line].value == 7)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYCLASS;

                //Stock the enemy class chosen
                Data.iaData.value[line] = GameObject.Find("CondEnemyClass" + line + "/enemyClass").GetComponent<Dropdown>().value;
                Debug.Log("Data.iaData.value[line]: " + Data.iaData.value[line]);
                //Stock which spell the player will use
                Data.iaData.idSkill[line] = Data.heroData.skillAvailable[GameObject.Find("CondEnemyClass" + line + "/playerSpells").GetComponent<Dropdown>().value];
                Debug.Log("Data.iaData.idSkill[line]: " + Data.iaData.idSkill[line]);
            }

            if (categoryDropdown[line].value == 0)
            {

                Data.iaData.idCondition[line] = IaData.IaCondition.NULL;
            }
        }
        //Switch the current scene to the menu
        //Application.LoadLevel("mainScene");
    }



    public void CallbackDropdownChanged(int _line)
    {


        categoryDropdown[_line-1] = GameObject.Find("categoryDropdown(" + _line + ")").GetComponent<Dropdown>();
            Debug.Log("categoryDropdown(" + _line + ")");

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

                if (switchCatCount < 1)
                {
                    //TODO print text "Choose one condition or more please"
                }
            

            }

}

    // Update is called once per frame
    void Update()
    {
        

    }   

}