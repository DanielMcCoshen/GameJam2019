using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsWiringCover : MonoBehaviour {

    public GameObject manager;
    public GameObject circutBoard;
    private bool isEnabled = true;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            GameObject BoardInstance = Instantiate(circutBoard);
            BoardInstance.GetComponent<GpsCircutBoard>().manager = manager;
            manager.SendMessage("addInteractible", BoardInstance);
            manager.SendMessage("removeInteractible", gameObject);
            manager.GetComponent<Manager>().gpsCircutBoard = BoardInstance;
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
