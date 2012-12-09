using UnityEngine;
using System.Collections;

public class GenericPickup : MonoBehaviour {
	
	public Transform player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(player.position.x > transform.position.x)
			Destroy (this.gameObject);
	}
}
