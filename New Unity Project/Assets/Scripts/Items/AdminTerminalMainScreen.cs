using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminTerminalMainScreen : MonoBehaviour {

    public GameObject manager;

    public GameObject scruberButton;
    public GameObject aiButton;
    public GameObject droneButton;
    public GameObject gpsButton;
    public GameObject schematicsButton;
    public GameObject exitButton;

    private bool inSchematicsMode = false;
    public Sprite mainSprite;
    public Sprite schematicsSprite;

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
        sr.sprite = schematicsSprite;
        aiButton.SetActive(false);
        droneButton.SetActive(false);
        gpsButton.SetActive(false);
        schematicsButton.SetActive(false);
        scruberButton.SetActive(false);
    }
	public void exit()
    {
        if (inSchematicsMode)
        {
            inSchematicsMode = false;
            sr.sprite = mainSprite;
            aiButton.SetActive(true);
            droneButton.SetActive(true);
            gpsButton.SetActive(true);
            schematicsButton.SetActive(true);
            scruberButton.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            manager.SendMessage("unDimScreen");
        }
    }
}
