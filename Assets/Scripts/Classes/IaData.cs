using UnityEngine;
using System.Collections;

public class IaData
{

    public enum IaCondition {HEALTH, MANA, ENEMYHEALTH, ENEMYMANA, ENEMYCAST, ENEMYNB, ENEMYCLASS, NULL};
    public int[] value; // The value of the condition in percent OR the enemy nb OR enemy class
    public int[] idTarget; // ID of the target (0 for the hero, 1...3 for the monster)
    public IaCondition[] idCondition; // ID of the condition (0 for Hp, 1 for mana ... [TODO] to complete)
    public Data.SkillType[] idSkill; // ID of the skill
    public int[] idSigne; // 0 for >, 1 for < and -1 for nothing;
    public int nbOrder; // Number of Order line into the IA 
    public int nbOrderMax;
    public int nbLvlRequireToAquireNewOrder;

    public IaData()
    {
        nbOrderMax = 8; //TODO 10!
        nbLvlRequireToAquireNewOrder = 25;
        nbOrder = Data.heroData.nbIAOrderAvailable; 
        value = new int[nbOrder];
        idTarget = new int[nbOrder];
        idCondition = new IaCondition[nbOrder];

        for (int i = 0; i <nbOrder; i++)
        {
            idCondition[i] = IaData.IaCondition.NULL;
        }

        idSkill = new Data.SkillType[nbOrder];
        idSigne = new int[nbOrder];
    }

}
