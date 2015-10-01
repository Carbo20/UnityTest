﻿using UnityEngine;
using System.Collections;

public class BigStomp : EnemyStatus
{
    public override void InitStatus()
    {
        IsBoss = false;
        Level = 3;
        Damage = 64;
        CdAttack = 2f;
        HpMax = 132;
        Armor = 135;
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
        SkillAvailable[1] = Data.EnemySkillType.STOMP;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        // REPEAT
            // Stomp (1x damage, Stun)
            // Attack  
        Data.EnemySkillType idSkill;

       // int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
