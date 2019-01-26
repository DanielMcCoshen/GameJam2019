using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsTerminal : MonoBehaviour {

    public GameObject manager;
    public GameObject CommsTerminalDetail;

    private bool isEnabled = true;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            manager.SendMessage("canAccessComs");
        }
    }

    public void canAccessComs(bool possible)
    {
        if (possible)
        {
            CommsTerminalDetail.SetActive(true);
        }
        else
        {
            //place for dialog
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
