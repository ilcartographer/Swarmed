using UnityEngine;
using System.Collections;

public class Watergun : MonoBehaviour {
	WatergunManager manager;
	
	const int PARTS_NEEDED = 4;	
	
	const int MAX_AMMO = 3;
	
	public GUITexture gunTexture;
	public GUITexture[] ammoTextures = new GUITexture[MAX_AMMO]; // represent each indicator
	
	int ammoCount = MAX_AMMO;
	bool isEnabled = true;
	bool isFireKeyPressed = false;
	
	public WaterBullet bullet;
	public float bulletSpeed = 10f;
	
	const float MIN_ROTATION = -60.0f;
	const float MAX_ROTATION = 60.0f;
	const float ROTATION_SPEED = 120.0f;
	
	void Start() {
		
		manager = GameObject.Find("Watergun Manager").GetComponent<WatergunManager>();
		if(manager) {
			if(manager.getPartsObtained() == PARTS_NEEDED) {
				gameObject.renderer.enabled = true;
				gunTexture.enabled = true;
				foreach(GUITexture texture in ammoTextures)
					texture.enabled = true;		
				
				isEnabled = true;
			} else {
				gameObject.active = false;	
			}
		} else {
			isEnabled = false;
			gameObject.active = false;	
		}
	}
	
	// If the gun is enabled, allow the player to fire the gun
	void Update () {		
		if(isEnabled) {
			// Check for aiming key presses
			if(Input.GetAxis("Vertical") < 0) {
				transform.Rotate(-1 * ROTATION_SPEED * Time.deltaTime, 0, 0);
			} else if(Input.GetAxis("Vertical") > 0) {
				transform.Rotate(ROTATION_SPEED * Time.deltaTime, 0, 0);
			}
			
			// Check if fire was pressed and not being held
			if(ammoCount > 0) {
				if(Input.GetAxis("Shoot") != 0 && !isFireKeyPressed) {
					FireBullet();
					isFireKeyPressed = true;
					ammoTextures[--ammoCount].enabled = false;
				}
				if(Input.GetAxis("Shoot") == 0)
					isFireKeyPressed = false;
			} else {
				gunTexture.enabled = false;
				gameObject.active = false;	
			}
				
			
		}
	}
	
	void FireBullet() {
		// Get the direction to fire the bullet
		Vector3 bulletDirection = transform.up;
		
		// Create a new bullet to be fired
		WaterBullet newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as WaterBullet;
		
		// Normalize so a speed can be applied more easily
		bulletDirection.Normalize();
		newBullet.direction = bulletDirection;
		newBullet.speed = bulletSpeed;
	}
}
