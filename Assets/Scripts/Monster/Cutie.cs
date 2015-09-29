using UnityEngine;
using System.Collections;

public class Cutie : EnemyStatus
{

    public override void InitStatus()
    {
        Level = 1;
        HpMax = 10;
        ManaMax = 0;

        RegenHp = 0;
        RegenMana = 0;

        Strenght = 3;
        Agility = 3;
        Intelligence = 3;
        Vitality = 3;

        Speed = 3;
        Damage = 2;
        SpellDamage = 0;
        Dodge = 0;
        Critical = 0;

        CdAttack = 1.5f;

        /* List here all the skill the monster can use */
        SkillAvailable = new Data.EnemySkillType[2];
        SkillAvailable[0] = Data.EnemySkillType.ATTACK;
        SkillAvailable[1] = Data.EnemySkillType.FIREBALL;
    }

    public override Data.EnemySkillType DoAnAction()
    {
        Data.EnemySkillType idSkill;

        int rnd = Random.Range(0, 2);


        idSkill = SkillAvailable[rnd];
        return idSkill;
    }
}
