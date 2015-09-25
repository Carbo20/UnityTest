using UnityEngine;
using System.Collections;

public class Mummy : EnemyStatus
{

    public override void InitStatus()
    {
        Level = 2;
        HpMax = 20;
        ManaMax = 30;

        RegenHp = 2;
        RegenMana = 0;

        Strenght = 3;
        Agility = 1;
        Intelligence = 7;
        Vitality = 7;

        Speed = 3;
        Damage = 5;
        SpellDamage = 7;
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
        /* Here is an example for monster IA 
        A Simple Random IA for example*/
        Data.EnemySkillType idSkill;

        int rnd = Random.Range(0, 2);


        idSkill = SkillAvailable[rnd];
        return idSkill;
    }
}
