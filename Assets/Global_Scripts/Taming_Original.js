 var Player : Transform;
 
 var UI : GameObject;
 
// var script : Patrol = GetComponent("Patrol");


static var item_script : Item;

var MoveSpeed = 4;
var MaxDist = 10;
var MinDist = 5;
var m_Animator = null ; 
var tameCount = 0;


 //Variable for ChasePlayer
 var trailPlayerSw = false; 
 var isTamed = false;
 
 var pMoveSpeed = 4;
 var pMaxDist = 10;
 var pMinDist = 5;
 
 
 function Start () 
 {

 	m_Animator = GetComponent.<Animator>();
		m_Animator.logWarnings = false; // so we dont get warning when updating controller in live link ( undocumented/unsupported function!)
		Debug.Log ("m_Animator : "+m_Animator);


	}

	function Update () 
	{



		//Define Action of Animale when Tame Success!
		if(isTamed){


			//Trail Player
			//transform.LookAt(Player);
			
			//yield WaitForSeconds(1);
			
			
			transform.forward = Vector3.Lerp (transform.forward, Player.forward, 0.1f * Time.deltaTime);


			if(Vector3.Distance(transform.position,Player.position) >= pMinDist){

				transform.position += transform.forward*pMoveSpeed*Time.deltaTime;




				//if(Vector3.Distance(transform.position,Item.position) <= pMaxDist)
				//{
				
				//transform.position += transform.forward*pMoveSpeed*Time.deltaTime;
		                 //Here Call any function U want Like Shoot at here or something
	            // } 

		         }




		    //Scale Heart UI 
		    if(UI.transform.localScale.magnitude < 1.5 )
		    {
					UI.transform.localScale *= 1 + Time.deltaTime / 0.25f;  // makes bullet scale overtime

					Debug.Log("transform.localScale : "+transform.localScale);

				}


			}







		}



// function OnTriggerEnter (other:Collider) {   
//		if (other.tag == "Temtation") {
//			Destroy(other.gameObject); 
//		}    
//			var gos : GameObject[]; 
//			gos = GameObject.FindGameObjectsWithTag("Temtation");
//		if (gos.length == 0) {     
//		// load new scene    }}
//	    }
//}



function OnTriggerStay (other : Collider) {
//			Debug.Log("OnTriggerStay, other :"+other);

if (other.tag == "Temtation") {


	m_Animator = GetComponent.<Animator>();

	Debug.Log("Temtation Entered!");

	transform.LookAt(other.transform);

	if(Vector3.Distance(transform.position,other.transform.position) >= MinDist){

		transform.position += transform.forward*MoveSpeed*Time.deltaTime;



		if(Vector3.Distance(transform.position,other.transform.position) <= MaxDist)
		{
		                 //Here Call any function U want Like Shoot at here or something
		                 Debug.Log("MaxDist (Lower) - other.gameObjec : "+other.gameObject );
		                 Destroy (other.gameObject);
//		                 if(other.gameObject == null){
	tameCount += 1;
	Debug.Log("tameCount : "+tameCount);
//		                	 }
		} 
	}



			m_Animator.SetBool("isWalking", true); // tell animator to shoot
			
			if(tameCount >= 3 && !isTamed) {

				Debug.Log("Tame Success!");
				m_Animator.SetBool("isJumping", true); // tell animator to shoot
				// trailPlayerSw = true;

				GetComponent("Patrol").enabled = false; 
				GetComponent("NavMeshAgent").enabled = false; 

			      GetComponent("Item").Tame();//finding the players inv.

			      isTamed = true;


		  	}
		}
//			else




}

function OnCollisionStay(collision: Collision) {
//	for (var contact: ContactPoint in collision.contacts) {
//		Debug.DrawRay(contact.point, contact.normal, Color.white);
//	}
//	if (collision.relativeVelocity.magnitude > 2)
//		GetComponent.<AudioSource>().Play();

//				Debug.Log("collision.tag : "+collision.tag);
//
//			if (collision.tag == "Temtation") {
//				Debug.Log("Get Temtation");
////				Destory();
//				Destroy (this);
//			}



}	



