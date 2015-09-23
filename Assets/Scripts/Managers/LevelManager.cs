using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    private Skill skill; //All the skill usable by the hero are here
    private EnemySkill mSkill;// All the monster skill are here
    private IA ia; //Here is the IA manager


    private GameObject hero;
    private HeroManager hManager;
    private EnemiesManager eManager;
    private GameObject text;


    private TextMesh enemyTextBar1;


    // Use this for initialization
    void Start ()
    {
        GameObject hero = Instantiate(Resources.Load("Prefabs/Hero")) as GameObject;
        hManager = hero.GetComponent<HeroManager>();
        GameObject enemies = Instantiate(Resources.Load("Prefabs/EnemiesManager")) as GameObject;
        eManager = enemies.GetComponent<EnemiesManager>();
        GameObject textBox = Instantiate(Resources.Load("Prefabs/Text")) as GameObject;
        enemyTextBar1 = textBox.GetComponent<TextMesh>();

        skill = new Skill(hManager,eManager);
        mSkill = new EnemySkill(hManager, eManager);
        ia = new IA(hManager, eManager, skill);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (eManager) // if a monster is always alive
        {
            //Loop
            HeroLoop();
            EnemiesLoop();
        }
        else // else we have to create a new bunch of enemies
        {
            GameObject enemies = Instantiate(Resources.Load("Prefabs/EnemiesManager")) as GameObject;
            eManager = enemies.GetComponent<EnemiesManager>();
            skill.UpdateEManager(eManager); //We have to update the new eManager into the skill class
        }

    }

    private void HeroLoop()
    {
        if (hManager.hero.IsDead)
        {
            /*[TODO] if we have to do something fot the death of the hero*/
        }
        if (hManager.hero.IsReady)
        {
            /*[TODO] A lot of stuff
            curently a testing stuff*/

            ia.ConditionComputation();

            /* End of the testing stuff */

            /*Use here the result of the IA computation to do something*/
            eManager.enemyList[0].enemy.TakeDamage(hManager.hero.DoDammage(2));
            enemyTextBar1.text = "-"+hManager.hero.DoDammage(2).ToString();
            hManager.hero.IsReady = false;
        }
    }

    private void EnemiesLoop()
    {
        foreach (EnemyManager e in eManager.enemyList)
        {
            if (e.enemy.IsReady)
            {
                //[TODO] A lot of stuff
                mSkill.actionList[(int)e.DoAnAction()]();
                e.enemy.IsReady = false;
            }
        }
    }



    public EnemiesManager EManager
    {
        get
        {
            return eManager;
        }

        set
        {
            eManager = value;
        }
    }
}
