using UnityEngine;
using System.Collections;

public interface IInteractable {
  bool IsCurrentlyInteracting { get; set; }
  void onDuringinteract();
  void onStartInteract();
  void onStopInteract();
}
