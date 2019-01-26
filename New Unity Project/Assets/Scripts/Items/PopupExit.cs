using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupExit : MonoBehaviour {

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.parent.gameObject.SendMessage("exit");
        }
    }
}
