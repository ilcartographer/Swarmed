using UnityEngine;

using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public static readonly int START_HEALTH = 100;
	public readonly int MAX_HEALTH = 200;
	
	int currentHealth = START_HEALTH;
	int currentScore  = 0;
	bool isDying = false;
		
	void Start() {
		//TODO: Add death animation	
	}
	
	void Update () {
		//TODO: Player will "swell up" as he gets low
		// Max scale is 1.5x (tenative)
		if(!isDying) {
			if(currentHealth < START_HEALTH) {
				//TODO: scale player
				
			}
			if(currentHealth <= 0) {
				isDying = true;
				gameObject.SendMessage ("SetControllable", false);
				GameObject.Find("Muzzle").SendMessage ("DisableFire", false);
				Application.LoadLevel("GameOverScreen");
			}
		}
	}
	
	public int GetHealth() {
		return currentHealth;
	}
	
	public int GetScore() {
		return currentScore;
	}
	
	public void HealPlayer(int healthToGive) {
		currentHealth += healthToGive;
		if(currentHealth > MAX_HEALTH)
			currentHealth = MAX_HEALTH;		
	}
	
	public void DoDamage(int damageToDeal) {
		currentHealth -= damageToDeal;	
		if(currentHealth < 0)
			currentHealth = 0;
	}
	
	public void AddScore(int scoreToAdd) {
		currentScore += scoreToAdd;
	}
}
