using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public float speed;

	public Transform brickPrefab;
	public GameObject cube;

	private Rigidbody rb;
	private int count;


	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;
	}

	void FixedUpdate() {
		// before phy calculation
		// SHORTCUT: highlight >  cmd + ' > window input doc appear
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float moveY = Input.GetAxis("Mouse Y");
//		print ("H"+ moveHorizontal+ "V"+ moveVertical+ "Y"+ moveY);

		Vector3 movement = new Vector3 (moveHorizontal, moveY/5, moveVertical);

		rb.AddForce (movement * speed);

		if(Input.GetKeyDown(KeyCode.P))
		{
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
//			if(Input.GetKeyDown(KeyCode.O))
//			{
//				Instantiate (cube, transform.position, new Quaternion(0,0,0,0));
//			}
		} 

	}
}
