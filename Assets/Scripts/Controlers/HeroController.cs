using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    private bool isAttacking;
    private float timeAttacking;
    private float timeOfAttackBase;
    private float timeOfAttack;
    private bool crit;
    private float speed;
    private float speedBase;

    private Vector3 target;
    private Vector3 pos;
    private BackgroundControler backgrdController;
    private bool gamePaused;

	// Use this for initialization
	void Start () {
        isAttacking = false;
        timeAttacking = 0;
        timeOfAttackBase = 1f;
        speedBase = 2f;
        pos = transform.position;
        gamePaused = false;
        backgrdController = GameObject.Find("Background").GetComponent<BackgroundControler>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gamePaused) return;
        if (isAttacking) Attack();
	}

    void Attack()
    {

        if (timeAttacking < timeOfAttack / 2)
        {
            //transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.position = Vector3.Lerp(pos, target, timeAttacking*speed / (timeOfAttack/2));
        }
        else if (timeOfAttack >= timeOfAttack / 2 && timeAttacking < timeOfAttack)
        {
            //transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.position = Vector3.Lerp(target, pos, (timeAttacking-timeOfAttack/2)*speed / (timeOfAttack/2));
        }
        else
        {
            isAttacking = false;
            backgrdController.SetScrollAllow(true);
        }

        timeAttacking += Time.deltaTime;
    }

    /// <summary>
    /// Function that trigger the attack animation
    /// </summary>
    /// <param name="_crit">true if the attack is a critical</param>
    /// <param name="_target">position of the target</param>
    /// <param name="esp">from 0 to 1, pourcentage d'espacement entre la fin de l'attaque et la cible</param>
    public void triggerAttack(bool _crit, Vector3 _target, float esp)
    {
        timeAttacking = 0;
        if (crit)
        {
            timeOfAttack = timeOfAttackBase / 2;
            speed = speedBase * 2;
        }
        else
        {
            timeOfAttack = timeOfAttackBase;
            speed = speedBase;
        }
        isAttacking = true;
        backgrdController.SetScrollAllow(false);
        crit = _crit;
        target = Vector3.Lerp(pos, _target, esp);
    }

    public void SetPause(bool b)
    {
        gamePaused = b;
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

}
