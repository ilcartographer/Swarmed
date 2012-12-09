using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {
	
	// Draw icon in editor
	void OnDrawGizmos() {
		Gizmos.DrawIcon(transform.position, "Actions-arrow-right-end-icon.png");
	}
}
