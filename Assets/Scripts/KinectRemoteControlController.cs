﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KinectRemoteControlController : MonoBehaviour
{
	public GameObject cube;
	public float thresholdTop;
	public float thresholdBottom;
	public GameObject player;

	private GameObject selectedCube;

	private FollowJoint followJoint; // Kinect Script


	void Start() {
		// get Kinect scripts
		followJoint = GetComponent<FollowJoint>();
		selectedCube = player.GetComponent<PlayerController>().selectedCube;
	}

	void FixedUpdate(){

		selectedCube = player.GetComponent<PlayerController>().selectedCube;

		// read position from Right hand
		transform.position = followJoint.ReadPosition;

		if (transform.position[1] >= thresholdTop){
			// Left hand is high -> create a new cube
			Vector3 coord = new Vector3((int)player.transform.position[0], ((int)player.transform.position[1]) + 0.5f, (int)player.transform.position[2]);
			Instantiate(cube, coord, new Quaternion(0, 0, 0, 0));
		} else if( transform.position[1] <= thresholdBottom && selectedCube.gameObject.CompareTag("Cube") ){
			// Left hand is low -> delete the cube
			selectedCube.gameObject.SetActive (false);
		}

	}

}
