﻿using UnityEngine;
using System.Collections;
using System;

public class EnemySkill  {

    private HeroManager hManager; //Reference toward the hero
    private EnemiesManager eManager;
    private bool isFireCapEquip; //Bool of example

    public Action[] actionList;


    /*We can't use parameters with action, so i decide to stock them here*/
    private int idTarget;


    public EnemySkill(HeroManager _hero, EnemiesManager _enemies)
    {
        hManager = _hero;
        eManager = _enemies;
        actionList = new Action[10];

        /* Test for put all the method in testAction Array */
        actionList[(int)Data.EnemySkillType.ATTACK] = FakeBuffTest;
        actionList[(int)Data.EnemySkillType.FIREBALL] = FakeDebuffTest;
    }

    public void UpdateEManager(EnemiesManager enemies)
    {
        eManager = enemies;
    }

    //I will use FakeFireBall to use it like a complete example for all other skill

    public void FakeFireBall()
    {

        int FireBallDammage = 20;
        int FireBallMana = 15;

        /*Example for skill wich could be up by a legendary item
          Here : If we own the magic fire cape of the death, we own more dammage for the fireball*/

        if (isFireCapEquip)
        {
            FireBallDammage = 50;
        }

        /*[TODO] Put a fireball animation here*/
        eManager.enemyList[idTarget - 1].enemy.TakeDamage(FireBallDammage);
        hManager.hero.UseMana(FireBallMana);

    }

    /*Here we have to place all the skill methods*/

    public void FakeBuffTest()
    {
        Debug.Log("Skill 1");
    }

    public void FakeDebuffTest()
    {
        Debug.Log("Skill 2");
    }

}