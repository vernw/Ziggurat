using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	private int torchValue = 1;
	public Material matColor_lit;
	public Material matColor_regular;
	private TorchSequence ts;

	private bool isLit;
	public bool colliding;

	public bool Light {
		get {
			return isLit;
		}
		set {
			isLit = value;
		}
	}

	void Start() {
		ts = FindObjectOfType<TorchSequence> ();
		colliding = false;
	}

	void Update() {
		if (colliding) {
			if (Input.GetKeyDown ("r")) {
				if (isLit) {
					isLit = false;
					this.GetComponent<Renderer> ().material = matColor_regular;
					ts.removeTorch (torchValue);
				} else {
					isLit = true;
					this.GetComponent<Renderer> ().material = matColor_lit;
					ts.addTorch (torchValue);
				}
			}
		}

	}

	void OnTriggerEnter(Collider col) {
		colliding = true;
		Debug.Log ("colliding");
	}

	void OnTriggerExit(Collider col) {
		colliding = false;
		Debug.Log ("not colliding");
	}

}
