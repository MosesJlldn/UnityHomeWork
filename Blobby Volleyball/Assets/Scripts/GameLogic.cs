using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {


	public GameObject player1Prefab;
	public GameObject player2Prefab;
	public GameObject ballPrefab;

	private bool count = true;
	private bool ballin = false;

	GameObject player1;
	GameObject player2;
	GameObject ball;

	// Use this for initialization
	void Start () {
		
		ball = Instantiate (ballPrefab, new Vector3 (-3f, 2f, 0f), Quaternion.identity) as GameObject;
		player1 = Instantiate (player1Prefab, new Vector3 (-3f, 0f, 0f), Quaternion.identity) as GameObject;
		player2 = Instantiate (player2Prefab, new Vector3 ( 3f, 0f, 0f), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit (Collider other) {

		if (other.gameObject.tag.Equals("Ball")) {

			count = !count;

			if (count) {
				
				Destroy  (other.gameObject);
				Destroy (player1);
				Destroy (player2);

				ball    = Instantiate (ballPrefab,    new Vector3 (-3f, 8f, 0f), Quaternion.identity) as GameObject;
				player1 = Instantiate (player1Prefab, new Vector3 (-3f, 0f, 0f), Quaternion.identity) as GameObject;
				player2 = Instantiate (player2Prefab, new Vector3 ( 3f, 0f, 0f), Quaternion.identity) as GameObject;
			} else {

				Destroy  (other.gameObject);
				Destroy (player1);
				Destroy (player2);

				ball =    Instantiate (ballPrefab,    new Vector3 ( 3f, 8f, 0f), Quaternion.identity) as GameObject;
				player1 = Instantiate (player1Prefab, new Vector3 (-3f, 0f, 0f), Quaternion.identity) as GameObject;
				player2 = Instantiate (player2Prefab, new Vector3 ( 3f, 0f, 0f), Quaternion.identity) as GameObject;
			}
		}
	}
}
