using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionEffect : MonoBehaviour {

    public float frozenTime;
    public float timeUnfrozen;
    public bool activo;
	// Use this for initialization
	void Start () {
        activo = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (activo == true)
        {
            if (!Input.anyKey)
            {
                Time.timeScale = frozenTime;

            }
            else
            {
                Time.timeScale = timeUnfrozen;
            }
        }
        else {
            Time.timeScale = 1;
        }
            
    }


}
