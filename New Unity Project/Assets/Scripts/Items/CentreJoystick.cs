using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreJoystick : MonoBehaviour
{
    public Sprite neutralPos;
    
    public void OnMouseExit()
    {
        Debug.Log("neutral");
        gameObject.GetComponent<SpriteRenderer>().sprite = neutralPos;
    }
}
