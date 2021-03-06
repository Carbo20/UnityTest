﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour {

    public List<EnemyManager> enemyList;
    private EnemyManager eManager;
    private bool gamePaused;
    private EnemySkill mSkill;
    private Data.EnemySkillType eAction;

	// Use this for initialization
	void Start () {
        enemyList = new List<EnemyManager>();
        // TODO change the Temporary set for monsters BEGIN
        List<string> monstersToLoad = new List<string>();
        monstersToLoad.Add("Prefabs/Monsters/mumy");
        monstersToLoad.Add("Prefabs/Monsters/stonegolem");
        monstersToLoad.Add("Prefabs/Monsters/spikedturtle");
        monstersToLoad.Add("Prefabs/Monsters/slime");
        monstersToLoad.Add("Prefabs/Monsters/bat");
        monstersToLoad.Add("Prefabs/Monsters/minishroom");
        monstersToLoad.Add("Prefabs/Monsters/bigshroom");
        monstersToLoad.Add("Prefabs/Monsters/bigstomp");
        monstersToLoad.Add("Prefabs/Monsters/swordbear");
        monstersToLoad.Add("Prefabs/Monsters/gargoyle");
        monstersToLoad.Add("Prefabs/Monsters/pinkslob");

        int monsterToLoadRand = UnityEngine.Random.Range(0, monstersToLoad.Count);

        // TODO change the Temporary set for monsters END
        GameObject enemy = Instantiate(Resources.Load(monstersToLoad[monsterToLoadRand])) as GameObject;
        eManager = enemy.GetComponent<EnemyManager>();
        enemyList.Add(eManager);

        gamePaused = false;
        /*GameObject enemy2 = Instantiate(Resources.Load("Prefabs/Monsters/Mumy")) as GameObject;
        eManager = enemy2.GetComponent<EnemyManager>();
        enemyList.Add(eManager);*/
    }
	
	// Update is called once per frame
	void Update () {
        if (gamePaused) return;

        /* Speed computation, wait here the hero is ready to do something
        [TODO] Computation of the delta.time with the hero speed in heroActivation */
        foreach (EnemyManager e in enemyList)
        {
            int idEnemy = 0;
            if(e == null)
            {
                enemyList.Remove(e);
                enemyList.Sort();
                break;
            }

            if(e.enemy.IsReady == false)
            {
                e.EnemyDeltaTime += Time.deltaTime;
                if (e.EnemyDeltaTime >= e.EnnemyActivation)
                {
                    e.enemy.IsReady = true;
                    e.EnemyDeltaTime = 0;
                    eAction = e.DoAnAction();
                }
            }
            else
            {
                e.EnemyDeltaTime += Time.deltaTime;
                if (e.EnemyDeltaTime >= mSkill.cdList[(int)eAction])
                {
                    mSkill.UpdateWhoIsCasting(idEnemy);
                    mSkill.actionList[(int)eAction]();
                    e.enemy.IsReady = false;
                }
            }
            idEnemy++;
            
        }

        if(enemyList.Count == 0) // Destroy the EnemiesManager if all enemies are dead
        {
            Debug.Log("No more enemies");
            Destroy(gameObject);
        }

    }

    public void GetSkill(EnemySkill _mSkill)
    {
        mSkill = _mSkill;
    }

    public void SetPause(bool b)
    {
        gamePaused = b;
    }
}
