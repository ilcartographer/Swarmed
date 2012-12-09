using UnityEngine;
using System.Collections;

public static class Helper {
	
	public static bool ParentHasTag(string tagToFind, Transform childObject) {
		if(childObject.tag == "Player")
			return true;
		
		Transform tempObject = childObject;
		while(tempObject.parent) {
			tempObject = tempObject.parent.transform;
			
			if(tempObject.tag == "Player")
				return true;
			
		}
		
		if(tempObject.tag == "Player")
			return true;
		
		return false;
		
	}
}