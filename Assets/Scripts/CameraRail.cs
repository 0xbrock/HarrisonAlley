using UnityEngine;
using System.Collections;

public class CameraRail : MonoBehaviour {

	public GameObject[] myWaypoints; // Camera rail waypoints
	public GameObject cameraContainer;
	public float speed = 4f;

	private int index;
	private float distance;
	private bool end;
	private Rigidbody rigidBody;
	private Transform transform;

	// Use this for initialization
	void Start () {
		index = 0;
		distance = 0;
		rigidBody = cameraContainer.GetComponent<Rigidbody>();
		transform = cameraContainer.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (myWaypoints.Length != 0 && !end) {
			distance = (myWaypoints[index].transform.position - transform.position).magnitude;

			if (Mathf.Abs (distance) <= 0.05f) {
				rigidBody.velocity = new Vector3 (0, 0, 0);
				index++;
				Debug.Log ("stoped");

				if (index == myWaypoints.Length)
					end = true;
			} else {
				var nextWaypoint = myWaypoints [index];
				var dir = (nextWaypoint.transform.position - transform.position).normalized * speed;
				rigidBody.velocity = dir;

				Debug.Log (rigidBody.velocity);
			}
		}
	}
}
