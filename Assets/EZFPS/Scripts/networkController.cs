using UnityEngine;
using System.Collections;

public class networkController : Photon.MonoBehaviour {
	
	public GameObject camera;

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;

	public bool isPaused;

	public int health = 100;

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	
	
	void Awake(){
		gameObject.name = PhotonNetwork.playerName;
		camera.SetActive (true);
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("triggered");
		if (other.tag == "Death") {
			Die ();
		}
	}
	
	void FixedUpdate () {

		if( photonView.isMine ) {
			//camera.SetActive (true);
			//gameObject.GetComponent<playerName>().enabled = false;

			if(health <= 0){
				Die ();
			}
			// Do nothing -- the character motor/input/etc... is moving us
			//graphics.SetActive(false);

			if(Input.GetKeyDown (KeyCode.Escape)){
				isPaused = true;
			}
			if(isPaused){
				gameObject.GetComponent <MouseLook> ().enabled = false;
				gameObject.GetComponentInChildren <MouseLook> ().enabled = false;
			}
			if (grounded) {
				// Calculate how fast we should be moving
				Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				targetVelocity = transform.TransformDirection(targetVelocity);
				targetVelocity *= speed;
				
				// Apply a force that attempts to reach our target velocity
				Vector3 velocity = GetComponent<Rigidbody>().velocity;
				Vector3 velocityChange = (targetVelocity - velocity);
				velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
				velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
				velocityChange.y = 0;
				GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
				
				// Jump
				if (canJump && Input.GetButton("Jump")) {
					GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				}
			}
			
			// We apply gravity manually for more tuning control
			GetComponent<Rigidbody>().AddForce(new Vector3 (0, -gravity * GetComponent<Rigidbody>().mass, 0));
			
			grounded = false;
		}
		else {
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
		}



	}
	
	void OnCollisionStay () {
		grounded = true;    
	}
	
	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}




	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if(stream.isWriting) {
			// This is OUR player. We need to send our actual position to the network.
			
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else {
			// This is someone else's player. We need to receive their position (as of a few
			// millisecond ago, and update our version of that player.
			
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
		}
		
	}

	public GUISkin skin;

	void OnGUI(){
		GUI.skin = skin;
		GUI.Box (new Rect(10,10,100,30), "Health: " + health);
		GUI.Box (new Rect(10,40,100,30), "Ammo: " + PlayerPrefs.GetInt ("ammo"));
		GUI.Box (new Rect (120, 10, 100, 30), "Score: " + PlayerPrefs.GetInt ("score"));

		if (isPaused) {
			if(GUI.Button (new Rect(Screen.width/2 - 50,Screen.height/2, 100,30), "Suicide")){
				Die ();
			}
			if(GUI.Button (new Rect(Screen.width/2 - 50,Screen.height/2 + 35, 100,30), "Disconnect")){
				PhotonNetwork.Destroy (gameObject);
				PhotonNetwork.Disconnect();
				Application.LoadLevel (0);
			}
			if(GUI.Button (new Rect(Screen.width/2 - 50,Screen.height/2 + 70, 100,30), "Quit")){
				PhotonNetwork.Destroy (gameObject);
				PhotonNetwork.Disconnect();
				Application.Quit ();
			}
			if(GUI.Button (new Rect(Screen.width/2 - 50,Screen.height/2 + 105, 100,30), "Close")){
				isPaused = false;
				gameObject.GetComponent <MouseLook> ().enabled = true;
				gameObject.GetComponentInChildren <MouseLook> ().enabled = true;
			}

		}

	}




	[PunRPC]
	public void ApplyDamage(int damage){
		health = health - damage;
		Debug.Log (health);

	}

	public void Die(){
		PhotonNetwork.Instantiate ("tombStone", transform.position, transform.rotation,0);
		PhotonNetwork.Destroy (gameObject);
		GameObject.Find ("_Room").GetComponent<roomManager> ().SendMessage ("OnJoinedRoom");
		PhotonView roompv = GameObject.Find ("_NETWORKSCRIPTS").GetComponent<PhotonView> ();
		if(gameObject.tag == "Red"){
			roompv.RPC ("addScoreB", PhotonTargets.AllBuffered, 10);
		}
		if(gameObject.tag == "Blue"){
			roompv.RPC ("addScoreA", PhotonTargets.AllBuffered, 10);
		}

	}



}
