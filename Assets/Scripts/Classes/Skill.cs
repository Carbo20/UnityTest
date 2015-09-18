using UnityEngine;
using System.Collections;

public class Skill {

    private HeroManager hManager; //Reference toward the hero
    private EnemiesManager eManager;

	public Skill(HeroManager _hero,EnemiesManager _enemies)
    {
        hManager = _hero;
        eManager = _enemies;
    }

    public void UpdateEManager(EnemiesManager enemies)
    {
        eManager = enemies;
    }

    /*Here we have to place all the skill methods*/

    public void FakeBuffTest()
    {
        hManager.hero.Agility += 3;
    }

    public void FakeDebuffTest(int enemyId)
    {
        eManager.enemyList[enemyId].enemy.Strenght--;
    }

}
