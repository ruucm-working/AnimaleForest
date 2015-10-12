using UnityEngine;
using System.Collections;

public class tpMuzzle : MonoBehaviour {

	public GameObject flare;
	public Transform muzzle;

	public void spawnMuzzle(){
		PhotonNetwork.Instantiate (flare.name, muzzle.position, muzzle.rotation, 0);
	}
}
