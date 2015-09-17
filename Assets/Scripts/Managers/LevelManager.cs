﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public System.Collections.Generic.List<Enemy> enemiesList;
    public Enemy e;
    public Hero h;
    public int enemiesAliveCount = 0;
    public int enemiesMax = 3;

    private GameObject Hero;
    private HeroManager hManager;
    private EnemiesManager eManager;
   
	// Use this for initialization
	void Start ()
    {
        GameObject hero = Instantiate(Resources.Load("Prefabs/Hero")) as GameObject;
        hManager = hero.GetComponent<HeroManager>();
        GameObject enemies = Instantiate(Resources.Load("Prefabs/EnemiesManager")) as GameObject;
        eManager = enemies.GetComponent<EnemiesManager>();
        Debug.Log("hero"+eManager);
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Hero Loop
        if (hManager.hero.IsReady)
        {
            //[TODO] A lot of stuff
        }

        //Monsters Loop
        foreach(EnemyManager e in eManager.enemyList)
        {
            if (e.enemy.IsReady)
            {
                //[TODO] A lot of stuff
            }
        }

	}

    

}
