using UnityEngine;
using System.Collections;

public class Sequence : MonoBehaviour {

	public int sequence;
	public int lightTrigger;

	private GameObject interactionTrigger;

	void Awake() {
		interactionTrigger = GameObject.FindWithTag("InteractionTrigger");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject == interactionTrigger) {
			TorchSequence ts = FindObjectOfType<TorchSequence> ();
			Debug.Log (lightTrigger);
			Debug.Log (sequence);
			ts.UserSequence = sequence;
			ts.PuzzleLight = lightTrigger;
		}
	}
}
