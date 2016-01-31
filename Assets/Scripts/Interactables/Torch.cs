using UnityEngine;
using System.Collections;

public class Torch : Interactable {
	public int torchValue = 1;
	public Material matColor_lit;
	public Material matColor_regular;
	private TorchSequence ts;

	private bool isLit;
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
	}

  public override void onStartInteract() {
    if (isLit) {
      deactivate();
      ts.removeTorch (this);
    } else {
      activate();
      ts.addTorch (this);
    }

    isLit = !isLit;
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
