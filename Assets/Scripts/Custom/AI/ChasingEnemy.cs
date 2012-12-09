using UnityEngine;
using System.Collections;

public class ChasingEnemy : MonoBehaviour {
	public Transform playerModel;
	Transform currentEnemy;
	Transform muzzle;

	public float moveSpeed = 10.0f;
	public float rotationSpeed = 3.0f;

	void Awake() {
		currentEnemy = transform;	
		muzzle = currentEnemy.Find("Muzzle");
	}


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		// Get direction and magnitude to move the enemy
		Vector3 directionToMove = new Vector3(0, 0, 0);
		if(playerModel.position.x - currentEnemy.position.x > 5) {
			directionToMove = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
		} else if(playerModel.position.x - currentEnemy.position.x < -5) {
			directionToMove = new Vector3(-1 * moveSpeed * Time.deltaTime, 0f, 0f);
		}
		
		// Move the enemy
		currentEnemy.Translate(directionToMove, null);
		
		
		// Rotate the muzzle to point towards the player
		muzzle.rotation *= Quaternion.FromToRotation(muzzle.up, muzzle.position - playerModel.position);
	}
}