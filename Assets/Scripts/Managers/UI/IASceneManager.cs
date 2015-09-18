using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IASceneManager : MonoBehaviour
{

    private Dropdown categoryDropdown;
    private int indexButtonCat;
    private int indexCatMax = 8;
    private int unchosenCount = 0;
    private Button button;

    private GameObject gObjHealth;
    private GameObject gObjHealthBis;
    private GameObject gObjMana;
    private GameObject gObjManaBis;
    private GameObject gObjCast;
    private GameObject gObjEnemiesNb;
    private GameObject gObjEnemyClass;

    //Text textToChoose = "You have to choose one or more conditions and actions";

    // Use this for initialization
    void Start()
    {

        gObjHealth = GameObject.Find("CondHealth");
        gObjHealth.SetActive(false);
        gObjHealthBis = GameObject.Find("CondHealthBis");
        gObjHealthBis.SetActive(false);

        gObjMana = GameObject.Find("CondMana");
        gObjMana.SetActive(false);
        gObjManaBis = GameObject.Find("CondManaBis");
        gObjManaBis.SetActive(false);

        gObjCast = GameObject.Find("CondCast");
        gObjCast.SetActive(false);

        gObjEnemiesNb = GameObject.Find("CondEnemiesNb");
        gObjEnemiesNb.SetActive(false);

        gObjEnemyClass = GameObject.Find("CondEnemyClass");
        gObjEnemyClass.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        for (indexButtonCat = 1; indexButtonCat < indexCatMax; indexButtonCat++)
        {
            categoryDropdown = GameObject.Find("categoryDropdown(" + indexButtonCat + ")").GetComponent<Dropdown>();
            Debug.Log("categoryDropdown(" + indexButtonCat + ")");
            // GameObject.Find("ConditionGoup").SetActive(false);

            //Player's Health
            if (categoryDropdown.value == 1)
            {
                gObjHealth.SetActive(true);
                gObjHealthBis.SetActive(true);
                //Pos y = Pos y + indexButtonCat*(Pos ybutton1 - Pos ybutton2)
            }

            //Player's Mana
            if (categoryDropdown.value == 2)
            {
                gObjMana.SetActive(true);
                gObjManaBis.SetActive(true);
                //Pos y = Pos y + indexButtonCat*(Pos ybutton1 - Pos ybutton2)
            }

            //Enemy's Health
            if (categoryDropdown.value == 3)
            {

            }

            //Enemy's Mana
            if (categoryDropdown.value == 4)
            {

            }

            //Enemy casting
            if (categoryDropdown.value == 5)
            {
                gObjCast.SetActive(true);
            }

            //Enemies Nb
            if (categoryDropdown.value == 6)
            {
                gObjEnemiesNb.SetActive(true);
            }

            //Enemy's Class       
            if (categoryDropdown.value == 7)
            {
                gObjEnemyClass.SetActive(true);
            }

            //Default Category
            if (categoryDropdown.value == 0)
            {
                unchosenCount++;
            }



            if (unchosenCount == indexCatMax)
            {
                //TODO print textToChoose to the screen
            }
        }
    }
}