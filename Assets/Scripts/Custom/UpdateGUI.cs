using UnityEngine;
using System.Collections;

public class UpdateGUI : MonoBehaviour {
	public GUIText playerScore;
	
	public Texture2D[] healthTextures = new Texture2D[5];
	public GUITexture healthIndicator;
	
	public PlayerStatus playerStatus; 
	
	public CharacterController playerController;
	
	public LevelTimer levelTimer;
	public GUIText timerText;
	
	void OnGUI () {
		// Update player health & score
		playerScore.text = "Score: " + playerStatus.GetScore();
		
		//TODO: expose start health and use percentages?
		if(playerStatus.GetHealth() >= 90) {
			healthIndicator.texture = healthTextures[0];
		} else if(playerStatus.GetHealth() >= 60) {
			healthIndicator.texture = healthTextures[1];
		} else if(playerStatus.GetHealth() >= 30) {
			healthIndicator.texture = healthTextures[2];
		} else if(playerStatus.GetHealth() > 0) {
			healthIndicator.texture = healthTextures[3];
		} else {
			healthIndicator.texture = healthTextures[4];
		}
			
		// Update level timer
		timerText.text = levelTimer.secondsToString();
	}
}
