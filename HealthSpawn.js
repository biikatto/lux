#pragma strict

var healthPack : Transform;

function Update() {	
if (GameObject.Find("HealthPack") == null)
{
	var packOne = Instantiate(healthPack, transform.position, transform.rotation);
	
}
}