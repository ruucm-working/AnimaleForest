using UnityEngine;
using System.Collections;

public class TestAnim : MonoBehaviour {


	public Animator anim; //stores the animator component


	// Use this for initialization
	void Start () {


		anim =GetComponent<Animator>(); //assigns Animator component when we start the game
		Debug.Log ("Start");
		Debug.Log ("Start");
	
	}
	
	// Update is called once per frame
	void Update () {
	

		anim.SetBool("isWalking",true);

		Debug.Log ("Update");




	}



}
