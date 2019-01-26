using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminTerminal : MonoBehaviour {

    public GameObject manager;
    public GameObject loginScreen;
    public GameObject mainScreen;

    private bool isEnabled = true;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
            manager.SendMessage("canLogIn");
        }
    }

    public void noPower()
    {
        Debug.Log("Power must be on to turn on computer");
    }

    public void mustLogIn()
    {
        GameObject loginInstance = Instantiate(loginScreen,
              Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1)), Quaternion.identity);
        //change this type when the login prompt gets made
        loginInstance.GetComponent<KeyPadDetail>().manager = manager;
        loginInstance.GetComponent<KeyPadDetail>().keyPad = gameObject;
    }

    public void loggedIn()
    {
        mainScreen.SetActive(true);
    }
    public void success()
    {
        manager.SendMessage("logIn");
        loggedIn();
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
