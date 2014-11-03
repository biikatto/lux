using UnityEngine;
using System.Collections;

public class HealthSpawn : MonoBehaviour{
	HealthPack healthPackPrefab;
	HealthPack healthPackInstance;
	bool waitingForRespawn = false;

	void Start(){
		healthPackPrefab = Resources.Load<HealthPack>("Prefabs/HealthPack");
		SpawnHealthPack();
	}

	void SpawnHealthPack(){
		// Spawn a new health pack
		healthPackInstance = Instantiate(
				healthPackPrefab,
				transform.position,
				transform.rotation) as HealthPack;
		waitingForRespawn = false;
	}

	void Update(){	
		// Respawn if health pack is missing and we aren't already waiting for respawn
		if(healthPackInstance == null){
			if(!waitingForRespawn){
				Invoke("SpawnHealthPack", 3);
				waitingForRespawn = true;
			}
		}
	}
}
