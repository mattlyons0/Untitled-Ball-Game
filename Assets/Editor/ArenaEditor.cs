using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BallGame.Procedural;

[CustomEditor(typeof(Arena))]
public class ArenaEditor : Editor {
  public override void OnInspectorGUI() {
    DrawDefaultInspector();
    Arena myScript = (Arena)target;

    if(GUILayout.Button("Generate")) {
        myScript.Generate();
    }
    if(GUILayout.Button("Clear")) {
        myScript.Clear();
    }
  }
}