using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
    
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
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (eManager) // if a monster is always alive
        {
            //Hero Loop
            HeroLoop();

            //Monsters Loop
            EnemiesLoop();
           
        }
        else // else we have to create a new bunch of enemies
        {
            GameObject enemies = Instantiate(Resources.Load("Prefabs/EnemiesManager")) as GameObject;
            eManager = enemies.GetComponent<EnemiesManager>();
        }

    }

    private void HeroLoop()
    {
        if (hManager.hero.IsReady)
        {
            /*[TODO] A lot of stuff
            curently a testing stuff*/
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
                e.enemy.IsReady = false;
            }
        }
    }
}
