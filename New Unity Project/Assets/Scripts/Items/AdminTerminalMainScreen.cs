using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminTerminalMainScreen : MonoBehaviour {

    public GameObject manager;

    public GameObject scruberButton;
    //public GameObject aiButton;
    public GameObject droneButton;
    public GameObject gpsButton;
    public GameObject schematicsButton;
    public GameObject exitButton;
    public GameObject circutDiagrams;

    private bool inSchematicsMode = false;

    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        manager.SendMessage("dimScreen");
	}
	
    void OnEnable(){
        manager.SendMessage("dimScreen");
    }

    public void showSchematics()
    {
        inSchematicsMode = true;
        //aiButton.SetActive(false);
        droneButton.SetActive(false);
        gpsButton.SetActive(false);
        schematicsButton.SetActive(false);
        scruberButton.SetActive(false);
        circutDiagrams.SetActive(true);
    }
	public void exit()
    {
        if (inSchematicsMode)
        {
            inSchematicsMode = false;
            //aiButton.SetActive(true);
            droneButton.SetActive(true);
            gpsButton.SetActive(true);
            schematicsButton.SetActive(true);
            scruberButton.SetActive(true);
            circutDiagrams.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            manager.SendMessage("unDimScreen");
        }
    }
}
