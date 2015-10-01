using UnityEngine;
using System.Collections;

public class BackgroundControler : MonoBehaviour {

    private Vector3 startPosition;
    private SpriteRenderer sprite;

    private float scrollSpeed;
    private float tileSize;
    private float time;

    private bool isScrolling, scrollAllow;
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
        scrollAllow = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gamePaused) return;

        
        if (scrollAllow && isScrolling)
        {
            time = time + Time.deltaTime;
            float newPosition = Mathf.Repeat(time * scrollSpeed, tileSize);
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

    public void SetScrollAllow(bool b)
    {
        scrollAllow = b;
    }
    
}
