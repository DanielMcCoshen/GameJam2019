using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadDetail : MonoBehaviour {

    public GameObject keyPad;
    public GameObject manager;
    public GameObject text;
    private string attempt = "";

	// Use this for initialization
	void Start () {
        manager.SendMessage("dimScreen");
	}
    
    void keyTyped(char key)
    {
        attempt += key;
        if (attempt == "8372")
        {
            Debug.Log(keyPad);
            keyPad.SendMessage("success");
            manager.SendMessage("unDimScreen");
            Destroy(gameObject);
        }
        if (attempt.Length == 4)
        {
            attempt = "";
        }
        text.GetComponent<TextMesh>().text = attempt;
    }
	
    public void exit()
    {
        manager.SendMessage("unDimScreen");
        Destroy(gameObject);
    }
}
