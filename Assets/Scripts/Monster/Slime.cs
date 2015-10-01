using UnityEngine;
using System.Collections;

public class Slime : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 1;
        Damage = 13;
        CdAttack = 2f;
        HpMax = 59;
        Armor = 36;
        ManaMax = 30;

        RegenHp = 2;
        RegenMana = 0;
        
        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 2;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.DIVIDE;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT 
            // IF HEALTH > 40%  Divide (-1/2 health, create a copy of himself)
            // ATTACK
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
