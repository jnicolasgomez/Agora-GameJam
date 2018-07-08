using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionEffect : MonoBehaviour {

    public float frozenTime;
    public float timeUnfrozen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.anyKey)
        {
            Time.timeScale = frozenTime;

        }
        else {
            Time.timeScale = timeUnfrozen;
        }
	}
}
