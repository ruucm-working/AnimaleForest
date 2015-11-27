using UnityEngine;
using System.Collections;

public class Test_Raycast : MonoBehaviour {

	RaycastHit hit;
	float distanceToGround = 0;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Physics.Raycast(transform.position, Vector3.down, out hit, 10.0F)) {
			distanceToGround = hit.distance;
		}

		Debug.Log ("distanceToGround : "+distanceToGround);

	
	}
}
