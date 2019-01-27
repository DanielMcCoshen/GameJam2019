using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfeildScroll : MonoBehaviour {
    public GameObject prefab;

    public Sprite withReticle;


    public GameObject left = null;
    public GameObject right = null;
    public GameObject up = null;
    public GameObject down = null;
    public bool priority = false;
	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate()
    {
        if (priority)
        {
            if (transform.position.x >= 55 && transform.position.y >= 130)
            {
                createLeft();
                createDown();
                if (left.GetComponent<StarfeildScroll>().down == null)
                {
                    left.GetComponent<StarfeildScroll>().down = Instantiate(prefab, 
                        transform.position + new Vector3(-300, -300, 0), Quaternion.identity);
                    left.GetComponent<StarfeildScroll>().down.transform.parent = transform.parent;
                    left.GetComponent<StarfeildScroll>().down.GetComponent<StarfeildScroll>().up = left;
                    down.GetComponent<StarfeildScroll>().left = left.GetComponent<StarfeildScroll>().down;
                    left.GetComponent<StarfeildScroll>().down.GetComponent<StarfeildScroll>().right = down;
                }
            } // left and down
            if (transform.position.x >= 55 && transform.position.y <= -130)
            {
                createLeft();
                createUp();
                if (left.GetComponent<StarfeildScroll>().up == null)
                {
                    left.GetComponent<StarfeildScroll>().up = Instantiate(prefab,
                        transform.position + new Vector3(-300, 300, 0), Quaternion.identity);
                    left.GetComponent<StarfeildScroll>().up.transform.parent = transform.parent;
                    left.GetComponent<StarfeildScroll>().up.GetComponent<StarfeildScroll>().down = left;
                    up.GetComponent<StarfeildScroll>().left = left.GetComponent<StarfeildScroll>().up;
                    left.GetComponent<StarfeildScroll>().up.GetComponent<StarfeildScroll>().right = up;
                }
            } //left and up
            if (transform.position.x <= -200 && transform.position.y >= 130) //right and down
            {
                createRight();
                createDown();
                if (right.GetComponent<StarfeildScroll>().down == null)
                {
                    right.GetComponent<StarfeildScroll>().down = Instantiate(prefab,
                        transform.position + new Vector3(300, -300, 0), Quaternion.identity);
                    right.GetComponent<StarfeildScroll>().down.transform.parent = transform.parent;
                    right.GetComponent<StarfeildScroll>().down.GetComponent<StarfeildScroll>().up = right;
                    down.GetComponent<StarfeildScroll>().right = right.GetComponent<StarfeildScroll>().down;
                    right.GetComponent<StarfeildScroll>().down.GetComponent<StarfeildScroll>().left = down;
                }
            }
            if (transform.position.x <= -200 && transform.position.y <= -130) //right and up
            {
                createRight();
                createUp();
                if (right.GetComponent<StarfeildScroll>().up == null)
                {
                    right.GetComponent<StarfeildScroll>().up = Instantiate(prefab,
                        transform.position + new Vector3(300, -300, 0), Quaternion.identity);
                    right.GetComponent<StarfeildScroll>().up.transform.parent = transform.parent;
                    right.GetComponent<StarfeildScroll>().up.GetComponent<StarfeildScroll>().down = right;
                    up.GetComponent<StarfeildScroll>().right = right.GetComponent<StarfeildScroll>().up;
                    right.GetComponent<StarfeildScroll>().up.GetComponent<StarfeildScroll>().left = up;
                }
            }
            if (transform.position.x >= 55)
            {
                createLeft();
            }
            if (transform.position.x <= -200)
            {
                createRight();
            }
            if (transform.position.y >= 130)
            {
                createDown();
            }
            if (transform.position.y <= -130)
            {
                createUp();
            }
        }

        if (transform.position.x >= 100)
        {
            if (priority)
            {
                left.GetComponent<StarfeildScroll>().priority = true;
            }
            removeFromSiblings();
            Destroy(gameObject);
        }
        if (transform.position.x <= -250)
        {
            if (priority)
            {
                right.GetComponent<StarfeildScroll>().priority = true;
            }
            removeFromSiblings();
            Destroy(gameObject);
        }
        if (transform.position.y <= -170)
        {
            if (priority)
            {
                up.GetComponent<StarfeildScroll>().priority = true;
            }
            removeFromSiblings();
            Destroy(gameObject);
        }
        if (transform.position.y >= 170)
        {
            if (priority)
            {
                down.GetComponent<StarfeildScroll>().priority = true;
            }
            removeFromSiblings();
            Destroy(gameObject);
        }
    }

    void createLeft()
    {
        if (left == null)
        {
            left = Instantiate(prefab, transform.position - new Vector3(300, 0, 0),
                Quaternion.identity);
            left.transform.parent = transform.parent;
            left.GetComponent<StarfeildScroll>().right = gameObject;
        }
    }
    void createRight()
    {
        if (right == null)
        {
            right = Instantiate(prefab, transform.position + new Vector3(300, 0, 0),
                Quaternion.identity);
            right.transform.parent = transform.parent;
            right.GetComponent<StarfeildScroll>().left = gameObject;
        }
    }
    void createUp()
    {
        if (up == null)
        {
            up = Instantiate(prefab, transform.position + new Vector3(0, 300, 0),
                Quaternion.identity);
            up.transform.parent = transform.parent;
            up.GetComponent<StarfeildScroll>().down = gameObject;
        }
    }
    void createDown()
    {
        if (down == null)
        {
            down = Instantiate(prefab, transform.position + new Vector3(0, -300, 0),
                Quaternion.identity);
            down.transform.parent = transform.parent;
            down.GetComponent<StarfeildScroll>().up = gameObject;
        }
    }

    void removeFromSiblings()
    {
        if (left != null)
        {
            left.GetComponent<StarfeildScroll>().right = null;
        }
        if (right != null)
        {
            right.GetComponent<StarfeildScroll>().left = null;
        }
        if (up != null)
        {
            up.GetComponent<StarfeildScroll>().down = null;
        }
        if (down != null)
        {
            down.GetComponent<StarfeildScroll>().up = null;
        }
    }

    void targetingOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = withReticle;
        prefab.GetComponent<SpriteRenderer>().sprite = withReticle;
    }
}
