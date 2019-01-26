using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject leftArrow;
    public GameObject rightArrow;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = ScreenPosition.CENTRE;
	}
	
	public void moveLeft()
    {
        if (!gameObject.transform.position.Equals(ScreenPosition.LEFT))
        {
            if (gameObject.transform.position.Equals(ScreenPosition.CENTRE))
            {
                StartCoroutine(MoveToPosition(gameObject.transform, ScreenPosition.LEFT, 2));
            }
            else if (gameObject.transform.position.Equals(ScreenPosition.RIGHT))
            {
                StartCoroutine(MoveToPosition(gameObject.transform, ScreenPosition.CENTRE, 2));
            }
            else
            {
                Debug.LogError("This should not happen");
            }
        } 
    }

    public void moveRight()
    {
        if (!gameObject.transform.position.Equals(ScreenPosition.RIGHT))
        {
            if (gameObject.transform.position.Equals(ScreenPosition.CENTRE))
            {
                StartCoroutine(MoveToPosition(gameObject.transform, ScreenPosition.RIGHT, 2));
            }
            else if (gameObject.transform.position.Equals(ScreenPosition.LEFT))
            {
                StartCoroutine(MoveToPosition(gameObject.transform, ScreenPosition.CENTRE, 2));
            }
            else
            {
                Debug.LogError("This should not happen");
            }
        }
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 target, float time)
    {
        leftArrow.SendMessage("disable");
        rightArrow.SendMessage("disable");
        Vector3 curPos = transform.position;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(curPos, target, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
        if (!transform.position.Equals(ScreenPosition.RIGHT))
        {
            rightArrow.SendMessage("enable");
        }
        if (!transform.position.Equals(ScreenPosition.LEFT))
        {
            leftArrow.SendMessage("enable");
        }
    }
}

static class ScreenPosition
{
    public static Vector3 CENTRE = new Vector3(0, 0, -10);
    public static Vector3 LEFT = new Vector3(-72, 0, -10);
    public static Vector3 RIGHT = new Vector3(72, 0, -10);
}
