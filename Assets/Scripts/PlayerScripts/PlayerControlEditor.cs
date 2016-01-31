using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PlayerControl))]
public class PlayerControlEditor : Editor {
  public override void OnInspectorGUI() {
    DrawDefaultInspector();

    PlayerControl playerControl = (PlayerControl) target;
    if(GUILayout.Button("Kill")) {
      playerControl.takeDamage(100.0f);
    }
  }
}
