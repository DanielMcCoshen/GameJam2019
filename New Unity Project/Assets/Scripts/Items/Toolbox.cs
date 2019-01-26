using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    private bool isEnabled = true;
    public GameObject manager;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            manager.SendMessage("aquireTools");
            manager.SendMessage("removeInteractible", gameObject);
            Destroy(gameObject);
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
