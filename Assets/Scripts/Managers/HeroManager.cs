using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroManager : MonoBehaviour {

    Hero h;
	// Use this for initialization
	void Start ()
    {
        h = new Hero(10,10,2,2,2,2);
        h.TakeDamage(2);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Hero manager is here");
	}
}
