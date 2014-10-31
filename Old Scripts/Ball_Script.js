#pragma strict

var SpawnPoint : Transform;

function OnTriggerEnter (other : Collider) {
	if(other.tag == "Goal") {
		Destroy(gameObject);
	}
}
