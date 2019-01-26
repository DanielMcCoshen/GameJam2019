using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAiButton : MonoBehaviour {

    public GameObject manager;
    public Sprite aiEnabledSprite;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.SendMessage("enableAi");
        }
    }

    public void success()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = aiEnabledSprite;
    }

}
