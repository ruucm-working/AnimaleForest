using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {


	public GameObject [] prefabs;

	public float delay = 2.0f;
	public bool active = true;

	public Vector2 delayRange = new Vector2 (1,2);

	int sum=0;



	// Use this for initialization
	void Start () {

		//Adjust delay range 
		ResetDelay ();
		StartCoroutine(EnemyGenerator());

	
	}


    IEnumerator EnemyGenerator() {

		yield return new WaitForSeconds (delay);

		if (active) {
			var newTransform = transform;
				


			print ("prefabs.Length"+prefabs.Length);
			//복제. 세포복제 같은것.
			Instantiate (prefabs [Random.Range (0, prefabs.Length)], newTransform.position, Quaternion.identity);
			ResetDelay ();
		}
		StartCoroutine (EnemyGenerator ());

	}




	void ResetDelay(){
		delay = Random.Range (delayRange.x, delayRange.y);
	}


}
