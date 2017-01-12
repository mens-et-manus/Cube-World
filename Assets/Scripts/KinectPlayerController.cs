using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KinectPlayerController : MonoBehaviour
{


    public float speed;

    public Transform brickPrefab;
    public GameObject cube;

    private Rigidbody rb;
    private int count;
    public FollowJoint followJoint;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        followJoint = GetComponent<FollowJoint>();
    }

    void FixedUpdate()
    {
        // before phy calculation
        
        transform.position = followJoint.ReadPosition;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 coord = new Vector3((int)transform.position[0], ((int)transform.position[1]) + 0.5f, (int)transform.position[2]);
            Instantiate(cube, coord, new Quaternion(0, 0, 0, 0));
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bucket"))
        {
            GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
        }
        else if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            //			if(Input.GetKeyDown(KeyCode.O))
            //			{
            //				Instantiate (cube, transform.position, new Quaternion(0,0,0,0));
            //			}
        }

    }
}
