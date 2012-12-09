using UnityEngine;
using System.Collections;

public class WatergunManager : MonoBehaviour {
	int partsObtained = 0;

	void Awake() {
		DontDestroyOnLoad(gameObject);	
	}

	public void addPart() {
		++partsObtained;	
	}

	public int getPartsObtained() {
		return partsObtained;	
	}
}