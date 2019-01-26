using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour {
    public GameObject manager;

    public GameObject note;

    private bool isEnabled = true;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            GameObject noteInstance = Instantiate(note,
                Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1)), Quaternion.identity);
            noteInstance.GetComponent<StickyNote>().manager = manager;
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
