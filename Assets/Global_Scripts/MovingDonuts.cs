using UnityEngine;
using System.Collections;

public class MovingDonuts : MonoBehaviour {

	// Use this for initialization
	void Start () {


//		var cube1 = GameObject.Find("Cube1");
	
	}
	
	// Update is called once per frame
	void Update () {


		if (transform.position.x <= 3) {
			// Move the object forward along its z axis 1 unit/second.
			transform.Translate (new Vector3 (3, 0, 0) * Time.deltaTime);
		}
//			if(transform.position.x > 3)
//				transform.position = new Vector3(3 ,0,0);

		
		
		// Move the object upward in world space 1 unit/second.
//		transform.Translate(Vector3.up * Time.deltaTime, Space.World);



	}
}
