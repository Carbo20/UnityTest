using UnityEngine;
using System;

public class IA
{

    private HeroManager hManager;
    private EnemiesManager eManager;
    private Skill skill;

    private bool isValid = false;

    public IA(HeroManager _hManager, EnemiesManager _eManager, Skill _skill)
    {
        hManager = _hManager;
        eManager = _eManager;
        skill = _skill;
        
        //Data.iaData.nbOrder = 8; // [TODO] Important to fixe it when we will have a dynamic nbOrder
        
        isValid = false;
        
    }


    public Data.SkillType ConditionComputation()
    {
        for (int i = 0; i < Data.iaData.nbOrder; i++)
        {
            if (Data.iaData.idSigne[i] == 0)
            {
                switch (Data.iaData.idCondition[i])
                {
                    case IaData.IaCondition.HEALTH:
                        if (hManager.hero.Hp * 100 / hManager.hero.HpMax >= Data.iaData.value[i]) // If Current HP > X%
                        {
                            return DoAnAction(i);
                        }
                        break;
                    case IaData.IaCondition.MANA:
                        if (hManager.hero.Mana * 100 / hManager.hero.ManaMax >= Data.iaData.value[i]) // If Current Mana > X%
                        {
                            return DoAnAction(i);
                        }
                        break;
                }
            }
            if (Data.iaData.idSigne[i] == 1)
            {
                switch (Data.iaData.idCondition[i])
                {
                    case IaData.IaCondition.HEALTH:
                        if (hManager.hero.Hp * 100 / hManager.hero.HpMax <= Data.iaData.value[i]) // If Current HP < X%
                        {
                            return DoAnAction(i);
                        }
                        break;
                    case IaData.IaCondition.MANA:
                        if (hManager.hero.Mana * 100 / hManager.hero.ManaMax <= Data.iaData.value[i]) // If Current Mana < X%
                        {
                            return DoAnAction(i);
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
                            return DoAnAction(i);
                        }
                        break;
                    case IaData.IaCondition.ENEMYCAST:
                        int enemyId = 1;
                        foreach(EnemyManager e in eManager.enemyList)
                        {
                            if (e.enemy.IsCasting)
                            {
                                Data.iaData.idTarget[i] = enemyId;
                                return DoAnAction(i);
                            }
                            enemyId++;
                        }
                        break;
                }
            }


            if (isValid) break; // We stop the loop if we found a valid condition
        }
        isValid = false;
        return Data.SkillType.ATTACK; // By default the hero is attacking
    }

    public Data.SkillType DoAnAction(int i)
    {
        skill.IdTarget = 1; // Here waiting the change for the bottom line
                            //skill.IdTarget = Data.iaData.idTarget[i];

        isValid = true;
        return Data.iaData.idSkill[i];
    }

}