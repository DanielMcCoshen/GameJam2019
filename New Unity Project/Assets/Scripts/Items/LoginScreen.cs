using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginScreen : MonoBehaviour {

    public GameObject caller;
    public InputField input;
    public GameObject manager;


    void Start()
    {
        input.onEndEdit.AddListener(processString);
        manager.SendMessage("dimScreen");
    }
	
    void processString(string password)
    {
        if (password == "SamIsTheBest")
        {
            caller.SendMessage("success");
            manager.SendMessage("unDimScreen");
            Destroy(gameObject);
        }
        else
        {
            input.text = "";
        }
    }
    public void exit()
    {
        manager.SendMessage("unDimScreen");
        Destroy(gameObject);
    }
}
