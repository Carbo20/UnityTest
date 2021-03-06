﻿using UnityEngine;
using System.Collections;

public class Mummy : EnemyStatus
{

    public override void InitStatus()
    {
        Level = 1;
        HpMax = 66;
        ManaMax = 30;

        Armor = 30;

        RegenHp = 2;
        RegenMana = 0;

        Damage = 5;
        SpellDamage = 7;
        Dodge = 0;
        Critical = 0;

        CdAttack = 1.5f;
        NumberOfSkills = 2;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[NumberOfSkills];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.FIREBALL;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        /* Here is an example for monster IA 
        A Simple Random IA for example */
        Data.EnemySkillType idSkill;

        //int rnd = Random.Range(0, NumberOfSkills);

        idSkill = SkillAvailable[0];
        return idSkill;
    }
}
