using UnityEngine;
using System.Collections;

public class getWeapon : MonoBehaviour
{
	
	
	
//	public static bool Gun1,Gun2 = false; 

	public static int weaponNum = 0;

	
	// Use this for initialization
	void Start ()
	{
		
		//		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		
		
		//		Debug.Log ("other.GetComponentn : "+other.gameObject);
		
		
		if (other.gameObject.tag == "Gun1") {
			
			Debug.Log ("other.gameObject : " + other.gameObject);
			
			Destroy (other.gameObject);

			weaponNum = 1;

			
			
		}
		
		
		
		if (other.gameObject.tag == "Gun2") {
			Destroy (other.gameObject);

			weaponNum = 2;
			Debug.Log ("other.gameObject : " + other.gameObject);
			
		}



		
		
		
		
		
	}


	

	
	
	
	
	
}