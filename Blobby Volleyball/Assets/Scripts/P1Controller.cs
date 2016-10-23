using UnityEngine;
using System.Collections;

public class P1Controller : MonoBehaviour {

	private Rigidbody rb;
	private Rigidbody rbBall;
	public float speed;


	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
	}

	Vector3 movement;

	void FixedUpdate () {
		
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		movement.x = horizontalMovement * Time.deltaTime * speed;
		movement.z = verticalMovement * Time.deltaTime * speed;
		movement.y = 0f;

		if (Input.GetKeyDown (KeyCode.Space)) {
			
			movement.y = 0.5f;
		}

		transform.position += movement;
	}

	void OnTriggerStay(Collider other) {
			
			float verticalMovement = Input.GetAxis ("Vertical");

			movement.z = verticalMovement;

			rbBall = other.GetComponentInParent<Rigidbody> ();
			rbBall.AddForce (new Vector3 (4f, 2f, movement.z/10f), ForceMode.Impulse);
	}
}
