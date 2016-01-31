using UnityEngine;
using System.Collections;

public class Ladder : Interactable {
  public Transform spawnPoint;

  public override void onStartInteract() {
    PlayerInteracting.transform.position = spawnPoint.position;
  }
}
