using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPanelCover : MonoBehaviour {

    public GameObject manager;
    public GameObject breaker;
    private bool isEnabled = true;
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            GameObject breakerInstance = Instantiate(breaker);
            breakerInstance.GetComponent<Breaker>().manager = manager;
            manager.SendMessage("addInteractible", breakerInstance);
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
