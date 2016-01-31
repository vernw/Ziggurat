using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {

	void Start () {
        Invoke("Destruct", 0.05f);
	}

    void Destruct () {
        Destroy(gameObject);
	}
}
