using UnityEngine;
using System.Collections;

public class Watergun : MonoBehaviour {
	WatergunManager manager;
	
	const int PARTS_NEEDED = 4;	
	
	const int MAX_AMMO = 3;
	
	public GUITexture gunTexture;
	public GUITexture[] ammoTextures = new GUITexture[MAX_AMMO]; // represent each indicator
	
	int ammoCount = MAX_AMMO;
	bool isEnabled = false;
	bool isKeyPressed = false;
	
	void Start() {
		manager = GameObject.Find("Watergun Manager").GetComponent<WatergunManager>();
		if(manager) {
			if(manager.getPartsObtained() == PARTS_NEEDED) {
				gameObject.renderer.enabled = true;
				gunTexture.enabled = true;
				foreach(GUITexture texture in ammoTextures)
					texture.enabled = true;		
				
				isEnabled = true;
			} else {
				gameObject.active = false;	
			}
		} else {
			gameObject.active = false;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(isEnabled) {
			if(Input.GetAxis("Shoot") != 0 && !isKeyPressed) {
				isKeyPressed = true;
				ammoTextures[--ammoCount].enabled = false;	
			}
			
			if(Input.GetAxis("Shoot") == 0)
				isKeyPressed = false;
		}
	}
	
}
