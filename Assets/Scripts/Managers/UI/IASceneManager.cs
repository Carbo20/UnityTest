using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IASceneManager : MonoBehaviour
{

    private Dropdown categoryDropdown, categoryDropdown1, categoryDropdown2;
    private int line;
    private int indexButtonCatMax;
    private int indexCatMax;
    private int unchosenCount;
    private int valueInputfield = -1;
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


    private float switchCatCount;
    private IaData.IaCondition conditionNb;



    //Text textToChoose = "You have to choose one or more conditions and actions";

    void initAll()
    {
        indexButtonCatMax = 8;
        unchosenCount = 0;
        Data.iaData.nbOrder = indexButtonCatMax;

        for (int ind = 0; ind < indexButtonCatMax; ind++)
        {
            gObjHealth[ind].SetActive(false);
            gObjHealthBis[ind].SetActive(false);
            gObjMana[ind].SetActive(false);
            gObjManaBis[ind].SetActive(false);

            gObjHealthEn[ind].SetActive(false);
            gObjHealthBisEn[ind].SetActive(false);
            gObjManaEn[ind].SetActive(false);
            gObjManaBisEn[ind].SetActive(false);

            gObjCast[ind].SetActive(false);
            gObjEnemiesNb[ind].SetActive(false);
            gObjEnemyClass[ind].SetActive(false);
        }
    }

    void initLine(int ind)
    {
        gObjHealth[ind].SetActive(false);
        gObjHealthBis[ind].SetActive(false);
        gObjMana[ind].SetActive(false);
        gObjManaBis[ind].SetActive(false);

        gObjHealthEn[ind].SetActive(false);
        gObjHealthBisEn[ind].SetActive(false);
        gObjManaEn[ind].SetActive(false);
        gObjManaBisEn[ind].SetActive(false);

        gObjCast[ind].SetActive(false);
        gObjEnemiesNb[ind].SetActive(false);
        gObjEnemyClass[ind].SetActive(false);

    }

    // Use this for initialization
    void Start()
    {
        for (int ind=0; ind<8; ind++)
        { 
            gObjHealth[ind] = GameObject.Find("CondHealth"+ind);
            gObjHealthBis[ind] = GameObject.Find("CondHealthBis" + ind);
            gObjMana[ind] = GameObject.Find("CondMana" + ind);
            gObjManaBis[ind] = GameObject.Find("CondManaBis" + ind);

            gObjHealthEn[ind] = GameObject.Find("CondHealthEn" + ind);
            gObjHealthBisEn[ind] = GameObject.Find("CondHealthBisEn" + ind);
            gObjManaEn[ind] = GameObject.Find("CondManaEn" + ind);
            gObjManaBisEn[ind] = GameObject.Find("CondManaBisEn" + ind);

            gObjCast[ind] = GameObject.Find("CondCast" + ind);
            gObjEnemiesNb[ind] = GameObject.Find("CondEnemiesNb" + ind);
            gObjEnemyClass[ind] = GameObject.Find("CondEnemyClass" + ind);

        }



        
        initAll();

        
    }
    public void CallbackApplyAndFarm()
    {
        
        
    }

    public void CallbackInputfield(int text) {
         valueInputfield = text;
    }

    public void CallbackDropdownChanged(int line)
    {
            

            categoryDropdown = GameObject.Find("categoryDropdown(" + line + ")").GetComponent<Dropdown>();
            Debug.Log("categoryDropdown(" + line + ")");

            line = line - 1;

            //Player's Health
            if (categoryDropdown.value == 1)
            {

                initLine(line);
                Data.iaData.idCondition[line] = IaData.IaCondition.HEALTH;
                switchCatCount++;
                gObjHealth[line].SetActive(true);
                gObjHealthBis[line].SetActive(true);

                //Get value of %
                Data.iaData.value[line] = valueInputfield;
                
                //Test which sign has been chosen
                if (gObjHealth[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
            }

            //Player's Mana
            if (categoryDropdown.value == 2)
            {

                initLine(line);
                Data.iaData.idCondition[line] = IaData.IaCondition.MANA;
                switchCatCount++;
                gObjMana[line].SetActive(true);
                gObjManaBis[line].SetActive(true);

                //Test which sign has been chosen
                if (gObjHealth[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
            }

            //Enemy's Health
            if (categoryDropdown.value == 3)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYHEALTH;
                gObjHealthEn[line].SetActive(true);
                gObjHealthBisEn[line].SetActive(true);
                switchCatCount++;

                //Test which sign has been chosen
                if (gObjHealth[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
            }

            //Enemy's Mana
            if (categoryDropdown.value == 4)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYMANA;
                gObjManaEn[line].SetActive(true);
                gObjManaBisEn[line].SetActive(true);
                switchCatCount++;

                //Test which sign has been chosen
                if (gObjHealth[line].GetComponent<Dropdown>().value == 0)
                {
                    Data.iaData.idSigne[line] = 0;
                }
                else
                {
                    Data.iaData.idSigne[line] = 1;
                }
            }

            //Enemy casting
            if (categoryDropdown.value == 5)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYCAST;
                initLine(line);
                switchCatCount++;
                gObjCast[line].SetActive(true);

                //Set none sign
                Data.iaData.idSigne[line] = -1;
            }

            //Enemies Nb
            if (categoryDropdown.value == 6)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYNB;
                initLine(line);
                switchCatCount++;
                gObjEnemiesNb[line].SetActive(true);
                
                //Set none sign
                Data.iaData.idSigne[line] = -1;
            }

            //Enemy's Class       
            if (categoryDropdown.value == 7)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.ENEMYCLASS;
                initLine(line);
                switchCatCount++;
                gObjEnemyClass[line].SetActive(true);

                //Set none sign
                Data.iaData.idSigne[line] = -1;

            }

            //Default Category
            if (categoryDropdown.value == 0)
            {
                Data.iaData.idCondition[line] = IaData.IaCondition.NULL;
                initLine(line);

                unchosenCount++;

                //Set none sign
                Data.iaData.idSigne[line] = -1;

            }



        if (unchosenCount == indexButtonCatMax)
            {
                //TODO print textToChoose to the screen
            }
        
    
}

    // Update is called once per frame
    void Update()
    {
        

    }   

}