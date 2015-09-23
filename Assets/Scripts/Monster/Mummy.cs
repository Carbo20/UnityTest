using UnityEngine;
using System.Collections;

public class Mummy : MonsterStatus {

    public Mummy()
    {
        HpMax = 10;
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
    }

    public override Data.SkillType DoAnAction()
    {
        Data.SkillType idSkill;
        idSkill = Data.SkillType.ATTACK;
        return idSkill;
    }
}
