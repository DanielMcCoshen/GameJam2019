using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrow : MonoBehaviour {

    public GameObject cameraController;

    public Sprite focusedSprite;
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    private SpriteRenderer sr;
    private bool isEnabled = true;
    private Sprite currentSprite;

    public void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        enable();
    }

    public void OnMouseOver()
    {
        if (isEnabled)
        {
            sr.sprite = focusedSprite;
        }

        if (Input.GetMouseButtonDown(0) && enabled)
        {
            cameraController.SendMessage("moveRight");
        }
    }

    public void OnMouseExit()
    {
        sr.sprite = currentSprite;
    }

    public void enable()
    {
        sr.sprite = enabledSprite;
        currentSprite = enabledSprite;
        isEnabled = true;
    }

    public void disable()
    {
        sr.sprite = disabledSprite;
        currentSprite = disabledSprite;
        isEnabled = false;
    }
}

