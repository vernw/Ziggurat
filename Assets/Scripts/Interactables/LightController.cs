using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public void activate() {
		this.gameObject.SetActive (true);
	}

	public void deactivate() {
		this.gameObject.SetActive (false);
	}
}
