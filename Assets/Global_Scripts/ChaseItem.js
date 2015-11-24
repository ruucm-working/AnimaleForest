 var Item : Transform;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 5;
 
 
 
 
 function Start () 
 {
 
 }
 
 function Update () 
 {
     transform.LookAt(Item);
     
     if(Vector3.Distance(transform.position,Item.position) >= MinDist){
     
          transform.position += transform.forward*MoveSpeed*Time.deltaTime;
 
           
           
          if(Vector3.Distance(transform.position,Item.position) <= MaxDist)
              {
                 //Here Call any function U want Like Shoot at here or something
    } 
    
    }
 }