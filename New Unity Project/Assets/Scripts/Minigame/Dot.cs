using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Dot : MonoBehaviour
{
    public SpriteRenderer Renderer;

    public bool IsSource;
    public bool IsTarget;

    public bool IsSelected;

    public Dot[] Neighbors;

    public MinigameInstance Minigame;
    public Coordinate Coordinate;

    void Start()
    {
        GetComponentRefs();
    }

    void Update()
    {
        Renderer.color = GetDotColor(IsSource, IsTarget, IsSelected);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            if (CanSelect && !(IsSource || IsSelected))
            {
                Minigame.DotMarked(this);
                IsSelected = true;
            }
        }
    }

    private bool CanSelect
    {
        get
        {
            foreach (var neighbor in Neighbors)
            {
                if (neighbor.IsSource || neighbor.IsSelected)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public static Color GetDotColor(bool source, bool target, bool selected)
    {
        if (source) { return Color.blue; }
        else if (target) { return Color.red; }
        else
        {
            if (selected) { return Color.white; }
            else { return Color.gray; }
        }
    }

    void Reset()
    {
        GetComponentRefs();
    }

    void GetComponentRefs()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }
}
