using UnityEngine;
using System.Collections;

public class photonDestroy : MonoBehaviour {

	public int countdown = 50;

	void FixedUpdate(){
		countdown = countdown - 1;

		if (countdown <= 0) {
				Destroy (gameObject);
			}
		}
	}

