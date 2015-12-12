#pragma strict

//var itemscript : script ;


var player : GameObject;
var ScriptB : Item; //This should be were Script B goes

function Start () {

}

function Update () {

}


function OnTriggerEnter (other : Collider) {
		if(other.gameObject.tag == "Item_Bullet"){
		Debug.Log("tag ==  Item_Bullet");
		
		player = GameObject.Find("Dude");		
		
		Debug.Log("player.GetComponent.<Item>() : "+player.GetComponent("Item"));
		player.GetComponent.<Item>().PickUpItem();
		
//		ScriptB.PickUpItem();
		
		
		}
}
	