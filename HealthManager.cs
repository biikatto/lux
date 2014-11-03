using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour{
	public float maxHealth = 100f;
	[Tooltip("Time (in seconds) this entity takes to respawn")]
	public float respawnTime = 3f;
	[Tooltip("Time (in seconds) this entity is invincible after being damaged")]
	public float hitInvincibilityTime = 1f;

	private float health;
	private bool invincible = false;

	[Tooltip("Transform for the respawn point for this entity")]
	public Transform spawnPoint;

	public GUISkin hpDisplaySkin;
	private Rect hpDisplayRect;

	private Control control;
	private float timer;

	private PlayerManager manager;

	void Start(){
		manager = gameObject.GetComponentInChildren<PlayerManager>();
		control = gameObject.GetComponentInChildren<Control>();
		health = maxHealth;
		hpDisplayRect = new Rect(20,50,100,20);
	}

	void Respawn(){
		renderer.enabled = true;
		health = maxHealth;
		control.Mobile(true);
	}

	void Death(){
		renderer.enabled = false;
		transform.position = spawnPoint.position;
		transform.rotation = spawnPoint.rotation;
		control.Mobile(false);
		Invoke("Respawn", respawnTime);
	}

	void ApplyDamage(float damage){
		if(!invincible){
			health -= damage;
			invincible = true;
			Invoke("ToggleInvincible", hitInvincibilityTime);
		}
	}

	void applyDamage(float damage){
		ApplyDamage(damage);
	}

	void ToggleInvincible(){
		invincible ^= true;
	}

	void OnGUI(){
		GUI.skin = hpDisplaySkin;
        GUI.Label(hpDisplayRect, "HP:" + health);  
	}

	float Health(){
		return health;
	}

	float Health(float newHealth){
		health = newHealth;
		return health;
	}

	void Update(){
		if(health>maxHealth){
			health = maxHealth;
		}else if(health <= 0){
			Death();
		}
	}
}	
