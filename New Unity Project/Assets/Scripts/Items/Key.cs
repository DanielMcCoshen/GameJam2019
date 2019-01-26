using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public GameObject keyPad;
    public char value;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            keyPad.SendMessage("keyTyped", value);
        }
    }
 }
