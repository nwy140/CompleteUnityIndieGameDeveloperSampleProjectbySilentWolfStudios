using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour {
	public int health;
	public GameObject particleeffect;
	SpriteRenderer spriteRenderer;

	public float speed;
	public Sprite Facingup;
	public Sprite FacingDown;
	public Sprite FacingRight;
	public Sprite FacingLeft;

	public  static  int currentHealth;

	public bool iniFrames;

	int direction;
	float timer = 1f;
	public float changetimer=0.2f;
	 public	bool shouldChange;
	// float timer2 = 3f;

	#region Camera
	public AudioClip damage;
//	public Camera camera;
//	public GameObject crab;
	#endregion
	#region destroycrabwitheffects
	void destroycrab()
	{
	if (health<=0)
				{Instantiate(particleeffect,transform.position,transform.rotation);															Destroy(gameObject); }
	}
	#endregion

	// Use this for initialization
	void Start () {
		spriteRenderer=GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = Facingup;
		direction=Random.Range(1,5);
		iniFrames=false;
		shouldChange=false;
	}
	
	// Update is called once per frame
	void Update () {
		Movement();

		timer-=Time.deltaTime;
 		if (timer<=0)
 		{timer=1.5f;
 		direction = Random.Range(1,5);

 		}
 		if(shouldChange) 
 		{changetimer-=Time.deltaTime;
			if (changetimer<=0) 
			{	
				shouldChange=false; changetimer=0.2f;
 			} 
 		}
 													

	}
	void Movement()
 	{
 		if(direction==1)
 		{
 			transform.Translate(0,-speed * Time.deltaTime,0);
 			spriteRenderer.sprite=FacingDown;
 		}
 		else if (direction==2)
		{
 			transform.Translate(-speed * Time.deltaTime,0,0);
 			spriteRenderer.sprite=FacingLeft;
 		}

 		else if (direction==3)
		{
 			transform.Translate(0,+speed * Time.deltaTime,0);
 			spriteRenderer.sprite=Facingup;
 		}
 		else if (direction==4)
		{
 			transform.Translate(+speed * Time.deltaTime,0,0);
 			spriteRenderer.sprite=FacingRight;
 		}

 	}	

 	void OnTriggerEnter2D (Collider2D col)
 	{
 		if (col.gameObject.tag == "Sword") 
 		{
 			health--;
			destroycrab();
 			col.GetComponent<Sword>().CreateParticle();
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanAttack=true; GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanMove=true;
			// timer2-=Time.deltaTime; if(timer<=0){		}
 			Destroy(col.gameObject);

 		}

 	}

 	void OnCollisionEnter2D (Collision2D col)
 	{
 		if (col.gameObject.tag == "Player")
 		{	
	 		
	 		if (!col.gameObject.GetComponent<Player>().iniFrames)
	 			{currentHealth--;
	 				col.gameObject.GetComponent<Player>().currentHealth--;
	 				col.gameObject.GetComponent<Player>().iniFrames = true;
	 			}

 			 AudioSource.PlayClipAtPoint(damage,this.transform.position);
			health--; destroycrab();
 		}

 		if (col.gameObject.tag == "Wall")
 		{
 		if (shouldChange){return;}
 	
 		else if (direction==1){direction=3;}
 		 else if (direction==2) {direction=4;}
 		 else if (direction==3) {direction=1;}
 		 else if (direction==4) {direction=2;}

 		shouldChange=true;
 		}





 	}

 	

}
