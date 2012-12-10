using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour {
	// used for determining what the AI should do
	enum AIStates { MOVING_LEFT, MOVING_RIGHT, SWOOPING_DOWN, SWOOPING_UP };
	AIStates currentState;
	AIStates lastState; // will hold the last state before swooping
	
	// Bee info
	public const int MAX_HEALTH = 3;
	int currentHealth; // number of hits needed to kill the bee
	
	public float moveSpeed = 10.0f;
	
	float timeSinceLastHit = 0.0f;
	
	// Info for allowing the bee to swoop
	Vector3 swoopCenter;
	Vector3 startPosition;
	Vector3 startSwoop;
	Vector3 endPosition;
	Vector3 endSwoop;
	float swoopTime = 0.0f;
	
	// GUI elements
	const float MAX_BAR_WIDTH = 295.4f;
	public GUITexture beeHealthBarFill;
	Rect _pixelInset;
	public Transform player;
	
	public Texture2D[] beeTextures = new Texture2D[3];
		
	// Use this for initialization
	void Start () {
		currentHealth = MAX_HEALTH;
		_pixelInset = beeHealthBarFill.pixelInset;
		currentState = AIStates.MOVING_RIGHT;
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentState) {
			
		case AIStates.MOVING_RIGHT:
			transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0), Space.World);
			
			if(transform.position.x - player.position.x > 5)
				currentState = AIStates.MOVING_LEFT;
			
			break;
			
		case AIStates.MOVING_LEFT:
			transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0), Space.World);
			
			if(transform.position.x - player.position.x < -5) {
				// Set up the swoop info
				startPosition = transform.position;
				endPosition = player.transform.position;
				swoopCenter = player.transform.position;
				swoopCenter.y = transform.position.y; // above the player at the bee's level
				
				startSwoop = startPosition - swoopCenter;
				endSwoop = endPosition - swoopCenter;				
				
				currentState = AIStates.SWOOPING_DOWN;
			}
			
			break;
			
		case AIStates.SWOOPING_DOWN:
			swoopTime += Time.deltaTime;
			transform.position = Vector3.Slerp(startSwoop, endSwoop, swoopTime * 2);
			transform.position += swoopCenter;
			if(swoopTime > 0.5f) {
				swoopTime = 0.0f;
				
				// Calculate second half of swoop
				Vector3 temp = startPosition;
				startPosition = endPosition;
				endPosition = temp + new Vector3(10, 0, 0);
				
				startSwoop = startPosition - swoopCenter;
				endSwoop = endPosition - swoopCenter;
				
				currentState = AIStates.SWOOPING_UP;
			}
			
			break;
			
		case AIStates.SWOOPING_UP:
			swoopTime += Time.deltaTime;
			transform.position = Vector3.Slerp(startSwoop, endSwoop, swoopTime * 2);
			transform.position += swoopCenter;
			if(swoopTime > 0.5f) {
				swoopTime = 0.0f;
				
				currentState = AIStates.MOVING_LEFT;
			}
			
			break;
		default:
			break;
			
		}
		
		
		switch(currentHealth) {
		case 3:
			transform.Find("MeanBee").renderer.material.mainTexture = beeTextures[0];
			break;
		case 2:
			transform.Find("MeanBee").renderer.material.mainTexture = beeTextures[1];
			break;
		case 1:
			transform.Find("MeanBee").renderer.material.mainTexture = beeTextures[2];
			break;
		default:
			// Empty the bar, then destroy the Bee object
			Destroy(beeHealthBarFill);
			Destroy(gameObject);
			break;
			
		}
	
	}
	
	void OnTriggerEnter(Collider coll) {
		CharacterController player = coll.transform.root.gameObject.GetComponent<CharacterController>();
		if(player) {
			// We'll consider it a valid hit if the following conditions are met: 
			// 1. It has been more than 1s since the last hit
			// 2. The player is moving downwards
			// 3. The player's center is above the bee's center
			ImpactReceiver ir = coll.transform.root.gameObject.GetComponent<ImpactReceiver>();
			if (ir) {
				if(Time.time - timeSinceLastHit >= 1.0f 
					&& player.velocity.y < 0 
					&& player.transform.position.y > gameObject.transform.position.y) {
					--currentHealth;
					timeSinceLastHit = Time.time;
				}
				
				// A reflection vector will be equal to:
				// Surface Normal + (Surface Normal + (-1 * Incoming Vector))
				Vector3 beeNormal = new Vector3(0, 1, 0);
				if(player.transform.position.y < gameObject.transform.position.y) beeNormal.y *= -1;
				
				Vector3 impactVector = beeNormal + (beeNormal - player.velocity.normalized);
				print(impactVector);
				ir.AddImpact(impactVector, 50);
			}
		}
	}
	
	void OnGUI() {
		Rect newInset = _pixelInset;
		newInset.width = MAX_BAR_WIDTH * (float)currentHealth / (float)MAX_HEALTH;
		beeHealthBarFill.pixelInset = newInset;
	}
	
	void DoDamage(int damage) {
		currentHealth -= damage;	
	}
}
