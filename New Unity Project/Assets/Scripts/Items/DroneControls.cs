using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControls : MonoBehaviour
{

    public GameObject manager;

    private int droneStatus;
    // Update is called once per frame
    void Update()
    {
        manager.SendMessage("requestDroneStatus");
    }
    public void setDroneStatus(int status)
    {
        droneStatus = status;

        //set sprites here
        switch (status)
        {
            case 0: break;
            case 1: break;
            case 2: break;
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (droneStatus == 0)
            {
                //still broken. space for voice lines
            }
            else if (droneStatus == 1)
            {
                manager.SendMessage("sendDrone");
            }
            else if (droneStatus == 2)
            {
                //drone is away, space for voice lines
            }
        }
    }
}
