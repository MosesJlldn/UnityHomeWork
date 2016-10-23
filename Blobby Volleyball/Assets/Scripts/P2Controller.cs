using UnityEngine;
using System.Collections;

public class P2Controller : MonoBehaviour {

	private Rigidbody rb;
	private Rigidbody rbBall;
	public float speed;
	public Transform target;
	private bool contact = true;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (contact && Vector3.Distance(transform.position, target.position) > 0.5f) {
			
			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}

	}

	void OnTriggerStay(Collider other) {

			
			rbBall = other.GetComponentInParent<Rigidbody> ();
			rbBall.AddForce (new Vector3 (-4f, 2f, 0f), ForceMode.Impulse);
	}

	void OnTriggerEnter(Collider other) {
		
		contact = true;
	}

	void OnTriggerExit(Collider other) {
		
		contact = false;
	}
}
