using UnityEngine;
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
   
	// Use this for initialization
	void Start ()
    {

        enemiesList = new List<Enemy>();
        e = new Enemy(20, 20, 20, 20, 20, 20);
        enemiesList.Add(e);
        enemiesAliveCount = enemiesList.Count;
        GameObject hero = Instantiate(Resources.Load("Prefabs/Hero")) as GameObject;
        hManager = hero.GetComponent<HeroManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        //The enemy do Damage to the hero
        h.TakeDamage(e.DoDamage());

        //Keep the number of alive enemies to 3
        if (enemiesAliveCount < enemiesMax)
        {
            enemiesList.Add(e);
        }

        e.TakeDamage(h.DoDammage(2));
        Debug.Log(e.Hp);
	}

    

}
