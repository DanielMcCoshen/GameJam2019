using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsControlButton : MonoBehaviour {

    public GameObject manager;
    public GameObject referenceSystem;
    

    private int gpsState;
	// Update is called once per frame
	void FixedUpdate () {
        manager.SendMessage("getGpsState");
	}

    public void setGpsState(int state)
    {
        gpsState = state;

        //set proper sprite
        switch (state)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gpsState == 0)
            { //still broken. maybe a voice line?

            }
            else if (gpsState == 1) //missing reference data
            {
                referenceSystem.SendMessage("record");
            }
            else if (gpsState == 2)
            { // ready to get data
                manager.SendMessage("locationFound");
            }
        }
    }
}
