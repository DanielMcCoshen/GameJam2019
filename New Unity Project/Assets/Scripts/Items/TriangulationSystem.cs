using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangulationSystem : MonoBehaviour {

    private const float DELTA = 2;

    public GameObject stars;
    public GameObject manager;

    private bool recording = false;

    private Vector2 target1 = new Vector2(-70, 15);
    private Vector2 target2 = new Vector2(-70, 0);
    private Vector2 target3 = new Vector2(-70, -15);

    private bool found1 = false;
    private bool found2 = false;
    private bool found3 = false;

    public List<GameObject> directions = new List<GameObject>();

    void Update()
    {
        if (recording)
        {
            if (Mathf.Abs(stars.transform.position.x - target1.x) < DELTA  && 
                Mathf.Abs(stars.transform.position.y - target1.y) < DELTA){
                found1 = true;
            }
            if (Mathf.Abs(stars.transform.position.x - target2.x) < DELTA &&
               Mathf.Abs(stars.transform.position.y - target2.y) < DELTA)
            {
                found2 = true;
            }
            if (Mathf.Abs(stars.transform.position.x - target3.x) < DELTA &&
               Mathf.Abs(stars.transform.position.y - target3.y) < DELTA)
            {
                found3 = true;
            }
            if (found1 && found2 && found3)
            {
                recording = false;
                manager.SendMessage("foundReferenceData");
            }
        }
    }

    //for a timed lock later
    private IEnumerator waitForLock()
    {
        yield return 0;
    }

	private void record()
    {
        recording = true;
    }

    private void activate()
    {
        foreach (GameObject d in directions)
        {
            d.SendMessage("activate");
        }
    }
}
