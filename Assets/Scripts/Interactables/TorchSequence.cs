using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TorchSequence : MonoBehaviour {

	public List<Torch> torches;

	public int[,] sequence = new int[,] {{1}, {1,2}, {1,2,3},{ 1, 2, 3, 4 }};
	public int[] sequence2 = new int[] { 1, 2, 3, 4 };

	private int selectedSequence;

	public int SelectedSequence {
		get {
			return selectedSequence;
		}
		set {
			selectedSequence = value;
		}
	}

	void Update () {
		//retrieve sequence
		if (torches.Count > 3) {
			Debug.Log ("SELECTED SEQUENCE: " + selectedSequence);
			Debug.Log ("TORCH COUNT: " + torches.Count);
			int match = 1;
			//Debug.Log (torches.Count);
			//check sequence
			for (int i = 0; i < torches.Count; i++) {
				Debug.Log ("CHECKING: " + torches [i].torchValue + "|" + sequence2[i]);// [selectedSequence,i]);
				if (torches [i].torchValue != sequence2[i]) {//	 [selectedSequence, i]) {
					match = 0;
					continue;
				}
			}
			if (match == 1) {
				Debug.Log ("LIGHTS ON");
			}
			StartCoroutine (resetTorches ());
		}
	}

	public void addTorch(Torch torch) {
		torches.Add (torch);
		Debug.Log ("Adding torch:" + torch.torchValue);
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
