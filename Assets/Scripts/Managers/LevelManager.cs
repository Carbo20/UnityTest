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
            Debug.Log("NEW ENEMIES");
            GameObject enemies = Instantiate(Resources.Load("Prefabs/EnemiesManager")) as GameObject;
            eManager = enemies.GetComponent<EnemiesManager>();
            skill.UpdateEManager(eManager); //We have to update the new eManager into the skill class
            mSkill.UpdateEManager(eManager);
        }

    }

    private void HeroLoop()
    {
        /*if (hManager.hero.IsDead)
        {
            /*[TODO] if we have to do something fot the death of the hero
        }*/
        if (hManager.hero.IsReady)
        {
            /* Here we compute the IA to know wich skill the hero will use */
            ia.ConditionComputation();

            /*Use here the result of the IA computation to do something*/
            Debug.Log("Hero Life : " + hManager.hero.Hp);
            enemyTextBar1.text = "-"+hManager.hero.DoDammage(2).ToString();
            hManager.hero.IsReady = false;
        }
    }

    private void EnemiesLoop()
    {
        foreach (EnemyManager e in eManager.enemyList)
        {
            int idEnemy = 0;
            if (e.enemy.IsReady)
            {
                //[TODO] A lot of stuff
                mSkill.UpdateWhoIsCasting(idEnemy);
                mSkill.actionList[(int)e.DoAnAction()]();
                e.enemy.IsReady = false;
            }
            idEnemy++;
        }
    }

    
}
