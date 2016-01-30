using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour, IInteractable {
  private GameObject interactionTrigger;
  private bool colliding;
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
  public virtual void onDuringinteract() {}
  public virtual void onStartInteract() {}
  public virtual void onStopInteract() {}

  void Awake() {
    IsCurrentlyInteracting = false;
    colliding = false;
    interactionTrigger = GameObject.FindWithTag("InteractionTrigger");
  }

  void Update() {
    if (colliding) {
      if (Input.GetKeyDown(interactKey)) {
        onStartInteract();
        IsCurrentlyInteracting = true;
      } else if (Input.GetKeyUp(interactKey)) {
        onStopInteract();
        IsCurrentlyInteracting = false;
      } else if (Input.GetKey(interactKey)) {
        onDuringinteract();
      }
    }
  }

  void OnTriggerEnter(Collider col) {
    if (col.gameObject == interactionTrigger)
      colliding = true;
  }

  void OnTriggerExit(Collider col) {
    if (col.gameObject == interactionTrigger)
      colliding = false;
  }
}
