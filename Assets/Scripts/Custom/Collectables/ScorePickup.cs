using UnityEngine;
using System.Collections;

public class ScorePickup : MonoBehaviour {
	public int scoreValue = 5;
	
	void OnTriggerEnter(Collider collision) {
		// If a player collides with the object, add to his score value
		if(collision.transform.CompareTag("Player")) {
			collision.gameObject.SendMessage("AddScore", scoreValue);
			Destroy(gameObject);
		}		
	}
}
