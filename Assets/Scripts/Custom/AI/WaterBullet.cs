using UnityEngine;
using System.Collections;

public class WaterBullet : MonoBehaviour {
	public float speed = .1f;
	public Vector3 direction = new Vector3(1, 0, 0);
	public float lifeSpan = 2.0f;
	public float maxDistance = 10.0f;
	public int damage = 1;
	
	private Transform bullet;
	private float spawnTime;
	private float currentDistanceTravelled = 0.0f; 
	private bool hasHitPlayer = false;
	
	void OnEnable() {
		bullet = transform;
		spawnTime = Time.time;
	}
	
	void Update () {
		// Move the bullet in the specified direction by the total
		// distance (speed * time)
		currentDistanceTravelled += speed;
		bullet.Translate(direction * speed * Time.deltaTime);
		
		if(Time.time >= lifeSpan + spawnTime) {
			Destroy(gameObject);	
		}
	}
	
	void OnTriggerEnter(Collider collision) {
		BulletCollide(collision);
	}
	
	void BulletCollide(Collider collision) {
		// If the collision is with the player, inform the player script
		// with how much damage to deal
		if(collision.transform.CompareTag("Enemy") && !hasHitPlayer) {
			collision.gameObject.SendMessage("DoDamage", damage, SendMessageOptions.RequireReceiver);
			hasHitPlayer = true;
			Destroy(gameObject);
			
		}
		
		//if(!collision.transform.CompareTag ("Collectable"))
		//	Destroy(gameObject);
	}
	
	// On a player collision, damage the player
	void PlayerCollision(GameObject player) {
		player.SendMessage ("DoDamage", damage);
		hasHitPlayer = true;
	}
	
	
}
