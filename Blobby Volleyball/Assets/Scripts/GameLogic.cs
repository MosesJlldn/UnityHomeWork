using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {


	public GameObject player1;
	public GameObject player2;
	public GameObject ballPrefab;
	private bool count = true;
	private bool ballin = false;

	// Use this for initialization
	void Start () {
		
		Instantiate (ballPrefab, new Vector3 (-3f, 2f, 0f), Quaternion.identity);
		Instantiate (player1, new Vector3 (-3f, 0f, 0f), Quaternion.identity);
		Instantiate (player2, new Vector3 ( 3f, 0f, 0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit (Collider other) {

		if (other.gameObject.tag.Equals("Ball")) {

			count = !count;

			//player1.transform.position = new Vector3 (-3f, 0f, 0f);
			//player2.transform.position = new Vector3 ( 3f, 0f, 0f);

			if (count) {
				
				Vector3 ballPos = (new Vector3 (-3f, 2f, 0f));

				Destroy  (other.gameObject);

				Destroy (player1);
				Destroy (player2);

				Instantiate (ballPrefab, ballPos, Quaternion.identity);
				ballin = true;

				//Instantiate (player1, new Vector3 (-3f, 0f, 0f), Quaternion.identity);
				//Instantiate (player2, new Vector3 ( 3f, 0f, 0f), Quaternion.identity);

			} else {
				
				Vector3 ballPos = (new Vector3 (3f, 2f, 0f));

				Destroy  (other.gameObject);

				Destroy (player1);
				Destroy (player2);

				Instantiate (ballPrefab, ballPos, Quaternion.identity);
				ballin = true;

				//Instantiate (player1, new Vector3 (-3f, 0f, 0f), Quaternion.identity);
				//Instantiate (player2, new Vector3 ( 3f, 0f, 0f), Quaternion.identity);

			}
		}
	}

	void OnTriggerStay (Collider coll1, Collider coll2) {

		if (ballin && coll1.gameObject.tag.Equals("Player") && coll2.gameObject.tag.Equals("Player")) {

			Destroy (coll1.gameObject);
			Destroy (coll2.gameObject);

			Instantiate (player1, new Vector3 (-3f, 0f, 0f), Quaternion.identity);
			Instantiate (player2, new Vector3 ( 3f, 0f, 0f), Quaternion.identity);

			ballin = false;
		}
	}
}
