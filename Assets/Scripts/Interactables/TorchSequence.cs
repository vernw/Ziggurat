using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TorchSequence : MonoBehaviour {

	public List<Torch> torches;

	public int[] sequence1 = new int[] {1};
	public int[] sequence2 = new int[] {1,2};
	public int[] sequence3 = new int[] {1,2,3};
	public int[] sequence4 = new int[] {1,2,3,4};

	private int userSequence;

	public int UserSequence {
		get {
			return userSequence;
		}
		set {
			userSequence = value;
		}
	}

	private int[] selectedSequence;

	public int[] SelectedSequence {
		get {
			return selectedSequence;
		}
		set {
			selectedSequence = value;
		}
	}

	void Update () {
		//retrieve sequence
		if (torches.Count > userSequence) {
			Debug.Log (userSequence);
			selectedSequence = determineSequence (userSequence);
			int match = 1;
			//Debug.Log (torches.Count);
			//check sequence
			for (int i = 0; i < torches.Count; i++) {
				Debug.Log ("CHECKING: " + torches [i].torchValue + "|" + selectedSequence[i]);// [selectedSequence,i]);
				if (torches [i].torchValue != selectedSequence[i]) {//	 [selectedSequence, i]) {
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

	public int[] determineSequence(int sequence) {
		if (sequence == 0) {
			return sequence1;
		} else if (sequence == 1) {
			return sequence2;
		} else if (sequence == 2) {
			return sequence3;
		} else {
			return sequence4;
		}
	}
}
