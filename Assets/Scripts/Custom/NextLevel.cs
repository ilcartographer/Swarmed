using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	void OnTriggerEnter(Collider collision) {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
