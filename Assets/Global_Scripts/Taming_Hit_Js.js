#pragma strict



var tamehit_count : int = 0;

var isTamed : boolean;

function Start () {

}

function Update () {







}





function OnCollisionEnter(collision: Collision) {


	Debug.Log("OnCollisionEnter : "+collision.gameObject.name);



	if(collision.gameObject.name == "Dude"){

		tamehit_count +=1;
	}






}


function OnTriggerStay (other : Collider) {

	  // GetComponent("Item").Tame();//finding the players inv.

	  




}