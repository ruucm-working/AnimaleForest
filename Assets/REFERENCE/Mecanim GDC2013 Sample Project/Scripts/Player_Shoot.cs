using UnityEngine;
using System.Collections;

/// <summary>
/// Makes player shoot bubbles
/// </summary>
/// 
public class Player_Shoot : MonoBehaviour {
	
	public GameObject Bullet;
	public Transform BulletSpawnPoint;
	public Transform BulletParent;
	
	const float m_BulletSpeed = 20.0f;
	const float m_BulletDuration = 2.0f;
	float m_Timer = 0;
	
	Animator m_Animator;	


	
	
	//{shot, fire, donut}
	public static int weaponNum = 0;
	public Transform[] weapons;	
	public int currentWeapon;

	
	void Start () 
	{
		m_Animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () 
	{		



		//Change Weapon using Number Keypad

		if (Input.GetKeyUp (KeyCode.Alpha0) && getWeapon.weapon[0]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha0)");
			weaponNum = 0;
			this.GetComponent<Player_Shoot>().Bullet = (GameObject)GameObject.Find("FlareMobile"); 
			changeWeapon(0);
			
		}	

	
		
		else if (Input.GetKeyUp (KeyCode.Alpha2) && getWeapon.weapon[2]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha2)");
			weaponNum = 2;
			this.GetComponent<Player_Shoot>().Bullet = (GameObject)GameObject.Find("Par_Donuts"); 
			changeWeapon(2);
			
		}


		else if (Input.GetKeyUp (KeyCode.Alpha3) && getWeapon.weapon[3]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha3)");
			weaponNum = 3;
			this.GetComponent<Player_Shoot>().Bullet = (GameObject)GameObject.Find("Par_Apple"); 
			changeWeapon(3);
			
		}
		
		
		else if (Input.GetKeyUp (KeyCode.Alpha4) && getWeapon.weapon[4]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha4)");
			weaponNum = 4;
			this.GetComponent<Player_Shoot>().Bullet = (GameObject)GameObject.Find("Par_Leaf"); 
			changeWeapon(4);
			
		}
		else if (Input.GetKeyUp (KeyCode.Alpha5) && getWeapon.weapon[5]) {
			Debug.Log("Input.GetKeyUp (KeyCode.Alpha5)");
			weaponNum = 5;
			this.GetComponent<Player_Shoot>().Bullet = (GameObject)GameObject.Find("Par_Candy"); 
			changeWeapon(5);
			
		}


		bool shoot = Input.GetButton("Fire1");
		m_Animator.SetBool("Shoot",shoot);

		if(CanShoot() && shoot)
		{			
			if(m_Timer > 0.1f) // firing rate
			{
				GameObject newBullet = Instantiate(Bullet, BulletSpawnPoint.position , Quaternion.Euler(0, 0, 0)) as GameObject;		  										
//				Destroy(newBullet, m_BulletDuration);	
//				Debug.Log("newBullet : "+newBullet);
				newBullet.GetComponent<Rigidbody>().velocity = -BulletSpawnPoint.forward* m_BulletSpeed;						
				newBullet.GetComponent<DamageProvider>().SetScaleBullet(); 
				newBullet.SetActive(true);  
			
//				Debug.Log("newBullet.GetComponent<Rigidbody>().velocity : "+newBullet.GetComponent<Rigidbody>().velocity);
//				Debug.Log("newBullet.GetComponent<DamageProvider>() : "+newBullet.GetComponent<DamageProvider>());



				if(BulletParent) newBullet.transform.parent = BulletParent;
				
				m_Timer = 0;
			}
		}	
				
		m_Timer += Time.deltaTime;
	}
	
	bool CanShoot()
	{
		AnimatorStateInfo info = m_Animator.GetCurrentAnimatorStateInfo(0);
		
		if(info.IsName("Base Layer.Death") || info.IsName("Base Layer.Reviving") || info.IsName("Base Layer.Dying"))
			return false;
			
		return m_Animator.GetBool("HoldLog");
		
	}

	public void changeWeapon(int num) {
		currentWeapon = num;
		for(int i = 0; i < weapons.Length; i++) {
			if(i == num)
				weapons[i].gameObject.SetActive(true);
			else
				weapons[i].gameObject.SetActive(false);
		}
	}



}
