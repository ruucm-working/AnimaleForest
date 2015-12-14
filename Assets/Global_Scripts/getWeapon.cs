using UnityEngine;
using System.Collections;

public class getWeapon : MonoBehaviour
{




	
//	public static bool Gun1,Gun2 = false; 

	public static bool[] weapon = {true, false,  false, false, false ,false};



	
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
			
			Debug.Log ("Get other.gameObject  : " + other.gameObject);
			
			Destroy (other.gameObject);

//			weaponNum = 1;

			weapon[1] = true;
			
			
		}
		
		
		
		if (other.gameObject.tag == "Donut") {
//			Destroy (other.gameObject);
//			Debug.Log ("Get other.gameObject  : " + other.gameObject);
//			weapon[2] = true;
			
		}
		else if (other.gameObject.tag == "Apple") {
			Destroy (other.gameObject);
			
			//			weaponNum = 2;
			Debug.Log ("Get other.gameObject  : " + other.gameObject);
			
			weapon[3] = true;
			
		}
		else if (other.gameObject.tag == "Leaf") {
			Destroy (other.gameObject);
			
			//			weaponNum = 2;
			Debug.Log ("Get other.gameObject : " + other.gameObject);
			
			weapon[4] = true;
			
		}
		else if (other.gameObject.tag == "Candy") {
			Destroy (other.gameObject);
			
			//			weaponNum = 2;
			Debug.Log ("Get other.gameObject : " + other.gameObject);
			
			weapon[5] = true;
			
		}


//		if (other.gameObject.tag == "Donut") {
//			Destroy (other.gameObject);
//			
//			weaponNum = 3;
//			Debug.Log ("other.gameObject : " + other.gameObject);
//			
//		}



		
		
		
		
		
	}




	

	
	
	
	
	
}