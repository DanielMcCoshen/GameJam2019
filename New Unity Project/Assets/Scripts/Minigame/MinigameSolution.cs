using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu]
public class MinigameSolution : ScriptableObject
{
    public Coordinate[] Coordinates;

    public bool IsValid { get { return Coordinates != null && Coordinates.Length >= 2; } }
}

#if UNITY_EDITOR

[CustomEditor(typeof(MinigameSolution))]
public class MinigameSolutionEditor : Editor
{

    public override void OnInspectorGUI()
    {
        var solution = target as MinigameSolution;
        serializedObject.UpdateIfRequiredOrScript();

        // 
        if (solution.Coordinates == null || solution.Coordinates.Length < 2)
            solution.Coordinates = new Coordinate[2];

        // Resize solution
        var size = EditorGUILayout.DelayedIntField("Solution Size: ", solution.Coordinates.Length);
        if (size < 2) size = 2;
        if (size != solution.Coordinates.Length)
            Array.Resize(ref solution.Coordinates, size);

        // 
        var coords = solution.Coordinates;
        for (var i = 0; i < solution.Coordinates.Length; i++)
        {
            var vec = new Vector2(coords[i].X, coords[i].Y);
            vec = EditorGUILayout.Vector2Field(String.Format("Point {0}", i), vec);
            coords[i] = new Coordinate((int)vec.x, (int)vec.y);
        }

        // 
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);
    }
}

#endif