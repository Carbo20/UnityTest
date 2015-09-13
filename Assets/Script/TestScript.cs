using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

    private float timer, speed;
    private float dx, dy;
	// Use this for initialization
	void Start () {
        transform.position.Set(-6f, -3.5f, 0f);
        speed = 5;
        timer = 0;
        dx = 1;
        dy = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer < 1)
        {
            transform.Translate(dx * speed * Time.deltaTime, dy * speed * Time.deltaTime, 0);
        }
        else
        {

            if (dx == 1 && dy == 0)
            {
                dx = 0;
                dy = 1;
            }
            else if (dx == 0 && dy == 1)
            {
                dx = -1;
                dy = 0;
            }
            else if (dx == -1 && dy == 0)
            {
                dx = 0;
                dy = -1;
            }
            else if (dx == 0 && dy == -1)
            {
                dx = 1;
                dy = 0;
            }
            timer = 0;
        }
	}
}
