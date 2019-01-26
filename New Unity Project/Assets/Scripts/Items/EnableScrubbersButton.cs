using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScrubbersButton : MonoBehaviour {
    public GameObject manager;
    public Sprite aiEnabledSprite;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.SendMessage("enableScrubbers");
        }
    }

    public void success()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = aiEnabledSprite;
    }

}
