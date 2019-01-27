using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsControlButton : MonoBehaviour {

    public GameObject manager;
    public GameObject referenceSystem;

    private bool clicked = false;
    private bool clicked2 = false;
    private int gpsState;
	// Update is called once per frame
	void FixedUpdate () {
        manager.SendMessage("getGpsState");
	}

    public void setGpsState(int state)
    {
        gpsState = state;

        //set proper text
        switch (state)
        {
            case 0:
                gameObject.GetComponent<TextMesh>().text = "Interstellar Positioning System:\n/!\\ Hardware Failure Detected.";
                break;
            case 1:
                if (!clicked) { 
                    gameObject.GetComponent<TextMesh>().text = "Interstellar Positioning System:\nMissing Reference Data. \n Please click here and then proceed to the pod directional controls " +
                        "\nby the window to re-aquire three reference star.s";
                } 
                break;
            case 2:
                if (!clicked2)
                {
                    gameObject.GetComponent<TextMesh>().text = "Interstellar Positioning System: \n Online. Click to calculate location.";
                }
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
                clicked = true;
                gameObject.GetComponent<TextMesh>().text = "Interstellar Positioning System: \n Awaiting Reference Data.";
            }
            else if (gpsState == 2)
            { // ready to get data
                gameObject.GetComponent<TextMesh>().text = "Interstellar Positioning System: \n Pod Location Triangulated.";
                clicked2 = true;
                manager.SendMessage("locationFound");
            }
        }
    }
}
