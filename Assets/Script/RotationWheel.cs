using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWheel : MonoBehaviour {

    public float speed = 50.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}
}
