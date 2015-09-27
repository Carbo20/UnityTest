﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroManager : MonoBehaviour {

    public Hero hero;
    private float heroActivation = 2;
    private float heroDeltaTime;

    private string heroActionStatus;

    public HeroController heroController;

	// Use this for initialization
	void Start ()
    {
        hero = new Hero(Data.heroData.hpMax, Data.heroData.manaMax,2,2,2,2);
        heroActionStatus = null;

        heroController = GetComponent<HeroController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        /* Speed computation, wait here the hero is ready to do something
        [TODO] Computation of the delta.time with the hero speed in heroActivation */
        heroDeltaTime += Time.deltaTime;
        if(heroDeltaTime >= heroActivation)
        {
            hero.IsReady = true;
            heroDeltaTime = 0;
        }

	}
    
}
