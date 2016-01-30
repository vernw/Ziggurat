using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class CharacterMovement : MonoBehaviour {
	private Animator anim;
	private Rigidbody rigidBody;
	public float tilt = 1.0f;
	public float moveSpeed = 2.0f;
	public float mouseSpeed = 2.0f;
	public Boundary boundary;

	void Awake() {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}


	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float mouseX = Input.GetAxis ("Mouse X") * mouseSpeed;
		float mouseY = Input.GetAxis ("Mouse Y") * mouseSpeed;


		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidBody.velocity = movement * moveSpeed;

		rigidBody.position = new Vector3 
			(
				Mathf.Clamp (rigidBody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidBody.position.z, boundary.zMin, boundary.zMax)
			);

		rigidBody.rotation = Quaternion.Euler (0.0f, rigidBody.velocity.x * mouseX * mouseSpeed, rigidBody.velocity.x * -tilt);

	}
	
	// Update is called once per frame
	void Update () {

	}
}
