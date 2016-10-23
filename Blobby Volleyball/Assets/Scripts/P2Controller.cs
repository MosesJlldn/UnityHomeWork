using UnityEngine;
using System.Collections;

public class P2Controller : MonoBehaviour {

	private Rigidbody rb;
	private Rigidbody rbBall;
	public float speed;
	public GameObject ball;
	private bool contact = true;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (transform.position, ball.transform.position);

		if (contact && (dist > 3f)) {
			
			transform.position = Vector3.MoveTowards (transform.position, ball.transform.position, speed * Time.deltaTime);
		}

	}

	void OnTriggerStay(Collider other) {

			
		rbBall = other.GetComponentInParent<Rigidbody> ();

		if (rbBall != null) {
			
			rbBall.AddForce (new Vector3 (-2f, 1.5f, 0f), ForceMode.Impulse);	
		}
	}

	void OnTriggerEnter(Collider other) {
		
		contact = true;
	}

	void OnTriggerExit(Collider other) {
		
		contact = false;
	}
}
