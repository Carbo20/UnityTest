using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroManager : MonoBehaviour {

    public Hero hero;
    private Skill skill;
    private IA ia;

    private float heroDeltaTime;
    private Data.SkillType iaResult;

    private string heroActionStatus;

    public HeroController heroController;

    private bool gamePause;

	// Use this for initialization
	void Start ()
    {
        hero = new Hero(Data.heroData.hpMax, Data.heroData.manaMax,2,2,2,2);
        heroActionStatus = null;
        gamePause = false;
        heroController = GetComponent<HeroController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gamePause) return;
        /* Speed computation, wait here the hero is ready to do something
        [TODO] Computation of the delta.time with the hero speed in heroActivation */
        
        if(hero.IsReady == false)
        {
            heroDeltaTime += Time.deltaTime;
            if (heroDeltaTime >= Data.heroData.heroActivation)
            {
                //Debug.Log("ICI");
                hero.IsReady = true;
                iaResult = ia.ConditionComputation();
                heroDeltaTime = 0;
            }
        }
        else
        {
            heroDeltaTime += Time.deltaTime;
            Debug.Log(iaResult);
            if (heroDeltaTime >= skill.cdAction[(int)iaResult])
            {
                hero.IsReady = false;
                skill.actionList[(int)iaResult]();
                heroDeltaTime = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Data.heroData.xp = Data.heroData.GetXPForLevelCumulated(Data.heroData.level);
            hero.LevelUP();
            Data.heroData.xpForNextLevel = Data.heroData.GetXPForLevelCumulated(Data.heroData.level);
            Debug.Log("hero level " + Data.heroData.level);
        }
        if (Input.GetKey(KeyCode.X))
        {
            hero.GetXp(1);
            Debug.Log("hero xp " + Data.heroData.xp + " xpGoal " + Data.heroData.xpForNextLevel );
        }
	}

    public void GetIA(IA _ia)
    {
        ia = _ia;
    }

    public void GetSkill(Skill _skill)
    {
        skill = _skill;
    }
    
    public void SetPause(bool b)
    {
        gamePause = b;
    }
}
