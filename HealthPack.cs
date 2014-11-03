using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour{
	public float healAmount = 25f;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
    		other.BroadcastMessage(
    				"applyDamage",
    				healAmount * -1,
    				SendMessageOptions.DontRequireReceiver);
    		Destroy(gameObject);
    	}
	}
}
