using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class control : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	//public Healthbar health;
	public Vida vida1;
	public Bonus elbono;
    
	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
		winText.text = "";
        
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speed);
		if (Input.GetMouseButtonDown (0) && elbono.activo == true) {
			elbono.activo = false;
            
		}

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive (false);
			count =count+ 1;
			SetCountText();
			//health.TakeDamage (10f);
			vida1.TakeDamage (10f);
			elbono.activo = true;

		}
	}
	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) {
			winText.text = "GANASTE!";
		}
	}


	 
}
