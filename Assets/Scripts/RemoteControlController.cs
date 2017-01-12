using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KinectPlayerController : MonoBehaviour
{
	public GameObject cube;

	private Rigidbody rb;
	private FollowJoint followJoint; // Kinect Script

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		// get Kinect scripts
		followJoint = GetComponent<FollowJoint>();
	}

	void FixedUpdate()
	{	// before phy calculation

		// read position from Right hand
		transform.position = followJoint.ReadPosition;

		if (Input.GetKeyDown(KeyCode.P)){
			// create a new cube with "P" pressed
			Vector3 coord = new Vector3((int)transform.position[0], ((int)transform.position[1]) + 0.5f, (int)transform.position[2]);
			Instantiate(cube, coord, new Quaternion(0, 0, 0, 0));
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bucket")){
			// collect the material
			GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
		}
		else if (other.gameObject.CompareTag("Cube")){
			// assign the material to a cube
			other.gameObject.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
		}

	}
}
