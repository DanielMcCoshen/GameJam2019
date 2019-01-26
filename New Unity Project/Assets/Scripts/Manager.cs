using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    //panel for dimming screen
    public GameObject screenDim;

    //interaction items
    [Header("Interactible objects")]
    public GameObject Drone;
    public GameObject Picture;
    public GameObject Keypad;
    public GameObject PowerPanelCover;
    public GameObject ControlTerminal;
    public GameObject GpsCover;
    public GameObject gpsCircutBoard;
    public GameObject triangulationSystem;

    private List<GameObject> allInteractibles= new List<GameObject>();

    //naviagtion arrows
    [Header("Naviagtion arrows")]
    public GameObject leftArrow; 
    public GameObject rightArrow;

    [Header("admin control buttons")]
    public GameObject EnableAiButton;
    public GameObject EnableScrubbersButton;
    public GameObject StartGpsButton;

    //condition variables
    private bool powerOn = false;
    private bool hasTools = false;
    private bool droneFixed = false;
    private bool isLoggedIn = false;
    private bool aiEnabled = false;
    private bool scrubbersEnabled = false;
    private bool gpsFixed = false;
    private bool hasReferenceData = false;
    private bool postionFound = false;

    public void Start()
    {
        allInteractibles.Add(Drone);
        allInteractibles.Add(Picture);
        allInteractibles.Add(Keypad);
        allInteractibles.Add(PowerPanelCover);
        allInteractibles.Add(ControlTerminal);
        allInteractibles.Add(GpsCover);
    }

    public void addInteractible(GameObject newInteractible)
    {
        allInteractibles.Add(newInteractible);
    }
    public void removeInteractible(GameObject interactible)
    {
        allInteractibles.Remove(interactible);
    }
    public void disableAllInteractibles()
    {
        foreach (GameObject i in allInteractibles)
        {
            i.SendMessage("disable");
        }
    }
    public void enableAllInteractibles()
    {
        foreach (GameObject i in allInteractibles)
        {
            i.SendMessage("enable");
        }
    }
    public void dimScreen()
    {
        screenDim.GetComponent<SpriteRenderer>().enabled = true;
        disableScreenMovement();
        disableAllInteractibles();
    }
    public void unDimScreen()
    {
        screenDim.GetComponent<SpriteRenderer>().enabled = false;
        enableScreenMovement();
        enableAllInteractibles();
    }
	public void disableScreenMovement()
    {
        leftArrow.SendMessage("disable");
        rightArrow.SendMessage("disable");
    }
    public void enableScreenMovement()
    {
        leftArrow.SendMessage("enable");
        rightArrow.SendMessage("enable");
    }
    public void aquireTools()
    {
        hasTools = true;
    }
    public void turnPowerOn()
    {
        powerOn = true;
        triangulationSystem.SendMessage("activate");
    }
    public void canRepairDrone()
    {
        Drone.SendMessage("canRepair", hasTools);
    }
    public void canRepairGps()
    {
        gpsCircutBoard.SendMessage("canRepair", hasTools);
    }
    public void droneRepaired()
    {
        droneFixed = true;
    }
    public void canLogIn()
    {
        if (!powerOn)
        {
            ControlTerminal.SendMessage("noPower");
        }
        else if (!isLoggedIn)
        {
            ControlTerminal.SendMessage("mustLogIn");
        }
        else
        {
            ControlTerminal.SendMessage("loggedIn");
        }
    }
    public void logIn()
    {
        isLoggedIn = true;
    }
    public void enableAi()
    {
        aiEnabled = true;
        EnableAiButton.SendMessage("success");
    }
    public void enableScrubbers()
    {
        scrubbersEnabled = true;
        EnableScrubbersButton.SendMessage("success");
    }
    public void gpsRepaired()
    {
        gpsFixed = true;
    }
    public void getGpsState()
    {
        if (!gpsFixed)
        {
            StartGpsButton.SendMessage("setGpsState", 0);
        }
        else if (!hasReferenceData)
        {
            StartGpsButton.SendMessage("setGpsState", 1);
        }
        else
        {
            StartGpsButton.SendMessage("setGpsState", 2);
        }
    }
    public void foundReferenceData()
    {
        hasReferenceData = true;
    }
    public void locationFound()
    {
        postionFound = true;
    }
}
