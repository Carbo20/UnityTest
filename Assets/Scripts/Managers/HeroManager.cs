using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroManager : MonoBehaviour {

    public Hero hero;
	// Use this for initialization
	void Start ()
    {
        hero = new Hero(10,10,2,2,2,2);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Hero manager is here");
	}
}
