using UnityEngine;
using System.Collections;

public class Sequence : MonoBehaviour {

	public int sequence;

	private GameObject interactionTrigger;

	void Awake() {
		interactionTrigger = GameObject.FindWithTag("InteractionTrigger");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject == interactionTrigger) {
			TorchSequence ts = FindObjectOfType<TorchSequence> ();
			ts.SelectedSequence = sequence;
		}
	}
}
