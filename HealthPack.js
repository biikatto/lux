#pragma strict

var healthPack : float = -15f;

function OnTriggerEnter (other : Collider) {
    other.BroadcastMessage("applyDamage", healthPack, SendMessageOptions.DontRequireReceiver);
    Destroy(gameObject);
}
