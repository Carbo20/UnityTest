using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public Enemy enemy;

    private float enemyDeltaTime;
    private float ennemyActivation;

    // Use for the initialization just after the instantiation of the object in the enemiesManager
    void Awake()
    {
        enemy = new Enemy(6, 6, 4, 4, 4, 4);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (enemy.IsDead)
        {
            Debug.Log("I Diiiie !");
            Destroy(gameObject);
        }
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
