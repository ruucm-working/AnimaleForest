
//First gun, AR, SMG, Ect
var Primary : GameObject;
//Second gun pistol Ect
var Secondary : GameObject;



// Use this for initialization
function Start () {

	Debug.Log ("Start", gameObject);
	Secondary.active = false;


//	Secondary.SetActiveRecursively(false);


}

// Update is called once per frame
function Update () {

//
//if (){
//
//}

	if(Input.GetKeyDown("1") && Secondary.active == true){
	
		Debug.Log ("1", gameObject);
//		Primary.SetActiveRecursively(true);
//		Secondary.SetActiveRecursively(false);
		Primary.active = true;
		Secondary.active = false;


	}

	if(Input.GetKeyDown("2")){
	
	
		Debug.Log ("2", gameObject);
	
//		Primary.SetActiveRecursively(false);
//		Secondary.SetActiveRecursively(true);


		Primary.active = false;
		Secondary.active = true;


//		Primary.active = false;
//		Secondary.active = true;


	}


}

