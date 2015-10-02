using UnityEngine;
using System.Collections;

public class SwordBear : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = true;
        MagicFind = 70;
        Level = 5;
        Damage = 124;
        CdAttack = 3f;
        HpMax = 1210;
        Armor = 225;
        ManaMax = 968;

        RegenHp = 15;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 3;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.BITE;
        SkillAvailable[2] = Data.EnemySkillType.RAGE;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
            // Bleed (dot, 2x damage, 2 secCd),
            // Rage(+50%speed, -10%armor, -5%Health, 4secCd)
            // Attack  
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
