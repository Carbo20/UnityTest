using UnityEngine;
using System.Collections;

public class Bat : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 4;
        Damage = 38;
        CdAttack = 1f;
        HpMax = 132;
        Armor = 144;
        ManaMax = 66;

        RegenHp = 5;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 2;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.BITE;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
            // Bite (1x damage, StealLife)
            // Attack  
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
