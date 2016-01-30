using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TorchSequence : MonoBehaviour {

	public List<Torch> torches;

	public int[,] sequences = new int[,] {{1,2,3,4}, {2,3,1,4}};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (torches.Count > 3) {
			int match = 1;
			Debug.Log (torches.Count);
			//check sequence
			for (int i = 0; i < torches.Count; i++) {
				if (torches [i].torchValue != sequences[0,i]) {
					match = 0;
					Debug.Log ("No match: " + torches [i].torchValue + "|" + sequences[0,i]);
					continue;

				}
			}
			if (match == 1) {
				Debug.Log ("LIGHTS ON");
			}
			StartCoroutine (resetTorches());

		}
	}

	public void addTorch(Torch torch) {
		torches.Add (torch);
	}

	public void removeTorch(Torch torch) {
		torches.Remove (torch);
	}

	IEnumerator resetTorches() {
		yield return new WaitForSeconds (.9f);
		for (int i = 0; i < torches.Count; i++) {
			torches [i].deactivate ();
			torches.Remove (torches [i]);
		}
	}
}
