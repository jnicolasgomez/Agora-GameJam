using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCollision : MonoBehaviour {


	public float minDistance=1.0F;
	public float maxDistance= 4.0F;
	public float smooth=10.0F;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;
	public float distance;
	
	// Use this for initialization
	void Awake() {
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir* maxDistance);
		RaycastHit hit;
		
		if(Physics.Linecast(transform.parent.position, desiredCameraPos, out hit)){
			distance= Mathf.Clamp((hit.distance*0.8F),minDistance,maxDistance);
		}
		else{
			distance=maxDistance;
		}
		transform.localPosition = Vector3.Lerp(transform.localPosition,dollyDir*distance, Time.deltaTime*smooth);
	}
}
