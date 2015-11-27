using UnityEngine;
using System.Collections;

/// <summary>
/// Third person camera.
/// </summary>
public class ThirdPersonCamera : MonoBehaviour
{
	public float distanceAway;			
	public float distanceUp;			
	public float smooth;				// how smooth the camera movement is
		
	private Vector3 m_TargetPosition;		// the position the camera is trying to be in)
	
	Transform follow; 
	
	void Start(){
		follow = GameObject.FindWithTag ("Blue").transform;	
	}
	
	void LateUpdate ()
	{
		// setting the target position to be the correct offset from the 
		m_TargetPosition = follow.position  + Vector3.up * distanceUp - follow.forward * distanceAway;

		Debug.Log ("follow.position : "+follow.position);
		Debug.Log ("Vector3.up : "+Vector3.up);

		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);
		
		// make sure the camera is looking the right way!
		transform.LookAt(follow);
	}
}
