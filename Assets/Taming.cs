using UnityEngine;
using System.Collections;

public class Taming : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		// Debug.Log("updateFrom Taming"); 

		

	}

	void OnCollisionEnter(Collision collision) {
		// foreach (ContactPoint contact in collision.contacts) {
		// 	Debug.DrawRay(contact.point, contact.normal, Color.white);
		// }
		// if (collision.relativeVelocity.magnitude > 2)
		// GetComponent<AudioSource>().Play();




		Debug.Log("collision : "+collision);


	} 

	void OnCollisionStay(Collision collisionInfo){


		Debug.Log("collisionInfo : "+collisionInfo.gameObject);

	}

	// void OnCollisionExit(Collision collisionInfo){

	// 	Debug.Log("collisionInfo : "+collisionInfo.gameObject);

	// }





}
