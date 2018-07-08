using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
	static Animator anim;

    public float vida = 100;
	public float speed = 20.0F;
	public float rotationSpeed = 100.0F;
    private bool isDead;
    public Transform respawn;
    private bool hasFlash;
    //hud variables
    public Bonus elbono;
    //Jump Variables

    public float jumpForce = 2.0F;
	public Vector3 jumpVector;
	public bool isGrounded;
	Rigidbody rb;

    public Vida vida1;

    private string power;

    public SlowMotionEffect slowTime;

	
	// Use this for initialization
	void Start () 
	{
        power = "None";
        hasFlash = true;
        isDead = false;
		anim= GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		jumpVector = new Vector3(0.0F,2.0F,0.0F);
    }
	
	void OnCollisionStay(){
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        //update bono hud
        if (Input.GetMouseButtonDown(0) && elbono.activo == true)
        {

            elbono.activo = false;
            power = elbono.img;
            Debug.Log(power);
        }
        //

        float translation = Input.GetAxis("Vertical") * speed;
		float straffe = Input.GetAxis("Horizontal") * speed;
		translation*=Time.deltaTime;
		straffe*=Time.deltaTime;
		
		transform.Translate(straffe,0,translation);
        if (power == "luz" && Input.GetButtonDown("Fire3") && hasFlash) {
            transform.position += new Vector3(0, 0, 10);
            //hasFlash = false;
        }
        if (power == "rel") {
            slowTime.activo = true;
        }
        if (power == "cal") {
            //vida1.TakeDamage(100f);
            death();
            power = "";
        }
        
		if(Input.GetButtonDown("Jump") && isGrounded){
			rb.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
			anim.SetTrigger("isJumping");
			isGrounded=false;
		}
		if(translation!=0 || straffe!=0){
			anim.SetBool("isRunning",true);
			anim.SetBool("isIdle",false);
		}
		else{
			anim.SetBool("isRunning",false);
			anim.SetBool("isIdle",true);
		}

		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Killzone" && !isDead)
        {
            death();
        }
    
    }

    //coger el bono
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("poder"))
        {
            if (slowTime.activo == true) {
                Debug.Log("SLOW TIMEEE");
                slowTime.activo = false;
            }
            other.gameObject.SetActive(false);
            elbono.activo = true;
        }
    }

    void death() {
        this.transform.position = respawn.position;
    }
}
