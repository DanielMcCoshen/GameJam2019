using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsCircutBoard : MonoBehaviour
{
    public GameObject manager;
    public GameObject circutBoard;
    public GameObject fixedCover;

    private bool isRepaired = false;
    private bool isEnabled = true;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            if (!isRepaired)
            {
                manager.SendMessage("canRepairGps");
            }
            else
            {
                Debug.Log("shouldn't get here");
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
            Debug.Log(gameObject);
            circutInstance.GetComponent<MinigameInstance>().Caller = gameObject;
        }
        else
        {
            Debug.Log(gameObject.name);
            Debug.Log("This can not be fixed without tools");
        }
    }

    public void success()
    {
        Debug.Log("got hre");
        isRepaired = true;
        manager.SendMessage("gpsRepaired");
        Instantiate(fixedCover);
        manager.SendMessage("removeInteractible", gameObject);
        Destroy(gameObject);

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
