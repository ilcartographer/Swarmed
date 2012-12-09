using UnityEngine;
using System.Collections;

// Borrowed from http://answers.unity3d.com/questions/242648/force-on-character-controller-knockback.html
// Purpose of this script is to add a force to the player, since CharacterControllers
// do not have physics applied to them

public class ImpactReceiver : MonoBehaviour {
	public float mass = 3.0f; // character's mass
	Vector3 impact = Vector3.zero;
	CharacterController character;
	
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}
	
	public void AddImpact(Vector3 direction, float force) {
		direction.Normalize();
		
		if(direction.y < 0) direction.y = -direction.y;
		print("direction: " + direction);
		impact += direction.normalized * force / mass;
	}
	
	// Update is called once per frame
	void Update () {
		// apply the force
		if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);
		
		impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
	}
}
