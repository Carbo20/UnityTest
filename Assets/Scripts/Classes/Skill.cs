using UnityEngine;
using System;

public class Skill {

    private HeroManager hManager; //Reference toward the hero
    private EnemiesManager eManager;

    public Action[] actionList;
    
    /*We can't use parameters with action, so i decide to stock them here*/
    private int idTarget;


    public Skill(HeroManager _hero,EnemiesManager _enemies)
    {
        hManager = _hero;
        eManager = _enemies;

        actionList = new Action[10];

        /* Test for put all the method in testAction Array */
        actionList[0] = FakeBuffTest;
        actionList[1] = FakeDebuffTest;
    }

    public void UpdateEManager(EnemiesManager enemies)
    {
        eManager = enemies;
    }

    /*Here we have to place all the skill methods*/

    public void FakeBuffTest()
    {
        hManager.hero.Agility += 3;
    }

    public void FakeDebuffTest()
    {
        eManager.enemyList[0].enemy.Strenght--;
    }



    /* Getter and Setter*/


    public int IdTarget
    {
        get
        {
            return idTarget;
        }

        set
        {
            idTarget = value;
        }
    }
}
