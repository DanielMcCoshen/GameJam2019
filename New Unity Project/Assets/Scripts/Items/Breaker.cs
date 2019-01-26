using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour {
    public GameObject manager;
    public Sprite onSprite;
    public GameObject closedAndOn;

    private bool isEnabled = true;
    private bool hasBeenFlipped;
    
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            if (hasBeenFlipped)
            {
                Debug.Log("here");
                manager.SendMessage("removeInteractible", gameObject);
                Instantiate(closedAndOn);
                Destroy(gameObject);
            }
            else
            {
                manager.SendMessage("turnPowerOn");
                gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
                hasBeenFlipped = true;
            }
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
