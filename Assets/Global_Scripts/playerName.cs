using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerName : Photon.MonoBehaviour {

	public Text name;
	public Text score;

	void Update(){
		PhotonView pv = gameObject.GetComponent<PhotonView>();
		name.text = GetComponent<PhotonView> ().owner.name;
	
		pv.RPC ("updateScore", PhotonTargets.AllBuffered, new object[] { PlayerPrefs.GetInt ("score") });

	}

	[PunRPC]
	public void updateScore(int vc){
		score.text = "Score: " + vc;
	}
}
