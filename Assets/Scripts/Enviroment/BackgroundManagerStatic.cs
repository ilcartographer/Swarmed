using UnityEngine;
using System.Collections;

/*This script will make the assigned object follow the camera*/

public class BackgroundManagerStatic : MonoBehaviour {
	
	public Transform target;
	
	private Transform background;
	
	// Use this for initialization
	void Start () {
		background = transform;
	}
	
	// Update is called once per frame
	void Update () {	
		transform.position = new Vector3 (target.position.x, transform.position.y, transform.position.z);
	}
}
