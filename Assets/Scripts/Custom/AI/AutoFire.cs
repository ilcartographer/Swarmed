using UnityEngine;
using System.Collections;

// Based on AutoFire.cs from AngryBots demo
public class AutoFire : MonoBehaviour {
	public CharacterController player;
	
	Transform muzzle;
	
	public BasicBullet bullet;
	public float fireFrequency = .5f; // how many per second
	public float bulletSpeed = 10f;
	
	private bool isFiring = true;
	private float lastFireTime = -1.0f;
		
	// Use this for initialization
	void Start () {
		muzzle = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFiring) {
			if(Time.time > lastFireTime + 1 / fireFrequency ) {
				FireBullet();
				
				lastFireTime = Time.time;
			}
		}
	}
	
	void DisableFire() {
		isFiring = false;
		foreach(GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
		{
		    Destroy(bullet);
		}
	}
	
	void FireBullet() {
		// Get the direction to fire the bullet
		Vector3 playerCenter = player.transform.position + player.center * 2;
		Vector3 bulletDirection = playerCenter - muzzle.position;
		
		// Create a new bullet to be fired
		BasicBullet newBullet = Instantiate(bullet, muzzle.position, Quaternion.identity) as BasicBullet;
		
		// Bullet needs to ignore other parts of the enemy
		//Physics.IgnoreCollision(newBullet.collider, muzzle.collider);
		//Physics.IgnoreCollision(newBullet.collider, muzzle.parent.transform.collider);
		Physics.IgnoreCollision(newBullet.collider, transform.parent.collider);
		
		// Normalize so a speed can be applied more easily
		bulletDirection.Normalize();
		newBullet.direction = bulletDirection;
		newBullet.speed = bulletSpeed;
	}
}
