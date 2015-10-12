using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {


	[PunRPC]
	public void playGunSound(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}
