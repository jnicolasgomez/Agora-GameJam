			using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public float CameraMoveSpeed = 120.0f;
	public GameObject CameraFollowObj;
	public float clampAngle = 80.0f;
	public float mouseSensitivity= 150.0f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
	public float finalInputX;
	public float finalInputZ;
	public float smoothX;
	public float smoothY;
	public float rotX= 0.0f;
	public float rotY= 0.0f;
	Vector3 followPOS;
	
	
	

	// Use this for initialization
	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotX=rot.x;
		rotY=rot.y;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		float inputX = Input.GetAxis("RightStickHorizontal");
		float inputZ= Input.GetAxis("RightStickVertical");
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");
		finalInputX = inputX + mouseX;
		finalInputZ = inputZ + mouseY;
		
		
		rotY += finalInputX * mouseSensitivity * Time.deltaTime;
		rotX += finalInputZ * mouseSensitivity * Time.deltaTime;
		
		rotX = Mathf.Clamp(rotX,-clampAngle,clampAngle);
		Quaternion localRotation= Quaternion.Euler(rotX,rotY,0.0f);
		transform.rotation=localRotation;
	}
	
	void LateUpdate(){
		CameraUpdater();
	}
	void CameraUpdater(){
		Transform target = CameraFollowObj.transform;
		
		float step = CameraMoveSpeed *Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
