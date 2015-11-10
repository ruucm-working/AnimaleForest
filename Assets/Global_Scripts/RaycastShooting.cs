using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour
{
	public GameObject flare;
	public GameObject par;
	
	public float range = 100;
	 
	public int ammo;
	public int theDamage;
	public int clipSize = 10;
	public int reloadTime = 30;
	public int rt;
	
	public Animation animManager, animManager1, animManager2;
	public AnimationClip shoot, reload, change;
	public AnimationClip shoot1 ,reload1, change1;
	public AnimationClip shoot2 ,reload2, change2;



	public static int weaponNum = 0;
	
	public bool isReload;

	public Transform muzzle;
	
	
	void Awake(){

		Reload ();



	}
	
	
	void Update () {
		ammo = PlayerPrefs.GetInt ("ammo");
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2,0));
		
		if (isReload) {
			rt = rt - 1;
		}
		
		if (rt <= 0) {
			rt = reloadTime;
			isReload = false;
			Reload ();
		}
		
		if (Input.GetKeyUp (KeyCode.R)) {
			startReload ();
		}
		
		if(Input.GetMouseButtonDown(0) && ammo >= 1 && !isReload)
		{



			if (weaponNum ==0)
				fireShot ();
			else
				candyShot();

		}


		if (Input.GetKeyUp (KeyCode.Alpha0) && getWeapon.weapon[0]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha0)");
			weaponNum = 0;
//			startChange();
			this.GetComponent<RaycastShooting>().par = (GameObject)GameObject.Find("FlareMobile"); 
			
		}


		if (Input.GetKeyUp (KeyCode.Alpha1) && getWeapon.weapon[1]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha1)");
			weaponNum = 1;
			startChange(1);
			this.GetComponent<RaycastShooting>().par = (GameObject)GameObject.Find("FireMobile"); 
//			this.GetComponent<RaycastShooting>().animManager = (GameObject)GameObject.Find("Gun1"); 


//			MySpell = Instantiate(animManager, transform.position, transform.rotation);
		}


		if (Input.GetKeyUp (KeyCode.Alpha2) && getWeapon.weapon[2]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha2)");
			weaponNum = 2;
//			startChange();
			this.GetComponent<RaycastShooting>().par = (GameObject)GameObject.Find("Donuts par"); 
			
		}


	}
	
	public void fireShot(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		
		spawnMuzzle ();
		PlayerPrefs.SetInt ("ammo", ammo - 1);

			animManager.Play (shoot.name);
	




		if (Physics.Raycast (ray, out hit, range) && ammo >= 1) {
			GameObject particleClone;
			particleClone = Instantiate (par, hit.point, Quaternion.LookRotation (hit.normal)) as GameObject;
			Destroy (particleClone, 0.3f);
			if(hit.collider.gameObject.GetComponent<PhotonView>() != null){
				PhotonView pv = hit.collider.gameObject.GetComponent<PhotonView> ();
				pv.RPC ("ApplyDamage", PhotonTargets.All, theDamage);
				
				if (pv.transform.tag == "Blue" && gameObject.tag == "Red") {
					PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score") + 5);
				}
				if (pv.transform.tag == "Red" && gameObject.tag == "Blue") {
					PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score") + 5);
				}
			}
		}
	}


	public void candyShot(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		
//		spawnMuzzle ();
		PlayerPrefs.SetInt ("ammo", ammo - 1);
		
		if(weaponNum ==1)
			animManager1.Play (shoot.name);
		else if (weaponNum ==2)
			animManager1.Play (shoot.name);
		

		
		
		if (Physics.Raycast (ray, out hit, range) && ammo >= 1) {
			GameObject particleClone;
			particleClone = Instantiate (par, hit.point, Quaternion.LookRotation (hit.normal)) as GameObject;
//			Destroy (particleClone, 0.3f);

			Debug.Log("par.GetComponent<ScriptName>().VariableName : "+this.GetComponent<RaycastShooting>().par);


			if(hit.collider.gameObject.GetComponent<PhotonView>() != null){
				PhotonView pv = hit.collider.gameObject.GetComponent<PhotonView> ();
				pv.RPC ("ApplyDamage", PhotonTargets.All, theDamage);
				
				if (pv.transform.tag == "Blue" && gameObject.tag == "Red") {
					PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score") + 5);
				}
				if (pv.transform.tag == "Red" && gameObject.tag == "Blue") {
					PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score") + 5);
				}
			}
		}
	}

	
	public void spawnMuzzle(){
		PhotonNetwork.Instantiate (flare.name, muzzle.position, muzzle.rotation, 0);
	}
	
	
	public void Reload(){
		PlayerPrefs.SetInt ("ammo", clipSize);
	}
	
	public void startReload(){

		if(weaponNum ==0)
			animManager.Play (reload.name);
		else if (weaponNum ==1)
			animManager1.Play (reload.name);


		isReload = true;
		rt = reloadTime;
		
	}

	public void startChange(int wpNum){

		if (wpNum == 1) {
			animManager.Play (change.name);
			animManager1.Play (change1.name);

			animManager.CrossFade ("Gun1");

		} else if (wpNum == 2) {

		}else if (wpNum == 0) {
			
		}






//		animManager = 


	}

}