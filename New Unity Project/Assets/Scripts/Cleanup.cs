using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour {

    public GameObject startprefab;
    public Sprite startstate;

	void OnApplicationQuit()
    {
        startprefab.GetComponent<SpriteRenderer>().sprite = startstate;
    }
}
