using UnityEngine;
using System.Collections;

public class PinkSlob : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 6;
        Damage = 45;
        CdAttack = 2f;
        HpMax = 396;
        Armor = 270;
        ManaMax = 198;

        RegenHp = 5;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 2;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.GLUE;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
            // Glue(slow 50%, 5 sec, 8 sec Cd)
            // Attack  
        Data.EnemySkillType idSkill;

       // int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
