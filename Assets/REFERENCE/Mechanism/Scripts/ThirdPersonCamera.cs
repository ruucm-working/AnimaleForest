using UnityEngine;
using System.Collections;

/// <summary>
/// Third person camera.
/// </summary>
public class ThirdPersonCamera : MonoBehaviour
{
	public float distanceAway;			
	public float distanceUp;		
	public float distanceRot;
	public float smooth;				// how smooth the camera movement is
		
	private Vector3 m_TargetPosition;		// the position the camera is trying to be in)
	
	Transform follow, camera;
	
	void Start(){
		follow = GameObject.FindWithTag ("Player").transform;	
	}
	
	void LateUpdate ()
	{
		// setting the target position to be the correct offset from the 
		m_TargetPosition = follow.position+ new Vector3(0.13f,0.005f,0.04f)+ new Vector3(0.14f,0.004f,0.02f) + Vector3.up * distanceUp - follow.forward * distanceAway ;


		 
		 
		Debug.Log ("follow.forward : "+follow.forward); 
		Debug.Log ("follow.up : "+follow.up); 
		Debug.Log ("follow.rotation : "+follow.rotation); 


		
		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);



		
		// make sure the camera is looking the right way!
		transform.LookAt(follow);
	}
}
