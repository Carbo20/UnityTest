using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IASceneManager : MonoBehaviour
{

    private Dropdown categoryDropdown, categoryDropdown1, categoryDropdown2;
    private int indexButtonCat;
    private int indexCatMax;
    private int unchosenCount;
    private Button button;

    private GameObject[] gObjHealth = new GameObject[8];
    private GameObject[] gObjHealthBis = new GameObject[8];
    private GameObject[] gObjMana = new GameObject[8];
    private GameObject[] gObjManaBis = new GameObject[8];
    private GameObject[] gObjCast = new GameObject[8];
    private GameObject[] gObjEnemiesNb = new GameObject[8];
    private GameObject[] gObjEnemyClass = new GameObject[8];
    private GameObject[] gObjHealthClone = new GameObject[8];

    private float switchCatCount;
 

    //Text textToChoose = "You have to choose one or more conditions and actions";

    void initAll()
    {
        indexCatMax = 8;
        unchosenCount = 0;

        for (int ind = 0; ind < 8; ind++)
        {
            gObjHealth[ind].SetActive(false);
            gObjHealthBis[ind].SetActive(false);
            gObjMana[ind].SetActive(false);
            gObjManaBis[ind].SetActive(false);
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
            gObjCast[ind] = GameObject.Find("CondCast" + ind);
            gObjEnemiesNb[ind] = GameObject.Find("CondEnemiesNb" + ind);
            gObjEnemyClass[ind] = GameObject.Find("CondEnemyClass" + ind);
        }



        
        initAll();

        
    }

    // Update is called once per frame
    void Update()
    {


        for (indexButtonCat = 1; indexButtonCat < indexCatMax; indexButtonCat++)
        {
            categoryDropdown = GameObject.Find("categoryDropdown(" + indexButtonCat + ")").GetComponent<Dropdown>();
            Debug.Log("categoryDropdown(" + indexButtonCat + ")");

            switchCatCount = 0;
            
            //Player's Health
            if (categoryDropdown.value == 1)
            {
               
                initLine(indexButtonCat-1);

                switchCatCount++;
                gObjHealth[indexButtonCat-1].SetActive(true);
                gObjHealthBis[indexButtonCat - 1].SetActive(true);
               
            }

            //Player's Mana
            if (categoryDropdown.value == 2)
            {
                
                initLine(indexButtonCat - 1);

                switchCatCount++;
                gObjMana[indexButtonCat - 1].SetActive(true);
                gObjManaBis[indexButtonCat - 1].SetActive(true);
               
            }

            //Enemy's Health
            if (categoryDropdown.value == 3)
            {
                

                switchCatCount++;
            }

            //Enemy's Mana
            if (categoryDropdown.value == 4)
            {
                
                switchCatCount++;
            }

            //Enemy casting
            if (categoryDropdown.value == 5)
            {
                initLine(indexButtonCat - 1);
                switchCatCount++;
                gObjCast[indexButtonCat - 1].SetActive(true);
            }

            //Enemies Nb
            if (categoryDropdown.value == 6)
            {
                initLine(indexButtonCat - 1);
                switchCatCount++;
                gObjEnemiesNb[indexButtonCat - 1].SetActive(true);
            }

            //Enemy's Class       
            if (categoryDropdown.value == 7)
            {
                initLine(indexButtonCat - 1);
                switchCatCount++;
                gObjEnemyClass[indexButtonCat - 1].SetActive(true);
            }

            //Default Category
            if (categoryDropdown.value == 0)
            {
                initLine(indexButtonCat - 1);
                
                switchCatCount++;
                
            }



            if (unchosenCount == indexCatMax)
            {
                //TODO print textToChoose to the screen
            }
        }
    }


    
}