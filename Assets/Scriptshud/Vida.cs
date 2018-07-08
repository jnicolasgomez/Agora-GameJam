
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Vida:MonoBehaviour {
	public Image currentHealth;
	public Image espuma; 

	private float hitpoint =97.5f;
	private float maxHitpoint = 100;
	public float espacioespuma=0.025f;


	private void Start(){
		UpdateHealth();



	}


	private void UpdateHealth(){
		float ratio=hitpoint/maxHitpoint;
		currentHealth.fillAmount = ratio;
		espuma.fillAmount = ratio+espacioespuma;
	}

	public void TakeDamage(float damage){
		hitpoint-=damage;
		UpdateHealth();
		if (hitpoint<0){
			hitpoint=0;
		}


	}

    public void restartHeatlth() {
        hitpoint = 97.5f;
        maxHitpoint = 100;
        espacioespuma = 0.025f;
        UpdateHealth();
}
}