using UnityEngine;
using System.Collections;

public class POLICEscript : MonoBehaviour {

	public float rotateSpeed = 2.0f;
	
	private bool rotating;


	public Transform[] patrol;
	private int Currentpoint;
	public float moveSpeed;
	
	void Start()
	{
		transform.position = patrol [0].position;
		Currentpoint = 0;
	}


	void Update() {


		
		StartCoroutine(TurnTowards(-transform.forward));


		if(Vector3.Distance(transform.position, patrol[Currentpoint].position) < 0.5f) {
			Currentpoint++;
		}
		
		if(Currentpoint >= patrol.Length)
		{
			Currentpoint = 0;
		}
		
		transform.position = Vector3.MoveTowards (transform.position, patrol [Currentpoint].position, moveSpeed * Time.deltaTime); 





	}
	
	IEnumerator TurnTowards(Vector3 lookAtTarget) {    
		
		if(rotating == false) {
			//Vector3 direction = lookAtTarget - transform.position;//this can be deleted, it's never used :P
			Quaternion newRotation = Quaternion.LookRotation(lookAtTarget - transform.position);
			newRotation.x = 0;
			newRotation.z = 0;
			
			for (float u = 0.0f; u <= 1.0f; u += Time.deltaTime * rotateSpeed) {
				rotating = true;
				transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, u);
				
				yield return null;
			}
			rotating = false;
		}
	}
}
