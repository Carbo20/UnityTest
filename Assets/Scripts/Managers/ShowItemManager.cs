using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowItemManager : MonoBehaviour {

    private float speed;
    private bool goRight;
    private float timeSpendInTheMiddle;
    private float timeInTheMiddle;
    private float timeOfRotate, timeRotating;
    private float rotateSpeed;

    public List<Sprite> sprites;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = sprites[Data.showItemId];
        transform.position = new Vector3(-10.5f, 0, 0);
        speed = 15f;
        goRight = true;
        timeSpendInTheMiddle = 0;
        timeInTheMiddle = .3f;
        rotateSpeed = 1500f;
        timeRotating = 0;
        timeOfRotate = .3f;
    }
	
	// Update is called once per frame
	void Update () {
        if (goRight && transform.position.x < 0) 
            transform.Translate(speed * Time.deltaTime, 0, 0);
        if (goRight && transform.position.x >= 0)
        {
            if (timeRotating < timeOfRotate)
            {
                timeRotating += Time.deltaTime;
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            }
            else if (timeSpendInTheMiddle < timeInTheMiddle)
            {
                if(timeRotating >= timeOfRotate && transform.rotation.z != 0)
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                timeSpendInTheMiddle += Time.deltaTime;
            }
            else
            {
                
                goRight = false;
            }
        }

        if (!goRight && transform.position.y < 15)
            transform.Translate(0, speed * Time.deltaTime, 0);
        if (!goRight && transform.position.y >= 15) 
        {
            transform.position = new Vector3(-10.5f, 0, 0);
            goRight = true;
            timeSpendInTheMiddle = 0;
            timeRotating = 0;
        }
	}
}
