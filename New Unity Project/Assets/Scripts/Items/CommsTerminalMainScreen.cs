using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsTerminalMainScreen : MonoBehaviour {

    public GameObject manager;

    void Start()
    {
        manager.SendMessage("dimScreen");
    }
    void OnEnable()
    {
        manager.SendMessage("dimScreen");
    }
    private void exit() {
        manager.SendMessage("unDimScreen");
        gameObject.SetActive(false);
    }
}
