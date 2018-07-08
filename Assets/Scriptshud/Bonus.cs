using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bonus : MonoBehaviour {
	public GameObject calavera;
	public GameObject alas;
	public GameObject reloj;
    public GameObject lobo;
    public bool activo;
	public string img;
	public float timer = 1f;
	public float delay = 1f;
	void Start(){
		calavera.SetActive (true);
		alas.SetActive (false);
		reloj.SetActive (false);
        lobo.SetActive(false);
		img = "cal";
		activo=false;
	}
	void Update(){
		if (activo == true) {

		timer -= Time.deltaTime;
		if (timer <= 0) {
			if (img=="cal") {
				calavera.SetActive (false);
				alas.SetActive (true);
				img = "alas";
				timer = delay;
				return;

			}
			if (img=="alas") {
				alas.SetActive (false);
				reloj.SetActive (true);
				img = "rel";
				timer = delay;
				return;

			}
			if (img=="rel") {
				reloj.SetActive (false);
				lobo.SetActive (true);
				img = "lobo";
				timer = delay;
				return;
			}
                if (img == "lobo")
                {
                    lobo.SetActive(false);
                    calavera.SetActive(true);
                    img = "cal";
                    timer = delay;
                    return;
                }
            }
		}

	}

}
