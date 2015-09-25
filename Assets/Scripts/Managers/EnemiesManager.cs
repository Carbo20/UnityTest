using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour {

    public List<EnemyManager> enemyList;
    private EnemyManager eManager;


	// Use this for initialization
	void Start () {
        enemyList = new List<EnemyManager>();
        GameObject enemy = Instantiate(Resources.Load("Prefabs/Monsters/Mumy")) as GameObject;
        eManager = enemy.GetComponent<EnemyManager>();
        enemyList.Add(eManager);
        /*GameObject enemy2 = Instantiate(Resources.Load("Prefabs/Monsters/Mumy")) as GameObject;
        eManager = enemy2.GetComponent<EnemyManager>();
        enemyList.Add(eManager);*/
    }
	
	// Update is called once per frame
	void Update () {
        /* Speed computation, wait here the hero is ready to do something
        [TODO] Computation of the delta.time with the hero speed in heroActivation */
        foreach (EnemyManager e in enemyList)
        {
            if(e == null)
            {
                enemyList.Remove(e);
                enemyList.Sort();
                break;
            }

            e.EnemyDeltaTime += Time.deltaTime;
            if (e.EnemyDeltaTime >= e.EnnemyActivation)
            {
                e.enemy.IsReady = true;
                e.EnemyDeltaTime = 0;
            }
        }

        if(enemyList.Count == 0) // Destroy the EnemiesManager if all enemies are dead
        {
            Destroy(gameObject);
        }

    }


}
