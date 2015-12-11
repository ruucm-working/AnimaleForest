using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
	public Transform target;
	public float speed = 3f;
	public float attack1Range = 1f;
	public int attack1Damage = 1;
	public float timeBetweenAttacks;
	public static bool moveSwitch ;
	
	
	// Use this for initialization
	void Start ()
	{
		Rest ();


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void MoveToPlayer ()
	{
		//rotate to look at player


//		transform.Rotate (new Vector3 (0, -90, 0), Space.World);


		Debug.Log ("moveSwitch : " + moveSwitch);

//		GetComponent("Patrol").enabled = false; 
//		GetComponent("NavMeshAgent").enabled = false; 


		if (moveSwitch) {
		
			gameObject.GetComponent<Patrol> ().enabled = false; 
			gameObject.GetComponent<NavMeshAgent> ().enabled = false; 

		} else {
		
			gameObject.GetComponent<Patrol> ().enabled = true; 
			gameObject.GetComponent<NavMeshAgent> ().enabled = true; 
		
		}


		//move towards player
		if (Vector3.Distance (transform.position, target.position) > attack1Range && moveSwitch) {
//			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));

			transform.LookAt (target.position);
			transform.position = Vector3.Lerp (transform.position, target.position, 0.1f * Time.deltaTime);

//			moveSwitch = true;

		} else {

			moveSwitch = false;
		}
	


	}
	
	public void Rest ()
	{
		
	}
}