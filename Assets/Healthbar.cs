using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Healthbar:MonoBehaviour {
	public Image currentHealthbar;
	public Text ratioText;
	private float hitpoint =100;
	private float maxHitpoint = 100;


	private void Start(){
		UpdateHealthbar();



	}


	private void UpdateHealthbar(){
		float ratio=hitpoint/maxHitpoint;
		currentHealthbar.rectTransform.localScale= new Vector3(ratio,1,1);
		ratioText.text= (ratio*100).ToString() + '%';

	}

	public void TakeDamage(float damage){
		hitpoint-=damage;
		UpdateHealthbar();
		if (hitpoint<0){
			hitpoint=0;
		}


	}
}