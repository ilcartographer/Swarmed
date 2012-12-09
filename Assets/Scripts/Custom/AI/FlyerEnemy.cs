using UnityEngine;
using System.Collections;

public class FlyerEnemy : MonoBehaviour {
	public float speed = 6.0f;
	public int damage = 20;
	bool hasBeenSeen = false;
	
	// The flyer doesn't do anything until it comes into view.
	// When it does, it flies straight across the screen
	void Update () {
		if(hasBeenSeen)
			gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
	}
	
	void OnBecameVisible() {
		hasBeenSeen = true;	
	}
	
	void OnBecameInvisible() {
		if(hasBeenSeen)
			Destroy (gameObject);	
	}
	
	void OnTriggerEnter(Collider collision) {
		BulletCollide(collision);
	}
	
	void OnTriggerStay(Collider collision) {
		BulletCollide(collision);
	}
	
	void BulletCollide(Collider collision) {
		// If the collision is with the player, inform the player script
		// with how much damage to deal
		if(collision.transform.CompareTag("Player")) {
			collision.gameObject.SendMessage("DoDamage", damage);
		}
		
		if(!(collision.transform.CompareTag ("Collectable") || collision.transform.CompareTag("Bullet")))
			Destroy(gameObject);
	}
}
