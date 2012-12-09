using UnityEngine;
using System.Collections;

public class GunPickup : MonoBehaviour {
	public WatergunManager gun;

	// When the player collects the pickup,
	// notify the WatergunManager
	void OnTriggerEnter(Collider collision) {
		if(collision.transform.CompareTag("Player")) {
			gun.addPart();
			Destroy(gameObject);
		}		
	}
}