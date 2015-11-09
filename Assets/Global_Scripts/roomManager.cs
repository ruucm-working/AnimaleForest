using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class roomManager : Photon.MonoBehaviour {
	
	public string roomName;
	public string playerName;
	public string currentVersion = "0.1";
	public string team1 = "Red";
	public string team2 = "Blue";
	public string currentTeam;
	
	public bool isConnected = false;
	
	public GameObject uiParent;
	public GameObject gameUIParent;
	public GameObject player1;
	public GameObject player2;
	
	public GameObject mainCam;
	
	public Transform spawn1;
	public Transform spawn2;
	
	public InputField roomField;
	public InputField nameField;
	public Text serverList;



	
	void Awake(){
//		Screen.showCursor = false;
		PhotonNetwork.ConnectUsingSettings (currentVersion);
		uiParent.SetActive (false);
		gameUIParent.SetActive (false);
		nameField.text = PlayerPrefs.GetString ("playerName");
		roomField.text = "Room " + Random.Range (1,999);
	}
	
	void Update(){
		//GameObject otherCams = GameObject.Find ("Main Camera");
		//otherCams.SetActive (false);
		roomName = roomField.text;
		playerName = nameField.text;
		serverList.text = PhotonNetwork.countOfPlayers + " users are online in " + PhotonNetwork.countOfRooms + " rooms.";
		
		if (Input.GetKeyUp (KeyCode.Return)) {
			spawnPlayer();
		}
		
	}
	
	void OnJoinedLobby(){
		uiParent.SetActive (true);
		isConnected = true;
		
	}
	
	public void Join(){
		setName ();
		PhotonNetwork.JoinRoom (roomName);
	}
	
	public void Create(){
		setName ();
		//PhotonNetwork.CreateRoom (roomName);
		PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
		
	}
	
	public void joinRandom(){
		PhotonNetwork.JoinRandomRoom ();
	}
	
	void OnJoinedRoom(){
		mainCam.SetActive (true);
		uiParent.SetActive (false);
		currentTeam = team1;
		gameUIParent.SetActive (true);
	}
	
	void OnCreatedRoom(){
		OnJoinedRoom ();
	}
	
	public void setName(){
		PhotonNetwork.playerName = playerName;
		PlayerPrefs.SetString ("playerName", playerName);
	}
	
	public void chooseRed(){
		currentTeam = team1;
	}
	public void chooseBlue(){
		currentTeam = team2;
	}
	
	public void spawnPlayer(){
		
		
		//Red Player
		if (currentTeam == team1) {
			gameUIParent.SetActive (false);
			GameObject player = PhotonNetwork.Instantiate (player1.name, spawn1.position, spawn1.rotation, 0) as GameObject;
			player.transform.FindChild("Main Camera").gameObject.SetActive(true);
			//				player.transform.FindChild("Graphics").gameObject.SetActive(true);
			((MonoBehaviour)player.GetComponent ("networkController")).enabled = true;	
			((MonoBehaviour)player.GetComponent ("MouseLook")).enabled = true;	
			
			
		}
		
		//Blue Player
		if (currentTeam == team2) {
			
			Debug.Log("spawnPlayer(), team2");
			gameUIParent.SetActive (false);
			GameObject player = PhotonNetwork.Instantiate (player2.name, spawn2.position, spawn2.rotation, 0) as GameObject;
			player.transform.FindChild("Main Camera").gameObject.SetActive(true);
			
			player.transform.FindChild("Graphics").gameObject.SetActive(true);
			((MonoBehaviour)player.GetComponent ("networkController")).enabled = true;	
//			((MonoBehaviour)player.GetComponent ("MouseLook")).enabled = true;	
			
		}
		
		mainCam.SetActive (false);
	}
	
	
	
	
	
}