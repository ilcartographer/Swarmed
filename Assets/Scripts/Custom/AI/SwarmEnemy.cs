using UnityEngine;
using System.Collections;

public class SwarmEnemy : MonoBehaviour {
	public GameObject player;
	Transform centralEnemy;
	
	public float moveSpeed = 4.0f;
	public float rotationSpeed = 240.0f;
	public float chaseDistance = 2.0f;
	
	void Start () {
		centralEnemy = transform;
	}
	
	void Update () {
		centralEnemy.Rotate(0.0f, 0.0f, -1 * rotationSpeed * Time.deltaTime);
		
		Vector3 movementVector = player.transform.position - centralEnemy.position;
		if(movementVector.magnitude >= chaseDistance) {
			movementVector.Normalize();
			centralEnemy.Translate(movementVector * moveSpeed * Time.deltaTime, Space.World);
		}
		
	}
}
