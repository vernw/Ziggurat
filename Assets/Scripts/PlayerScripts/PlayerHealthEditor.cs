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
    if(GUILayout.Button("10 Damage")) {
      playerHealth.takeDamage(10.0f);
    }
  }
}
