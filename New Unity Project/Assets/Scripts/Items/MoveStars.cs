using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStars : MonoBehaviour {

    public GameObject starfeild;
    public Vector2 direction;
    public GameObject joystick;
    public Sprite pos;

    private bool active = false;
    public void OnMouseOver()
    {
        Debug.Log("here");
        if (Input.GetMouseButton(0) && active )
        {
            joystick.GetComponent<SpriteRenderer>().sprite = pos;
            StartCoroutine(MoveToPosition(starfeild.transform, new Vector3(starfeild.transform.position.x + direction.x,
                starfeild.transform.position.y + direction.y, starfeild.transform.position.z), 0.25f));
        }
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 target, float time)
    {
        active = false;
        Vector3 curPos = transform.position;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(curPos, target, t);
            yield return null;
        }
        active = true;
    }

    public void activate()
    {
        active = true;
    }
}
