using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Transform movingPlat;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;

    public string currentState;
    public float smooth;
    public float resetTime;
	// Use this for initialization
	void Start () {
        //newPosition = position1.position;
        ChangeTarget();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        movingPlat.position = Vector3.Lerp(movingPlat.position, newPosition, smooth * Time.deltaTime);
        
        /*if (movingPlat.position.x - newPosition.x < 0.5) {
            Debug.Log("entraaaaaa");
            
            ChangeTarget();
        }*/
        //ChangeTarget();
	}

    void ChangeTarget() {
        if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }
        else if (currentState == "") {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
}
