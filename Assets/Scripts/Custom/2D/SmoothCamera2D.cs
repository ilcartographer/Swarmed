using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
	
	public Transform wall;
	
    // Update is called once per frame
    void Update () 
    {
       if (target)
       {
         Vector3 point = camera.WorldToViewportPoint(target.position);
         Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(.5f, point.y, point.z)); //(new Vector3(0.5, 0.5, point.z));
         if(delta.x > 0){
			Vector3 destination = transform.position + delta;
         	transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
				
			Vector3 wall_destination = wall.position + delta;
         	wall.position = Vector3.SmoothDamp(wall.position, wall_destination, ref velocity, dampTime);
		 }
       }

    }
}