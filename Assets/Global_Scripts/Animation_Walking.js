#pragma strict
 
var animator : Animator; //stores the animator component
var v : float; //vertical movements
var h : float; //horizontal movements
var sprint : float;
var isJump : boolean;
 
 
function Start () {
 
animator = GetComponent(Animator); //assigns Animator component when we start the game
 
}
 
function Update () {

 
v = Input.GetAxis("Vertical");
h = Input.GetAxis("Horizontal");
Sprinting();

Jumping();
 
}
 
function FixedUpdate () {
 
 
//Debug.Log("getAxis v :"+v);
//
//Debug.Log("animator :"+animator);
//set the "Walk" parameter to the v axis value
animator.SetFloat ("isWalking", v);
animator.SetFloat ("Turn", h);
animator.SetFloat("Sprint", sprint);
 
}
 
function Sprinting () {


if(Input.GetButton("Fire1")) {
sprint = 0.2;
}
else {
 
sprint = 0.0;
}
 
}


function Jumping () {


if(Input.GetButton("Jump")) {
isJump = true;
animator.SetBool("isJumping",isJump);
//animator.SetTrigger("isJumping2");
//animator.SetTrigger("isIdle2");

}
else {
 
isJump = false;
//animator.SetBool("isJumping",isJump);
}
 
}