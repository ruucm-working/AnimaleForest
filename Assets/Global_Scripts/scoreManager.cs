using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreManager : Photon.MonoBehaviour {

	public int teamAscore;
	public int teamBscore;

	public Text teamA;
	public Text teamB;

	void Update(){
		teamA.text = "Team A: " + teamAscore;
		teamB.text = "Team B: " + teamBscore;

	}

	[PunRPC]
	public void addScoreA(int scoreToAdd){
		teamAscore = teamAscore + scoreToAdd;

	}
	[PunRPC]
	public void addScoreB(int scoreToAdd){
		teamBscore = teamBscore + scoreToAdd;
		
	}

}
