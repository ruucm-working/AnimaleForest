
//First gun, AR, SMG, Ect
var Primary : GameObject;
//Second gun pistol Ect
var Secondary : GameObject;



// Use this for initialization
function Start () {


Secondary.active = false;


}

// Update is called once per frame
function Update () {

//
//if (){
//
//}

if(Input.GetKeyDown("1")){
Primary.active = true;
Secondary.active = false;


}

if(Input.GetKeyDown("2")){
Primary.active = false;
Secondary.active = true;


}


}

