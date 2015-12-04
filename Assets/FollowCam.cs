using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public Transform camPos;
	// Use this for initialization
	void Start () {


//		camPos
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = camPos.position;//Vector3.Lerp (transform.position, camPos.position, 1);
		transform.forward = Vector3.Lerp (transform.forward, camPos.forward, 3 * Time.deltaTime);


//		if (Input.GetMouseButtonDown (1)) {
//			 
//			this.GetComponent<FollowCam>().camPos = (Transform)transform.Find("CamPosNear");  
//
//		}

	} 
}
