using UnityEngine;
using System.Collections;

public class ShowItemManager : MonoBehaviour {

    private float speed;
    private bool goRight;
    private float timeSpendInTheMiddle;
    private float timeInTheMiddle;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-10.5f, 0, 0);
        speed = 15f;
        goRight = true;
        timeSpendInTheMiddle = 0;
        timeInTheMiddle = .3f;
        Debug.Log(Screen.height);
    }
	
	// Update is called once per frame
	void Update () {
        if (goRight && transform.position.x < 0) 
            transform.Translate(speed * Time.deltaTime, 0, 0);
        if (goRight && transform.position.x >= 0)
        {
            if (timeSpendInTheMiddle < timeInTheMiddle)
            {
                timeSpendInTheMiddle += Time.deltaTime;
            }
            else
            {
                goRight = false;
            }
        }
       
        if(!goRight )
            transform.Translate(0, speed * Time.deltaTime, 0);
	}
}
