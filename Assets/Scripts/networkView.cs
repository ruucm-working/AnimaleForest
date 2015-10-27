using UnityEngine;
using System.Collections;

public class networkView : Photon.MonoBehaviour {


	public GameObject cam;
	public GameObject graph;
	

	
	// Update is called once per frame
	void Update () {
		
	

		if (photonView.isMine) {
			graph.SetActive (false);			
		} else {
			cam.SetActive (false);
		}

	}
	

}


	

