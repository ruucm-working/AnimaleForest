#pragma strict
 
var animator : Animator; //stores the animator component
var v : float; //vertical movements
var h : float; //horizontal movements
var sprint : float;

var j : boolean;


 
function Start () {
 
animator = GetComponent(Animator); //assigns Animator component when we start the game
 
}
 
function Update () {

 
v = Input.GetAxis("Vertical");
h = Input.GetAxis("Horizontal");

//if(!Input.GetButtonDown("Jump"))
//	j = 0;
//else
//	j = 1;

j = Input.GetButtonDown("Jump");

Debug.Log("j : "+j);


Sprinting();
 
}
 
function FixedUpdate () {
 
 
//Debug.Log("getAxis v :"+v);
//Debug.Log("animator :"+animator);

//set the "Walk" parameter to the v axis value
animator.SetFloat ("isWalking", v);
animator.SetFloat ("Turn", h);
//animator.SetFloat("Sprint", sprint);


//set the "Jump"
animator.SetBool("isJumping",j);



 
}
 
function Sprinting () {
if(Input.GetButton("Fire1")) {
sprint = 0.2;
}
else {
 
sprint = 0.0;
}
 
}