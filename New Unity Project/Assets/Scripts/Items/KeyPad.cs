using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour {

    public GameObject manager;
    public GameObject interactableKeyPad;
    public GameObject toolChest;
    public GameObject openDoor;

    private bool isEnabled = true;

	public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isEnabled)
        {
           GameObject padInstance = Instantiate(interactableKeyPad, 
               Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1)) - new Vector3(0,5,0), Quaternion.identity);
            padInstance.GetComponent<KeyPadDetail>().manager = manager;
            padInstance.GetComponent<KeyPadDetail>().keyPad = gameObject;

        }
    }

    public void success()
    {
        GameObject tools = Instantiate(toolChest);
        tools.GetComponent<Toolbox>().manager = manager;
        manager.SendMessage("addInteractible", tools);
        manager.SendMessage("removeInteractible", gameObject);
        Instantiate(openDoor);
        Destroy(gameObject);
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
