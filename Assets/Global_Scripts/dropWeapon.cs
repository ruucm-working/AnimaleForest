using UnityEngine;
using System.Collections;

public class dropWeapon : MonoBehaviour {


	public Animation animManager;
	
	public AnimationClip drop_d, drop_d2;

	void OnCollisionEnter(Collision collision) {
		//		foreach (ContactPoint contact in collision.contacts) {
		//			Debug.DrawRay(contact.point, contact.normal, Color.white);
		//		}
		//		if (collision.relativeVelocity.magnitude > 2)
		//			audio.Play();
		
		Debug.Log ("ItemTree collision.gameObject : " + collision.gameObject);
		
		if (collision.gameObject.tag == "Player") {
			Debug.Log("Drop It!");

			Debug.Log("animManager : "+animManager);
			animManager.Play (drop_d.name);
//			animManager2.Play (drop_d.name);

		}
		
	}



}
