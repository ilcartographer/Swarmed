using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin mainMenuSkin;
	public float areaWidth;
	public float areaHeight;
	
	
	void OnGUI() {
		GUI.skin = mainMenuSkin;
		
		float ScreenX = (((float)Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = ((Screen.height) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea(new Rect(ScreenX, ScreenY, areaWidth, areaHeight));
		
		if(GUILayout.Button("Play")) {
			Application.LoadLevel(1);	
		}
		
		if(GUILayout.Button("Quit")) {
			Application.Quit();
		}
		
		GUILayout.EndArea();
	}
}
