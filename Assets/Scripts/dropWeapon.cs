using UnityEngine;
using System.Collections;

public class dropWeapon : MonoBehaviour {


	public Animation animManager;
	
	public AnimationClip drop1;

	void OnCollisionEnter(Collision collision) {
		//		foreach (ContactPoint contact in collision.contacts) {
		//			Debug.DrawRay(contact.point, contact.normal, Color.white);
		//		}
		//		if (collision.relativeVelocity.magnitude > 2)
		//			audio.Play();
		
		Debug.Log ("collision.gameObject : " + collision.gameObject);
		
		if (collision.gameObject.tag == "Blue") {
			Debug.Log("Drop It!");
			animManager.Play (drop1.name);
		}
		
	}



}
