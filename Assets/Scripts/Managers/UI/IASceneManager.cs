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
    //private float deltaPosY;
    private float switchCatCount;
    //private float originPosY;
    //private float gObjHealthOriginX;
    //private float gObjHealthBisOriginX;
  //  private float gObjManaOriginX;
   // private float gObjManaBisOriginX;
   // private float gObjCastOriginX;
    //private float gObjEnemiesNbOriginX;
   // private float gObjEnemyClassOriginX;

    //Text textToChoose = "You have to choose one or more conditions and actions";

    void init()
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



        
        init();

        //Get delta position between two conditions lines
        //deltaPosY = GameObject.Find("categoryDropdown(" + 1 + ")").GetComponent<Transform>().localPosition.y
        //            - GameObject.Find("categoryDropdown(" + 2 + ")").GetComponent<Transform>().localPosition.y;
       // originPosY = GameObject.Find("categoryDropdown(" + 1 + ")").GetComponent<Transform>().localPosition.y;

        //gObjHealthOriginX = gObjHealth.GetComponent<Transform>().localPosition.y;
        //gObjHealthBisOriginX = gObjHealthBis.GetComponent<Transform>().localPosition.y;
        //gObjManaOriginX = gObjMana.GetComponent<Transform>().localPosition.y;
        //gObjManaBisOriginX = gObjManaBis.GetComponent<Transform>().localPosition.y;
        //gObjCastOriginX = gObjCast.GetComponent<Transform>().localPosition.y;
        //gObjEnemiesNbOriginX = gObjEnemiesNb.GetComponent<Transform>().localPosition.y;
        //gObjEnemyClassOriginX = gObjEnemyClass.GetComponent<Transform>().localPosition.y;

        //Debug.Log("origin y: " + originPosY);
       // Debug.Log("Delta y: " + deltaPosY);
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
                //Debug.Log("switchCatCount: " + switchCatCount);

                //init();
                switchCatCount++;
                gObjHealth[indexButtonCat-1].SetActive(true);
                gObjHealthBis[indexButtonCat - 1].SetActive(true);
                //Pos y = Pos y + indexButtonCat*(Pos ybutton1 - Pos ybutton2)

                //currentPosY = gObjMana.GetComponent<Transform>().position.y;
                // gObjMana.GetComponent<Transform>().Translate(0, currentPosY + ((indexButtonCat - 1) * deltaPosY), 0);
                // currentPosY = gObjMana.GetComponent<Transform>().position.y;
                
                //gObjHealthClone.GetComponent<Transform>().Translate(gObjHealthOriginX, originPosY - ((indexButtonCat - 1) * deltaPosY), 0);
                //Debug.Log("gObjHealthClone pos: " +(originPosY - ((indexButtonCat - 1) * deltaPosY) ));
            }

            //Player's Mana
            if (categoryDropdown.value == 2)
            {
                //Debug.Log("switchCatCount: " + switchCatCount);

                
                switchCatCount++;
                gObjMana[indexButtonCat - 1].SetActive(true);
                gObjManaBis[indexButtonCat - 1].SetActive(true);
                //Pos y = Pos y + indexButtonCat*(Pos ybutton1 - Pos ybutton2)

               // currentPosY = gObjMana.GetComponent<Transform>().localPosition.y;
               // gObjMana.GetComponent<Transform>().Translate(0,currentPosY + ((indexButtonCat-1) * deltaPosY),0);
               // gObjMana.GetComponent<Transform>().Translate(0, currentPosY + ((indexButtonCat - 1) * deltaPosY), 0);

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
                
                switchCatCount++;
                gObjCast[indexButtonCat - 1].SetActive(true);
            }

            //Enemies Nb
            if (categoryDropdown.value == 6)
            {
                
                switchCatCount++;
                gObjEnemiesNb[indexButtonCat - 1].SetActive(true);
            }

            //Enemy's Class       
            if (categoryDropdown.value == 7)
            {               
                
                switchCatCount++;
                gObjEnemyClass[indexButtonCat - 1].SetActive(true);
            }

            //Default Category
            if (categoryDropdown.value == 0)
            {
                if (switchCatCount != 0)
                {
                    init();
                }
                switchCatCount++;
                
            }



            if (unchosenCount == indexCatMax)
            {
                //TODO print textToChoose to the screen
            }
        }
    }


    
}