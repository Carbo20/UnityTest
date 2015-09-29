using UnityEngine;
using System.Collections;
using System;

public class EnemySkill
{
    private HeroManager hManager; //Reference toward the hero
    private EnemiesManager eManager;

    public Action[] actionList;
    public float[] cdList;

    /*We can't use parameters with action, so i decide to stock them here*/
    private int idTarget;
    private int idEnemyWhoCast;

    public EnemySkill(HeroManager _hero, EnemiesManager _enemies)
    {
        hManager = _hero;
        eManager = _enemies;
        actionList = new Action[10];
        cdList = new float[10];

        /* Test for put all the method in testAction Array */
        actionList[(int)Data.EnemySkillType.ATTACK] = Attack;
        actionList[(int)Data.EnemySkillType.FIREBALL] = Attack;

        /* Put all the cd Skill here */
        cdList[(int)Data.EnemySkillType.ATTACK] = 1.5f;
        cdList[(int)Data.EnemySkillType.FIREBALL] = 3f;
    }

    public void UpdateEManager(EnemiesManager enemies)
    {
        eManager = enemies;
    }

    //I will use FakeFireBall to use it like a complete example for all other skill

    public void UpdateWhoIsCasting(int idEnemy)
    {
        idEnemyWhoCast = idEnemy;
    }

    public void FakeFireBall()
    {

        int FireBallDammage = 50;
        int FireBallMana = 15;

        /*[TODO] Put a fireball animation here
          [TODO] Change this part of the code to be usable by ennemies*/
        hManager.hero.TakeDamage(FireBallDammage, eManager.enemyList[idEnemyWhoCast].enemy.Level);
        eManager.enemyList[idEnemyWhoCast].enemy.UseMana(FireBallMana);

    }

    /*Here we have to place all the skill methods*/

    public void Attack()
    {
        hManager.hero.TakeDamage(eManager.enemyList[idEnemyWhoCast].enemy.DoDamage(), eManager.enemyList[idEnemyWhoCast].enemy.Level);
    }

    public void FakeBuffTest()
    {
        Debug.Log("Skill 1");
    }

    public void FakeDebuffTest()
    {
        Debug.Log("Skill 2");
    }
}
