using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour {
	// max time we're going to track
	private const int MAX_TIME = 60 * 20; // 20 minutes
	private int secondsInLevel;
	private float timeSinceLastUpdate;
	
	// Initialize member variables
	void Start () {
		secondsInLevel = 0;
		timeSinceLastUpdate = -1.0f;
	
	}
	
	void Update () {
		if(Time.time > timeSinceLastUpdate + 1) {
			++secondsInLevel;
			if(secondsInLevel > MAX_TIME) secondsInLevel = MAX_TIME;
			timeSinceLastUpdate = Time.time;
		}
	}
	
	public string secondsToString() {
		int minutes = secondsInLevel / 60;
		int seconds = secondsInLevel % 60;
		
		return minutes.ToString("D2") + ":" + seconds.ToString("D2");
	}
}
