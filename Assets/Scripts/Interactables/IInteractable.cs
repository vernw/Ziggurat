using UnityEngine;
using System.Collections;

public interface IInteractable {
  bool IsCurrentlyInteracting { get; set; }
  void interact();
  void onStartInteract();
  void onStopInteract();
}
