using UnityEngine;
using System;

public class IA
{

    private HeroManager hManager;
    private EnemiesManager eManager;
    private Skill skill;


    public IA(HeroManager _hManager, EnemiesManager _eManager, Skill _skill)
    {
        hManager = _hManager;
        eManager = _eManager;
        this.skill = _skill;
        
        Data.iaData.nbOrder = 1;

        Data.iaData.value = new int[Data.iaData.nbOrder];
        Data.iaData.idTarget = new int [Data.iaData.nbOrder];
        Data.iaData.idCondition = new IaData.IaCondition[Data.iaData.nbOrder];
        Data.iaData.idSkill = new int[Data.iaData.nbOrder];
        Data.iaData.idSigne = new int[Data.iaData.nbOrder];

        Data.iaData.isValid = false;


        /* Testing value for the moment */
        Data.iaData.value[0] = 50;
        Data.iaData.idTarget[0] = 0;
        Data.iaData.idCondition[0] = IaData.IaCondition.HEALTH;
        Data.iaData.idSkill[0] = 0;
        Data.iaData.idSigne[0] = 0;
    }


    public void ConditionComputation()
    {
        for (int i = 0; i < Data.iaData.nbOrder; i++)
        {
            if (Data.iaData.idSigne[i] == 0)
            {
                switch (Data.iaData.idCondition[i])
                {
                    case IaData.IaCondition.HEALTH:
                        if (hManager.hero.Hp * 100 / hManager.hero.HpMax <= Data.iaData.value[i]) // If Current HP < X%
                        {
                            DoAnAction(i);
                        }
                        break;
                    case IaData.IaCondition.MANA:
                        if (hManager.hero.Mana * 100 / hManager.hero.ManaMax <= Data.iaData.value[i]) // If Current Mana < X%
                        {
                            DoAnAction(i);
                        }
                        break;
                }
            }
            if (Data.iaData.idSigne[i] == 1)
            {
                switch (Data.iaData.idCondition[i])
                {
                    case IaData.IaCondition.HEALTH:
                        if (hManager.hero.Hp * 100 / hManager.hero.HpMax >= Data.iaData.value[i]) // If Current HP > X%
                        {
                            DoAnAction(i);
                        }
                        break;
                    case IaData.IaCondition.MANA:
                        if (hManager.hero.Mana * 100 / hManager.hero.ManaMax >= Data.iaData.value[i]) // If Current Mana > X%
                        {
                            DoAnAction(i);
                        }
                        break;
                }
            }
            if(Data.iaData.idSigne[i] == -1) //Here the stuff who don't need to know < or >
            {
                switch (Data.iaData.idCondition[i])
                {
                    case IaData.IaCondition.ENEMYNB:
                        if(eManager.enemyList.Count == Data.iaData.value[i])
                        {
                            DoAnAction(i);
                        }
                        break;
                    case IaData.IaCondition.ENEMYCAST:
                        int enemyId = 1;
                        foreach(EnemyManager e in eManager.enemyList)
                        {
                            if (e.enemy.IsCasting)
                            {
                                Data.iaData.idTarget[i] = enemyId;
                                DoAnAction(i);
                            }
                            enemyId++;
                        }
                        break;
                }
            }


            if (Data.iaData.isValid) break; // We stop the loop if we found a valid condition
        }
        Data.iaData.isValid = false;
    }

    public void DoAnAction(int i)
    {
        skill.IdTarget = Data.iaData.idTarget[i];
        skill.actionList[Data.iaData.idSkill[i]]();
        Data.iaData.isValid = true;
        Debug.Log("Do an action");
    }
    /*
    public int NbOrder
    {
        get
        {
            return nbOrder;
        }

        set
        {
            nbOrder = value;
        }
    }
    */

}