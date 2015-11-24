 var Item : Transform;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 5;
 
 
 
 
 function Start () 
 {
 
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
			if (other.tag == "Temtation") {

			    transform.LookAt(other.transform);
     
		     if(Vector3.Distance(transform.position,other.transform.position) >= MinDist){
		     
		          transform.position += transform.forward*MoveSpeed*Time.deltaTime;
		 
		           
		           
		          if(Vector3.Distance(transform.position,other.transform.position) <= MaxDist)
		              {
		                 //Here Call any function U want Like Shoot at here or something
		    } 
		    }


			}    
	}


