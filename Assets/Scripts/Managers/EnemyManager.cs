using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public Enemy enemy;

    private float enemyDeltaTime;
    private float ennemyActivation;

   

    // Use this for initialization
    void Start () {
        enemy = new Enemy(20, 20, 4, 4, 4, 4);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("EnemyManger is here");
	}

    public float EnemyDeltaTime
    {
        get
        {
            return enemyDeltaTime;
        }

        set
        {
            enemyDeltaTime = value;
        }
    }

    public float EnnemyActivation
    {
        get
        {
            return ennemyActivation;
        }

        set
        {
            ennemyActivation = value;
        }
    }
}
