using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*
	void OnControllerColliderHit(ControllerColliderHit hit) {
		print ("collision");
		if(hit.gameObject.tag == "Bullet") {
			Destroy(hit.gameObject);
		}
	}
	
	void OnTriggerEnter(Collider hit) {
		print (hit.gameObject.tag);
		if(hit.gameObject.tag == "Bullet") {
			Destroy(hit.gameObject);
		}
	}
	*/
}
