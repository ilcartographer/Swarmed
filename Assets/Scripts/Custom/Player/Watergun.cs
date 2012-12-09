using UnityEngine;
using System.Collections;

public class Watergun : MonoBehaviour {
	const int MAX_AMMO = 3;
	
	public GUITexture gunTexture;
	public GUITexture[] ammoTextures = new GUITexture[MAX_AMMO]; // represent each indicator
	
	int ammoCount = MAX_AMMO;
	bool isKeyPressed = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Shoot") != 0 && !isKeyPressed) {
			isKeyPressed = true;
			ammoTextures[--ammoCount].enabled = false;	
		}
		
		if(Input.GetAxis("Shoot") == 0)
			isKeyPressed = false;
	}
}
