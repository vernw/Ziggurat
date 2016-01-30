using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour, IInteractable {
  private bool isCurrentlyInteracting;
  public bool IsCurrentlyInteracting {
    get {
      return isCurrentlyInteracting;
    }
    set {
      isCurrentlyInteracting = value;
    }
  }

  public string interactKey = "r";
  public abstract void interact();
  public void onStartInteract() {}
  public void onStopInteract() {}

  void Awake() {
    IsCurrentlyInteracting = false;
  }

  void Update() {
    if (Input.GetKeyDown(interactKey)) {
      onStartInteract();
      IsCurrentlyInteracting = true;
      interact();
    } else {
      onStopInteract();
      IsCurrentlyInteracting = false;
    }
  }
}
