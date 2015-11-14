using UnityEngine;
using System.Collections;

public class dropWeapon : MonoBehaviour {


	public Animation animManager;
	
	public AnimationClip drop_d;

	void OnCollisionEnter(Collision collision) {
		//		foreach (ContactPoint contact in collision.contacts) {
		//			Debug.DrawRay(contact.point, contact.normal, Color.white);
		//		}
		//		if (collision.relativeVelocity.magnitude > 2)
		//			audio.Play();
		
		Debug.Log ("collision.gameObject : " + collision.gameObject);
		
		if (collision.gameObject.tag == "Blue") {
			Debug.Log("Drop It!");
			animManager.Play (drop_d.name);
		}


	}


	// Update is called once per frame
	void Update () {
		
		
//		if (transform.position.x <= 3) {
			// Move the object forward along its z axis 1 unit/second.
//			transform.Translate (new Vector3 (3, 0, 0) * Time.deltaTime);
//		}

		
	}



}
