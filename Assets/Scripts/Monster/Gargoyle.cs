using UnityEngine;
using System.Collections;

public class Gargoyle : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 2;
        Damage = 91;
        CdAttack = 2.5f;
        HpMax = 132;
        Armor = 126;
        ManaMax = 130;

        RegenHp = 10;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 2;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.HARDSKIN;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
            // HardSkin(+50% armor, 2 secCast, 5 secDuration, 10 secCd)  
            // Attack  
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
