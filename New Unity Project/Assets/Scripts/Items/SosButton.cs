using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SosButton : MonoBehaviour
{
    public GameObject manager;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.SendMessage("sendSos");
        }
    }

    public void failure()
    {
        gameObject.GetComponent<TextMesh>().text = "Send SOS Signal\nError: Sos broadcasting\nnot available";
    }
}
