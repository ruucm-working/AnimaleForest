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
 // var isTamed = false;
 
 var pMoveSpeed = 4;
 var pMaxDist = 10;
 var pMinDist = 5;





var tamehit_count : int = 0;
var isTamed : boolean;


 
 
 function Start () 
 {

 	// m_Animator = GetComponent.<Animator>();
		// m_Animator.logWarnings = false; // so we dont get warning when updating controller in live link ( undocumented/unsupported function!)
		// Debug.Log ("m_Animator : "+m_Animator);


}



function Update () 
{


	//Define Action of Animale when Tame Success!
		if(isTamed){


			//Trail Player
			//transform.LookAt(Player);

			if(Vector3.Distance(transform.position,Player.position) >= pMinDist){

				transform.position += transform.forward*pMoveSpeed*Time.deltaTime;



				if(Vector3.Distance(transform.position,Item.position) <= pMaxDist)
				{
		                 //Here Call any function U want Like Shoot at here or something
		             } 

		         }




		    //Scale Heart UI 
		    if(UI.transform.localScale.magnitude < 1.5 )
		    {
					UI.transform.localScale *= 1 + Time.deltaTime / 0.25f;  // makes bullet scale overtime

					Debug.Log("transform.localScale : "+transform.localScale);

				}


			}







		





}	





function OnCollisionEnter(collision: Collision) {


	Debug.Log("OnCollisionEnter : "+collision.gameObject.name);



	if(collision.gameObject.name == "Dude"){

		tamehit_count +=1;
	}



	if(tamehit_count >= 20 && !isTamed){
		Debug.Log("Tame Success! by Hit");
		Debug.Log("tamehit_count : "+tamehit_count);
	  GetComponent("Item").Tame();//finding the players inv.
	  isTamed = true;

	}




		// Debug.Log("tamehit_count : "+tamehit_count);










}


