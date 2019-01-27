using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScrubbersButton : MonoBehaviour {
    public GameObject manager;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.SendMessage("enableScrubbers");
        }
    }

    public void success()
    {
        gameObject.GetComponent<TextMesh>().text = "Co2 Scrubber Control: \n Scrubbers [enabled]";
    }

}
