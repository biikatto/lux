using UnityEngine;
using System.Collections;

[AddComponentMenu("Gameplay/Ball")]
public class Ball : MonoBehaviour{
	public Transform SpawnPoint;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Goal"){
			Destroy(gameObject);
		}
	}
}
