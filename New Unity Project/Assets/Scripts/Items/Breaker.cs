using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour {
    public GameObject manager;
    public Sprite onSprite;

    private bool isEnabled = true;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            manager.SendMessage("turnPowerOn");
            gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
    }

    public void enable()
    {
        isEnabled = true;
    }

    public void disable()
    {
        isEnabled = false;
    }
}
