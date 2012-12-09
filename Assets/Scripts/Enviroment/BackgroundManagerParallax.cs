using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {
	
	public float velocity;
	public Transform target;
	
	private Transform tracker;
	private Transform backgroundManager;
	
	// Use this for initialization
	void Awake () {
		Transform tracker = transform.Find("Tracker");
		
		tracker.position = new Vector3(target.position.x, tracker.position.y, tracker.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!target)
      		return;
		
		Transform backgroundManager = transform;
		Transform tracker = transform.Find("Tracker");
		
		Vector3 delta = tracker.position - target.position;
		tracker.position = target.position;
		
		if(delta.x != 0){
			if(delta.x > 0) {
				Transform near = backgroundManager.Find("Near");
				Transform far = backgroundManager.Find("Far");
				near.Translate(new Vector3(velocity * Time.deltaTime, 0f, 0f));
				far.Translate(new Vector3(velocity * Time.deltaTime, 0f, 0f));
			} else if(delta.x < 0) {
				Transform near = backgroundManager.Find("Near");
				Transform far = backgroundManager.Find("Far");
				near.Translate(new Vector3(-1 * velocity * Time.deltaTime, 0f, 0f));
				far.Translate(new Vector3(-1 * velocity * Time.deltaTime, 0f, 0f));
			}
		}
	}
}

/*Vector3 delta = target.position - gameObject.transform.position;
		 if (delta.x != 0){
	         Vector3 destination = transform.position + new Vector3(delta.x * velocity, 0.0f, 0.0f);
	         gameObject.transform.position += destination;
			 
		 }
*/