using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {
    public GameObject manager;
    public GameObject circutBoard;

    private bool isRepaired = false;
    private bool isEnabled = true;

    public GameObject voice;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            if (!isRepaired)
            {
                manager.SendMessage("canRepairDrone");
            }
            else
            {
                Debug.Log("this has already been fixed");
            }
        }
    }

    public void canRepair(bool possible)
    {
        if (possible)
        {
            GameObject circutInstance = Instantiate(circutBoard,
               Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1)), Quaternion.identity);
            //CHANGE THIS WHEN MINIAME IS MADE
            circutInstance.GetComponent<MinigameInstance>().GameManager = manager;
            circutInstance.GetComponent<MinigameInstance>().Caller = gameObject;
        }
        else
        {
            manager.SendMessage("noToolsSequence");
        }
    }

    public void success()
    {
        isRepaired = true;
        manager.SendMessage("droneRepaired");
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
