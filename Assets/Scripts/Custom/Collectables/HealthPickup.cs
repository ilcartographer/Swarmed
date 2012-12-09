using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
	public float rotationSpeed = 240.0f;
	public bool rotateOn;
	
	// Making public allows this to be attached to larger/smaller health packs
	public int healthValue = 20;
	public int scoreValue = 10;
	
	void Update () {
		if(rotateOn)
        	transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
	}
	
	void OnTriggerEnter(Collider collision) {
		// If a player collides with the pick up, heal him and increase the score
		if(collision.transform.CompareTag("Player")) {
			collision.gameObject.SendMessage("HealPlayer", healthValue);
			collision.gameObject.SendMessage("AddScore", scoreValue);
			
			Destroy(gameObject);
		}		
	}
}
