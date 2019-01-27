using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class MinigameInstance : MonoBehaviour
{
    [Header("Game References")]
    public GameObject GameManager;
    public GameObject Caller;

    [Header("Minigame Configuration")]
    public MinigameSolution Solution;
    public LineRenderer Wire;

    public bool HasSolution { get { return Solution != null && Solution.IsValid; } }

    [Header("Prefabs")]
    public GameObject DotPrefab;

    private Dot[,] _dots;
    private List<Dot> _chain;

    void Start()
    {
        StartMinigame();

        _chain = new List<Dot>();
        _dots = new Dot[5, 5];

        // Create dot grid
        for (var y = 0; y < 5; y++)
        {
            for (var x = 0; x < 5; x++)
            {
                var p = GetPosition(x, y);

                // Create dot instance
                var dotGo = Instantiate(DotPrefab, transform, false);
                dotGo.transform.localPosition = new Vector3(p.x, p.y, 0);
                dotGo.name = String.Format("dot {0}, {1}", x, y);

                // Configure dot
                var dot = dotGo.GetComponent<Dot>();
                dot.Coordinate = new Coordinate(x, y);
                dot.Minigame = this;

                // 
                _dots[x, y] = dot;
            }
        }

        // Connect dot grid
        for (var y = 0; y < 5; y++)
        {
            for (var x = 0; x < 5; x++)
            {
                var dot = GetDot(x, y);
                dot.Neighbors = GetNeighborDots(x, y).ToArray();
            }
        }

        // Augment dots to have solution information
        if (HasSolution)
        {
            // 
            for (var i = 0; i < Solution.Coordinates.Length; i++)
            {
                var dot = GetDot(Solution.Coordinates[i]);
                dot.IsSource = i == 0;
                dot.IsTarget = i == Solution.Coordinates.Length - 1;
                dot.IsSelected = false;
            }
        }

        // Automatically contains the source
        _chain.Add(GetDot(Solution.Coordinates[0]));
        UpdateWire();
    }

    public void DotMarked(Dot dot)
    {
        _chain.Add(dot);
        UpdateWire();
         
        // Target clicked, check solution
        if (dot.IsTarget)
        {
            // TODO: Validate Path
            var success = CheckPathIsCorrect();
            EndMinigame(success);
        }
    }

    private bool CheckPathIsCorrect()
    {
        for (var i = 0; i < _chain.Count; i++)
        {
            var co1 = Solution.Coordinates[i];
            var co2 = _chain[i].Coordinate;
            if (co1 != co2) { return false; }
        }

        return true;
    }

    private void UpdateWire()
    {
        Wire.positionCount = _chain.Count;
        for (var i = 0; i < _chain.Count; i++)
        {
            var dot = _chain[i];
            Wire.SetPosition(i, dot.transform.position);
        }
    }

    public Vector2 GetPosition(int x, int y)
    {
        var xx = ((x / 4F) * 2 - 1) * 12;
        var yy = ((y / 4F) * 2 - 1) * 12;

        return new Vector2(xx, yy);
    }

    public Vector2 GetPosition(Coordinate coord)
    {
        return GetPosition(coord.X, coord.Y);
    }

    public bool IsValidDotCoord(int x, int y)
    {
        if (x < 0 || x >= 5) { return false; }
        if (y < 0 || y >= 5) { return false; }
        return true;
    }

    public Dot GetDot(int x, int y)
    {
        if (!IsValidDotCoord(x, y))
        {
            Debug.LogErrorFormat("Invalid dot coordinate {0} {1}", x, y);
        }
        return _dots[x, y];
    }

    public Dot GetDot(Coordinate coord)
    {
        return GetDot(coord.X, coord.Y);
    }

    public IEnumerable<Dot> GetNeighborDots(int x, int y)
    {
        for (var offsetY = -1; offsetY <= 1; offsetY++)
        {
            for (var offsetX = -1; offsetX <= 1; offsetX++)
            {
                // Skip center
                if (offsetX == 0 && offsetY == 0) { continue; }
                // If coordinate is valid, return dot
                else if (IsValidDotCoord(x + offsetX, y + offsetY))
                {
                    yield return GetDot(x + offsetX, y + offsetY);
                }
            }
        }
    }

    void Update()
    {

    }

    void StartMinigame()
    {
        if (GameManager != null) { GameManager.SendMessage("dimScreen"); }
    }

    void EndMinigame(bool success)
    {
        if (GameManager != null) { GameManager.SendMessage("unDimScreen"); }
        else { Debug.LogWarningFormat("MINIGAME ENDED (success: {0})", success); }
        if (success && Caller != null) { Caller.SendMessage("success"); }
        Destroy(gameObject);
    }

    void exit()
    {
        EndMinigame(false);
    }

    void OnDrawGizmos()
    {
        // 
        for (var y = 0; y < 5; y++)
        {
            for (var x = 0; x < 5; x++)
            {
                var color = Color.black;

                // Has a solution set
                if (HasSolution)
                {
                    var idx = Array.FindIndex(Solution.Coordinates, q => q.X == x && q.Y == y);
                    if (idx >= 0)
                    {
                        if (idx == 0) { color = Color.blue; }
                        else if (idx == Solution.Coordinates.Length - 1) { color = Color.red; }
                        else { color = Color.white; }
                    }
                }

                Gizmos.color = color;
                Gizmos.DrawWireSphere(GetPosition(x, y), 1);
            }
        }

        // 
        if (HasSolution)
        {
            for (var i = 1; i < Solution.Coordinates.Length; i++)
            {
                var source = GetPosition(Solution.Coordinates[i - 1]);
                var target = GetPosition(Solution.Coordinates[i - 0]);

                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(source, target);
            }
        }
    }
}
