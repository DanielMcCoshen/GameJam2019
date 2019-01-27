using UnityEngine;

public class MinigameInstance : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject Caller;

    void Start()
    {
        GameManager.SendMessage("dimScreen");
        Invoke("EndMinigame", 5);
    }

    void Update()
    {

    }

    void EndMinigame(bool success)
    {
        GameManager.SendMessage("unDimScreen");
        if (success) { Caller.SendMessage("success"); }
        Destroy(gameObject);
    }

    void exit()
    {
        EndMinigame(false);
    }
}
