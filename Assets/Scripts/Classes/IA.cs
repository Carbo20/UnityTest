using System;

public class IA
{
    /*Variable for test an IA*/
    private int value; // The value of the condition
    private int idFocus; // ID of the target (0 for the hero, 1...3 for the monster)
    private int idCondition; // ID of the condition (0 for Hp, 1 for mana ... [TODO] to complete)
    private int idSkill; // ID of the skill

    

    private HeroManager hManager;
    private EnemiesManager eManager;
    private Skill skill;

    public IA(HeroManager _hManager, EnemiesManager _eManager,Skill _skill)
    {
        hManager = _hManager;
        eManager = _eManager;
        this.skill = _skill;

        value = 50;
        idFocus = 0; //Hero target
        idCondition = 0; // Hp Condition
        idSkill = 12; // Heal
    }
    

    public void ConditionComputation()
    {
        skill.testAction[0]();
    }

}