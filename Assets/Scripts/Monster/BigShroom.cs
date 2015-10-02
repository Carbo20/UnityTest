using UnityEngine;
using System.Collections;

public class BigShroom : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 8;
        Damage = 156;
        CdAttack = 3f;
        HpMax = 1232;
        Armor = 360;
        ManaMax = 616;

        RegenHp = 10;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 2;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.POISON;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
            // PoisonCloud(dot, 2x damage, 4sec, 4 cast, 6 secCd)
            // Attack  
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
