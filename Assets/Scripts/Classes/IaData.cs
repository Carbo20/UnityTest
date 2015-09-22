using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IaData
{

    public enum IaCondition {HEALTH, MANA, ENEMYHEALTH, ENEMYMANA, ENEMYCAST, ENEMYNB, ENEMYCLASS, NULL };
    public List<int> value; // The value of the condition in percent
    public List<int> idTarget; // ID of the target (0 for the hero, 1...3 for the monster)
    public List<IaCondition> idCondition; // ID of the condition (0 for Hp, 1 for mana ... [TODO] to complete)
    public List<int> idSkill; // ID of the skill
    public List<int> idSigne; // 0 for >, 1 for < and -1 for nothing;
    public int nbOrder; // Number of Order line into the IA 

    public IaData()
    {
        value = new List<int>();
        idTarget = new List<int>();
        idCondition = new List<IaCondition>();
        idSkill = new List<int>();
        idSigne = new List<int>();
        nbOrder = 0;
    }

}
