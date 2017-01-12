using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed; // speed of player movement
	public GameObject cube;

	private Rigidbody playerObj; // player

	void Start() {
		playerObj = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {

		// movement from Keyboard arrows and Mouse Y axis
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float moveY = Input.GetAxis("Mouse Y");

		Vector3 movement = new Vector3 (moveHorizontal, moveY/5, moveVertical);

		playerObj.AddForce (movement * speed);

		// create a new cube with "P" pressed
		if(Input.GetKeyDown(KeyCode.P)) {
			Vector3 coord = new Vector3((int)transform.position[0],((int)transform.position[1])+0.5f, (int)transform.position[2]);
			Instantiate (cube, coord, new Quaternion(0,0,0,0));
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Bucket")) {
			GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
		} 
		else if (other.gameObject.CompareTag ("Cube")) {
			other.gameObject.GetComponent<Renderer> ().material = GetComponent<Renderer> ().material;
		} 

	}
}
