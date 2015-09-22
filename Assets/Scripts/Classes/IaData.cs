using UnityEngine;
using System.Collections;

public class IaData {

    public enum IaCondition { HEALTH, MANA, ENEMYHEALTH, ENEMYMANA, ENEMYCAST, ENEMYNB, ENEMYCLASS };

    public int[] value; // The value of the condition in percent
    public int[] idTarget; // ID of the target (0 for the hero, 1...3 for the monster)
    public IaCondition[] idCondition; // ID of the condition (0 for Hp, 1 for mana ... [TODO] to complete)
    public int[] idSkill; // ID of the skill
    public int[] idSigne; // 0 for <, 1 for > and -1 for nothing;
    public int nbOrder; // Number of Order line into the IA 
    public bool isValid; // Trigger to know if ConditionComputation() found a valid condition

}
