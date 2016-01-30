using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TorchSequence : MonoBehaviour {

	public List<int> torches;

	public int[,] sequences = new int[,] {{1,2,3,4}, {2,3,1,4}};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (torches.Capacity > 4) {
			//check sequence
			for (int i = 0; i < torches.Capacity; i++) {
				if (torches [i] == sequences[0,i]) {
					
					Debug.Log ("Door Opened");
				}
			}

		}
	}

	public void addTorch(int torchValue) {
		torches.Add (torchValue);
	}

	public void removeTorch(int torchValue) {
		torches.Remove (torchValue);
	}
}
