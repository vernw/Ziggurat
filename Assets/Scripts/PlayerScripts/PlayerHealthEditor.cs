using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PlayerHealth))]
public class PlayerHealthEditor : Editor {
  public override void OnInspectorGUI() {
    DrawDefaultInspector();

    PlayerHealth playerHealth = (PlayerHealth) target;
    if(GUILayout.Button("Kill")) {
      playerHealth.takeDamage(100.0f);
    }
  }
}
