using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
	public Transform camPos;
	public Transform FarCamPos;
	public Transform NearCamPos;

	public bool aSwitch;
//	public float ;

//	public 


	int posNum ;


	// Use this for initialization
	void Start () {
	
		posNum = 0;
		camPos = FarCamPos;

	}
	
	// Update is called once per frame
	void Update () {
//		transform.position = camPos.position;

//		if(transform.position )

	
		transform.position = Vector3.Lerp (transform.position, camPos.position, 3f * Time.deltaTime);
		transform.forward = Vector3.Lerp (transform.forward, camPos.forward, 3f * Time.deltaTime);


		if ( Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) {

		



		}


		if (Input.GetMouseButtonDown (1)) {

			Debug.Log("GetMouseButtonDown (1)");
		
			if(posNum ==0){
				camPos = NearCamPos;
				posNum = 1; 
			}
			else
			{
				camPos = FarCamPos;
				posNum = 0; 
			}


		

//			this.GetComponent<FollowCam>().camPos = (Transform)GameObject.FindWithTag("CamPosNear").transform;  

//			GameObject.FindWithTag ("Player").transform;
			
		}



	}
}
