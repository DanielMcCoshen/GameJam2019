using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpriteOnMessage : MonoBehaviour {

    public Sprite newSprite;
	public void toggle()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
