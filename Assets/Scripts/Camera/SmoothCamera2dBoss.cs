using UnityEngine;
using System.Collections;

public class SmoothCamera2dBoss : MonoBehaviour {

    public float dampTime = 0.15f;
    public Transform target;
	public Transform rightBound;
	public Transform leftBound;
	public bool forwardOnly;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 rightCameraBound = Vector3.zero;
	private Vector3 leftCameraBound = Vector3.zero;
	private Vector3 cameraDistanceToLeftBound = Vector3.zero;
	
	void Start (){
		//We need to position the camera so that it's at the edge of the left most bound. The camera will then track the target from there.
		//To start we must see how far the bounds are from the camera so we can set the z value properly when using ViewportToWorldPoint.
		//Below, both values for cameraDistanceToRightBound and LeftBound should be about the same. I could have probably just chosen
		//one and gone with that but I decided to check both.
		Vector3 cameraDistanceToRightBound = transform.position - rightBound.position;
		cameraDistanceToLeftBound = transform.position - leftBound.position;
		
		//Now get the left and right edge of the camera on the plane created by the leftBound and rightBound.
		Vector3 rightCameraEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, Mathf.Abs(cameraDistanceToRightBound.z)));
		Vector3 leftCameraEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, Mathf.Abs(cameraDistanceToLeftBound.z)));
		
		//We need the width of the camera in world parameters so we can properly place the camera bounds in the camera movement plane.
		Vector3 worldCameraWidth = rightCameraEdge - leftCameraEdge;
		
		//if you created a sphere at rightCameraBound and leftCameraBound you would see it was in the xy plane of the camera location.
		rightCameraBound = new Vector3(rightBound.position.x - worldCameraWidth.x/2, transform.position.y, transform.position.z);
		leftCameraBound = new Vector3(leftBound.position.x + worldCameraWidth.x/2, transform.position.y, transform.position.z);
		
		transform.position = leftCameraBound;
	}
	
    // Update is called once per frame
    void LateUpdate (){
		if (target){
			Vector3 targetViewportPosition = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(.5f, targetViewportPosition.y, targetViewportPosition.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3	cameraDesination = new Vector3(delta.x + transform.position.x, transform.position.y,transform.position.z);
			
			if (Mathf.Abs(delta.x) > 0){
				if(cameraDesination.x >= leftCameraBound.x && cameraDesination.x <= rightCameraBound.x){
					transform.position = Vector3.SmoothDamp(transform.position, cameraDesination, ref velocity, dampTime);
				}
				else if(cameraDesination.x < leftCameraBound.x){			
					transform.position = Vector3.SmoothDamp(transform.position, leftCameraBound, ref velocity, dampTime);
				}
				else if(cameraDesination.x > rightCameraBound.x){
					transform.position = Vector3.SmoothDamp(transform.position, rightCameraBound, ref velocity, dampTime);
				}
				
				//Test if forward is toggled.
				if (forwardOnly == true && delta.x > 0f){
					Vector3 leftCameraEdge2 = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,Mathf.Abs(cameraDistanceToLeftBound.z)));
					float newLeftBoundX = leftCameraEdge2.x;
					leftBound.position = new Vector3(newLeftBoundX, leftBound.position.y, leftBound.position.z);
					leftCameraBound = new Vector3(newLeftBoundX, leftCameraBound.y, leftCameraBound.z);
				}
			}
    	}
	}
}