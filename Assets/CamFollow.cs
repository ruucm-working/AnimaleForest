using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
	public Transform camPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, camPos.position, 3 * Time.deltaTime);
		transform.forward = Vector3.Lerp (transform.forward, camPos.forward, 3 * Time.deltaTime);
	}
}
