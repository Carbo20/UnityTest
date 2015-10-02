using UnityEngine;
using System.Collections;

public class StoneGolem : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 9;
        Damage = 167;
        CdAttack = 3f;
        HpMax = 743;
        Armor = 608;
        ManaMax = 371;

        RegenHp = 20;
        RegenMana = 0;

        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;
        NumberOfSkills = 2;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.MINISTUN;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
        // MiniStun (0,5 sec stun, half attack damage, 2 sec cd, 10 cast, 2 secCd)
        // Attack  
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }

}