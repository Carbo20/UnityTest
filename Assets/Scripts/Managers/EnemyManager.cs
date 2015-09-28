using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{

    public Enemy enemy;

    private float enemyDeltaTime;
    private float enemyActivation = 3; // [TODO] Change this after test

    EnemyStatus monsterStatus; // Stats + Skill

    // Use for the initialization just after the instantiation of the object in the enemiesManager
    void Awake()
    {
        monsterStatus = GetComponent<EnemyStatus>();
        monsterStatus.InitStatus();
        enemy = new Enemy(monsterStatus.Level, monsterStatus.HpMax, monsterStatus.ManaMax, monsterStatus.Strenght, monsterStatus.Intelligence, monsterStatus.Agility, monsterStatus.Vitality, monsterStatus.Armor);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (enemy.IsDead)
        {
            Debug.Log("I Diiiie !");
            Destroy(gameObject);
        }

    }

    public Data.EnemySkillType DoAnAction()
    {
        return monsterStatus.DoAnAction();
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
            return enemyActivation;
        }

        set
        {
            enemyActivation = value;
        }
    }
}
