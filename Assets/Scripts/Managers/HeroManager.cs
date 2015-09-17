using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroManager : MonoBehaviour {

    public Hero hero;
    private float heroActivation = 0;
    private float heroDeltaTime;
    private float DeltaTime;

	// Use this for initialization
	void Start ()
    {
        hero = new Hero(10,10,2,2,2,2);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Hero manager is here");

        /* Speed computation, wait here the hero is ready to do something
        [TODO] Computation of the delta.time with the hero speed in heroActivation */
        heroDeltaTime += DeltaTime;
        if(heroDeltaTime >= heroActivation)
        {
            hero.IsReady = true;
        }
	}
}
