using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TorchSequence : MonoBehaviour {

	public List<Torch> torches;

	private int[] sequence1 = new int[] {1};
	private int[] sequence2 = new int[] {1,2};
	private int[] sequence3 = new int[] {1,2,3};
	private int[] sequence4 = new int[] {1,2,3,4};

	public Light[] lights = new Light[10];

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

	private int puzzleLight;

	public int PuzzleLight {
		get {
			return puzzleLight;
		}
		set {
			puzzleLight = value;
		}
	}

	void Update () {
		//retrieve sequence
		if (torches.Count > userSequence) {
			Debug.Log (userSequence);
			selectedSequence = determineSequence (userSequence);
			int match = 1;
			//check sequence
			for (int i = 0; i < torches.Count; i++) {
				Debug.Log ("CHECKING: " + torches [i].torchValue + "|" + selectedSequence[i]);
				if (torches [i].torchValue != selectedSequence[i]) {
					match = 0;
					continue;
				}
			}
			if (match == 1) {
				Debug.Log ("LIGHTS ON " + puzzleLight);
				lights [puzzleLight].GetComponent<LightController> ().activate();
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
		Debug.Log ("Removing torch:" + torch.torchValue);
	}

	IEnumerator resetTorches() {
		yield return new WaitForSeconds (2f);
		for (int i = 0; i < torches.Count; i++) {
			torches [i].deactivate ();
			removeTorch (torches [i]);
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
			Debug.Log("hit sequence 4");
			return sequence4;
		}
	}
}
