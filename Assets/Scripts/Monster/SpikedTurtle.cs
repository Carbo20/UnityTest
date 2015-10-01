using UnityEngine;
using System.Collections;

public class SpikedTurtle : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = true;
        Level = 10;
        Damage = 178;
        CdAttack = 2.5f;
        HpMax = 3520;
        Armor = 495;
        ManaMax = 1760;

        RegenHp = 50;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 3;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[0] = Data.EnemySkillType.SPIKE;
        SkillAvailable[0] = Data.EnemySkillType.BUTTSTOMP;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
        // Spike (+50% damage, + 50% armor, 5 sec, 10 secCd), ButtStomp (0xdamage, stun 3sec, 5secCd)
        // Attack  
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }

}