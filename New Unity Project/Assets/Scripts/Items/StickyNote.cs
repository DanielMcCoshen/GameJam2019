using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNote : MonoBehaviour {
    public GameObject manager;
	// Use this for initialization
	void Start () {
        manager.SendMessage("dimScreen");
    }
	
	public void exit()
    {
        manager.SendMessage("unDimScreen");
        Destroy(gameObject);
    }
}
