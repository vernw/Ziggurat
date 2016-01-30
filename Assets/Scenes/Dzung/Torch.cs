using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	public int torchValue = 1;
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
					deactivate ();
					ts.removeTorch (this);
				} else {
					activate ();
					ts.addTorch (this);
				}
			}
		}

	}

	void OnTriggerEnter(Collider col) {
		colliding = true;
	}

	void OnTriggerExit(Collider col) {
		colliding = false;
	}

	public void activate() {
		isLit = true;
		this.GetComponent<Renderer> ().material = matColor_lit;
	}

	public void deactivate() {
		isLit = false;
		this.GetComponent<Renderer> ().material = matColor_regular;
	}

}
