using UnityEngine;
using System.Collections;

public class GunPickup : MonoBehaviour {
	public WatergunManager gun;
		
	void OnTriggerEnter(Collider collision) {
		if(collision.transform.CompareTag("Player")) {
			gun.addPart();
			Destroy(gameObject);
		}		
	}
}
