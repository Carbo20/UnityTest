using UnityEngine;
using System;

public class IA
{
    private int[] value; // The value of the condition
    private int[] idTarget; // ID of the target (0 for the hero, 1...3 for the monster)
    private Data.IaCondition[] idCondition; // ID of the condition (0 for Hp, 1 for mana ... [TODO] to complete)
    private int[] idSkill; // ID of the skill
    private int[] idSigne; // 0 for <, 1 for > and -1 for nothing;
    private int nbOrder; // Number of Order line into the IA 
    private bool isValid; // Trigger to know if ConditionComputation() found a valid condition

    private HeroManager hManager;
    private EnemiesManager eManager;
    private Skill skill;


    public IA(HeroManager _hManager, EnemiesManager _eManager, Skill _skill)
    {
        hManager = _hManager;
        eManager = _eManager;
        this.skill = _skill;

        nbOrder = 1;

        value = new int[nbOrder];
        idTarget = new int [nbOrder]; 
        idCondition = new Data.IaCondition[nbOrder]; 
        idSkill = new int[nbOrder]; 
        idSigne = new int[nbOrder];

        isValid = false;


        /* Testing value for the moment */
        value[0] = 50;
        idTarget[0] = 0;
        idCondition[0] = Data.IaCondition.HEALTH;
        idSkill[0] = 0;
        idSigne[0] = 0;
    }


    public void ConditionComputation()
    {
        for (int i = 0; i < nbOrder; i++)
        {
            if (idSigne[i] == 0)
            {
                switch (idCondition[i])
                {
                    case Data.IaCondition.HEALTH:
                        if (hManager.hero.Hp * 100 / hManager.hero.HpMax <= value[i]) // If Current HP < X%
                        {
                            DoAnAction(i);
                        }
                        break;
                    case Data.IaCondition.MANA:
                        if (hManager.hero.Mana * 100 / hManager.hero.ManaMax <= value[i]) // If Current Mana < X%
                        {
                            DoAnAction(i);
                        }
                        break;
                }
            }
            if (idSigne[i] == 1)
            {
                switch (idCondition[i])
                {
                    case Data.IaCondition.HEALTH:
                        if (hManager.hero.Hp * 100 / hManager.hero.HpMax >= value[i]) // If Current HP > X%
                        {
                            DoAnAction(i);
                        }
                        break;
                    case Data.IaCondition.MANA:
                        if (hManager.hero.Mana * 100 / hManager.hero.ManaMax >= value[i]) // If Current Mana > X%
                        {
                            DoAnAction(i);
                        }
                        break;
                }
            }
            if(idSigne[i] == -1) //Here the stuff who don't need to know < or >
            {
                switch (idCondition[i])
                {
                    case Data.IaCondition.NBENEMY:
                        if(eManager.enemyList.Count == value[i])
                        {
                            DoAnAction(i);
                        }
                        break;
                    case Data.IaCondition.ISCASTING:
                        int enemyId = 1;
                        foreach(EnemyManager e in eManager.enemyList)
                        {
                            if (e.enemy.IsCasting)
                            {
                                idTarget[i] = enemyId;
                                DoAnAction(i);
                            }
                            enemyId++;
                        }
                        break;
                }
            }


            if (isValid) break; // We stop the loop if we found a valid condition
        }
        isValid = false;
    }

    public void DoAnAction(int i)
    {
        skill.IdTarget = idTarget[i];
        skill.actionList[idSkill[i]]();
        isValid = true;
        Debug.Log("Do an action");
    }

}