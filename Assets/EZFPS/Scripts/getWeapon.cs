using UnityEngine;
using System.Collections;

public class getWeapon : MonoBehaviour {
	
	
	
	public static bool Gun1,Gun2 = false; 
	
	
	// Use this for initialization
	void Start () {
		
		//		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnTriggerEnter(Collider other) {
		
		
		//		Debug.Log ("other.GetComponentn : "+other.gameObject);
		
		
		if (other.gameObject.tag == "Gun1") {
			
			Debug.Log ("other.gameObject : "+other.gameObject);
			
			Destroy (other.gameObject);
			Gun1 = true;
			
			
			
		}
		
		
		
		if (other.gameObject.tag == "Gun2") {
			Destroy (other.gameObject);
			Gun2 = true;
			
			Debug.Log ("other.gameObject : "+other.gameObject);
			
		}
		
		
		
		
		
		
	}
	
	
	
	
	
}