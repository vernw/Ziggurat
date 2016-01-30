using UnityEngine;
using System.Collections;

public class Torch : Interactable {
	public int torchValue = 1;
	public Material matColor_lit;
	public Material matColor_regular;
	private TorchSequence ts;

	private bool isLit;

	void Start() {
		ts = FindObjectOfType<TorchSequence> ();
	}

  public override void interact() {
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
