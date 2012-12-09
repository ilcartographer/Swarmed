using UnityEngine;
using System.Collections;

public class StartPoint : MonoBehaviour {

	// Draw icon in editor
	void OnDrawGizmos() {
		Gizmos.DrawIcon(transform.position, "Start-Sign-32.png");	
	}
}
