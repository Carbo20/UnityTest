using UnityEngine;
using System;

public class Skill {

    private HeroManager hManager; //Reference toward the hero
    private EnemiesManager eManager;

    public Action[] testAction;

    public Skill(HeroManager _hero,EnemiesManager _enemies)
    {
        hManager = _hero;
        eManager = _enemies;

        testAction = new Action[10];

        /* Test for put all the method in testAction Array */
        testAction[0] = FakeBuffTest;
        testAction[1] = FakeDebuffTest;
    }

    public void UpdateEManager(EnemiesManager enemies)
    {
        eManager = enemies;
    }

    /*Here we have to place all the skill methods*/

    public void FakeBuffTest()
    {
        hManager.hero.Agility += 3;
        Debug.Log("Si ce message s'affiche c'est que mon tableau de callback marche like a pro !");
    }

    public void FakeDebuffTest()
    {
        eManager.enemyList[0].enemy.Strenght--;
    }

}
