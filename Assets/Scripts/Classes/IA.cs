using UnityEngine;
using System;

public class IA
{
    /*Variable for test an IA
    [TODO] Transform all this stuff in a list stuff to use more than one order line*/
    private int value; // The value of the condition
    private int idFocus; // ID of the target (0 for the hero, 1...3 for the monster)
    private Data.IaCondition idCondition; // ID of the condition (0 for Hp, 1 for mana ... [TODO] to complete)
    private int idSkill; // ID of the skill
    private int idSigne; // 0 for >, 1 for <
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

        /* Testing value for the moment */
        value = 50;
        idFocus = 0; //Hero target
        idCondition = Data.IaCondition.HEALTH; // Hp Condition
        idSkill = 0; // Heal
        idSigne = 0;
        nbOrder = 1;

        isValid = false;
    }


    public void ConditionComputation()
    {
        for (int i = 0; i < nbOrder; i++)
        {
            if (idSigne == 0)
            {
                switch (idCondition)
                {
                    case Data.IaCondition.HEALTH:
                        if (hManager.hero.Hp * 100 / hManager.hero.HpMax <= value)
                        {
                            DoAnAction();
                        }
                        break;
                    case Data.IaCondition.MANA:
                        if (hManager.hero.Mana * 100 / hManager.hero.ManaMax <= value)
                        {
                            DoAnAction();
                        }
                        break;
                }
            }
            if (idSigne == 1)
            {

            }
            if (isValid) break; // We stop the loop if we found a valid condition
        }
        isValid = false;
    }

    public void DoAnAction()
    {
        skill.actionList[idSkill]();
        isValid = true;
        Debug.Log("Do an action");
    }

}