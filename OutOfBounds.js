#pragma strict

var Ball : Transform;
var Spawn : Transform;

function OnTriggerEnter (other : Collider) {
    
    other.BroadcastMessage("applyDamage", 1437, SendMessageOptions.DontRequireReceiver);

    
    	if(other.tag == "Ball") {
    	    Destroy(other);
			var instanceBall = Instantiate(Ball, Spawn.transform.position, transform.rotation);
    	 } 
}