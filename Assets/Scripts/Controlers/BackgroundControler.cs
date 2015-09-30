using UnityEngine;
using System.Collections;

public class BackgroundControler : MonoBehaviour {

    private Vector3 startPosition;
    private SpriteRenderer sprite;


    private float scrollSpeed;
    private float tileSize;

    private bool isScrolling;
    private bool gamePaused;

    // Use this for initialization
    void Start ()
    {
        startPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        tileSize = sprite.bounds.extents.x;
        isScrolling = false;
        scrollSpeed = 3f;
        gamePaused = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gamePaused) return;

        
        if (isScrolling)
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
            transform.position = startPosition + Vector3.left * newPosition;
        }
    }


    public void SetPause(bool b)
    {
        gamePaused = b;
    }

    /* Getter and Setter */

    public bool IsScrolling
    {
        get
        {
            return isScrolling;
        }

        set
        {
            isScrolling = value;
        }
    }
    
}
