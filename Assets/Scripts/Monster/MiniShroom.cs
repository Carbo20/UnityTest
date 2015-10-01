using UnityEngine;
using System.Collections;

public class MiniShroom : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 7;
        Damage = 97;
        CdAttack = 2.5f;
        HpMax = 323;
        Armor = 315;
        ManaMax = 0;

        RegenHp = 20;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 1;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        Data.EnemySkillType idSkill;
        // REPEAT
        // Attack  
        //Data.EnemySkillType idSkill;

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
