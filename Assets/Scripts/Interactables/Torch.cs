using UnityEngine;
using System.Collections;

public class Torch : Interactable {
	public int torchValue;
	public Material matColor_lit;
	public Material matColor_regular;
	private TorchSequence ts;
	GameObject child;

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
		child = this.gameObject.transform.FindChild ("FireMobile").gameObject;
	}

  public override void onStartInteract() {
    if (Light) {
      deactivate();
      ts.removeTorch (this);
    } else {
      activate();
      ts.addTorch (this);
    }
  }

  public void activate() {
    Light = true;
	child.SetActive (true);
	child.GetComponent<ParticleSystem> ().Play ();
  }

  public void deactivate() {
    Light = false;
	child.SetActive (false);
  }
}
