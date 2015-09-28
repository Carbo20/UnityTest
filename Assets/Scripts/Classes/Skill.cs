using UnityEngine;
using System;

public class Skill {

    private HeroManager hManager; //Reference toward the hero
    private EnemiesManager eManager;
    private bool isFireCapEquip; //Bool of example

    public Action[] actionList;
    

    /*We can't use parameters with action, so i decide to stock them here*/
    private int idTarget;


    public Skill(HeroManager _hero,EnemiesManager _enemies)
    {
        hManager = _hero;
        eManager = _enemies;

        actionList = new Action[10];

        /* Test for put all the method in testAction Array */
        actionList[(int)Data.SkillType.ATTACK] = Attack;
        actionList[(int)Data.SkillType.TESTSKILL] = FakeDebuffTest;
        actionList[(int)Data.SkillType.FIREBALL] = FakeFireBall;
        actionList[(int)Data.SkillType.HEAL] = Heal;
    }

    public void UpdateEManager(EnemiesManager enemies)
    {
        Debug.Log("Ennemies Update in Skill : " + enemies);
        eManager = enemies;
    }

    //I will use FakeFireBall to use it like a complete example for all other skill

    public void FakeFireBall()
    {

        int FireBallDammage = 5;
        int FireBallMana = 15;

        /*Example for skill wich could be up by a legendary item
          Here : If we own the magic fire cape of the death, we own more dammage for the fireball*/

        if (isFireCapEquip)
        {
            FireBallDammage = 50;
        }

        /*[TODO] Put a fireball animation here*/
        eManager.enemyList[idTarget - 1].enemy.TakeDamage(FireBallDammage, 2); // TODO add hero's level instead of 2
        hManager.hero.UseMana(FireBallMana);

    }

    /*Here we have to place all the skill methods*/

    public void Attack()
    {
        eManager.enemyList[idTarget - 1].enemy.TakeDamage(hManager.hero.DoDammage(2), 2); // TODO add hero's level instead of 2
        
        hManager.heroController.triggerAttack(false, eManager.enemyList[idTarget - 1].transform.position, 0.8f); //declanchement de l'animation d'attaque <TODO: capter les coups critique, booleen à mettre en parametre
    }

    public void FakeBuffTest()
    {
        hManager.hero.Agility += 3;
    }

    public void FakeDebuffTest()
    {
        eManager.enemyList[0].enemy.Strenght--;
    }

    public void Heal()
    {
        int healAmount = 10;

        hManager.hero.RegainHp(healAmount);
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
