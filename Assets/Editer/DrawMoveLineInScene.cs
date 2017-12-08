#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(enemy1ToDie))]
public class DrawMoveLineInScene : Editor {

    void OnSceneGUI()
    {
        enemy1ToDie e = target as enemy1ToDie;
        Vector3 p = e.transform.position;
        Handles.DrawLine(p - new Vector3(e.moveL, 0, 0), p + new Vector3(e.moveR, 0, 0));
    }
}

#endif