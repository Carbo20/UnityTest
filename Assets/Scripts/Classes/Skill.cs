using UnityEngine;
using System;

public class Skill {

    private HeroManager hManager; //Reference toward the hero
    private EnemiesManager eManager;
    private bool isFireCapEquip; //Bool of example

    public Action[] actionList;
    public float[] cdAction;

    /*We can't use parameters with action, so i decide to stock them here*/
    private int idTarget;


    public Skill(HeroManager _hero, EnemiesManager _enemies)
    {
        hManager = _hero;
        eManager = _enemies;
        
        actionList = new Action[10];
        cdAction = new float[10];


        /* Put here all the callback into the ActionList */
        actionList[(int)Data.SkillType.ATTACK] = Attack;
        actionList[(int)Data.SkillType.TESTSKILL] = FakeDebuffTest;
        actionList[(int)Data.SkillType.FIREBALL] = FakeFireBall;
        actionList[(int)Data.SkillType.HEAL] = Heal;

        /* Put here all the cd Skill */
        cdAction[(int)Data.SkillType.ATTACK] = 1.5f;
        cdAction[(int)Data.SkillType.FIREBALL] = 3f;
        cdAction[(int)Data.SkillType.HEAL] = 3f;

        Debug.Log("Skill cd : " + cdAction[0]);
    }

    public void UpdateEManager(EnemiesManager enemies)
    {
        Debug.Log("Ennemies Update in Skill : " + enemies);
        eManager = enemies;
    }

    //I will use FakeFireBall to use it like a complete example for all other skill

    public void FakeFireBall()
    {

        int FireBallDammage = 100;
        int FireBallMana = 15;

        /*Example for skill wich could be up by a legendary item
          Here : If we own the magic fire cape of the death, we own more dammage for the fireball*/

        if (isFireCapEquip)
        {
            FireBallDammage += 50;
        }

        /*[TODO] Put a fireball animation here*/
        eManager.enemyList[idTarget - 1].enemy.TakeDamage(FireBallDammage, Data.heroData.level); 
        hManager.hero.UseMana(FireBallMana);
    }

    /*Here we have to place all the skill methods*/

    public void Attack()
    {
        Boolean isACrit = hManager.hero.IsCritical();

        eManager.enemyList[idTarget - 1].enemy.TakeDamage(hManager.hero.DoDammage(isACrit), Data.heroData.level);
        
        hManager.heroController.triggerAttack(false, eManager.enemyList[idTarget - 1].transform.position, 0.8f); //declenchement de l'animation d'attaque <TODO: capter les coups critique, booleen à mettre en parametre
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
