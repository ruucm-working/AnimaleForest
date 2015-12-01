 var Item : Transform;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 5;
 var m_Animator = null ; 
 var tameCount = 0;
 
 
 function Start () 
 {
 
 		m_Animator = GetComponent.<Animator>();
		m_Animator.logWarnings = false; // so we dont get warning when updating controller in live link ( undocumented/unsupported function!)
		Debug.Log ("m_Animator : "+m_Animator);
 
 }
 
 function Update () 
 {
 
//     transform.LookAt(Item);
//     
//     if(Vector3.Distance(transform.position,Item.position) >= MinDist){
//     
//          transform.position += transform.forward*MoveSpeed*Time.deltaTime;
// 
//           
//           
//          if(Vector3.Distance(transform.position,Item.position) <= MaxDist)
//              {
//                 //Here Call any function U want Like Shoot at here or something
//    } 
//    
//    }
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
			
			Debug.Log("Temtation Entered!");

			    transform.LookAt(other.transform);
     
		     if(Vector3.Distance(transform.position,other.transform.position) >= MinDist){
		     
		          transform.position += transform.forward*MoveSpeed*Time.deltaTime;
		 
		           
		           
		          if(Vector3.Distance(transform.position,other.transform.position) <= MaxDist)
		              {
		                 //Here Call any function U want Like Shoot at here or something
		                 Destroy (other.gameObject);
		                 tameCount += 1;
		    } 
		    }



			m_Animator.SetBool("isWalking", true); // tell animator to shoot
			
			if(tameCount >3) 
				m_Animator.SetBool("isJumping", true); // tell animator to shoot

			

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



