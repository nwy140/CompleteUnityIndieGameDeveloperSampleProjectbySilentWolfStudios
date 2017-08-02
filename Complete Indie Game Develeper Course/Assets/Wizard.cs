using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

	Animator anim;
	public float speed;
	public int dir;
	float dirTimer=1.5f;

	public int health;

	public GameObject deathparticle;


	bool canAttack;
	float attackTimer = 2f;

	public GameObject projectile;
	public float projectilethrust;

	public float changeTimer=0.2f;
	public bool ShouldChange;
	public bool moveawayAI;
	public bool  startdiryes;
	public int startdir;
	public float specialtimer;

	public Transform rewardposition;
	public GameObject potion;

	public bool spawnreward2=false;

	public GameObject BOSER;


	#region Addons
	public AudioClip damage;
	public int offset;

	#endregion




	// Use this for initialization
	void Start () { transform.position = new Vector3 (transform.position.x,transform.position.y, 33f);
		anim=GetComponent<Animator>();
		if(!startdiryes) { dir=Random.Range(1,5);	}
		bool canAttack=false;
		bool ShouldChange = false;

	}
	
	// Update is called once per frame
	void Update () {  if (startdiryes){dir=startdir;} specialtimer-=Time.deltaTime; if(specialtimer<=0){SpecialAttack();SpecialAttack(); specialtimer=.5f;}
		destroydragon();
		dirTimer -=Time.deltaTime;
		if (dirTimer<=0 && !startdiryes)
		{   
			dirTimer =1.5f;
			switch(dir){
				case 2: dir=1; 
					break;
				case 3: dir=2;
					break;
				case 4: dir=3;
					break;
				case 1: dir =4;
					break;
				default: dir=1;
					break;
			}

		}


		Movement(); 
		attackTimer-=Time.deltaTime;
		if(attackTimer<=0)
		{
			attackTimer=2f;
			canAttack=true;
		}
		Attack();

		if (ShouldChange) {changeTimer-=Time.deltaTime; 
		if(changeTimer<=0) {ShouldChange=false;	changeTimer=0.2f;} }
		
	}

	void Attack()
	{
		if (!canAttack)
			return;
		canAttack=false;

		if (dir==1)
		{
			GameObject newProjectile = Instantiate (projectile,transform.position,Quaternion.identity);
			newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.down*projectilethrust+Vector2.down*offset);
		}
		else if (dir==2)
		{
			GameObject newProjectile = Instantiate (projectile,transform.position,Quaternion.identity);
			newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left*projectilethrust+Vector2.left*offset);
		}

		else if (dir==3)
		{
			GameObject newProjectile = Instantiate (projectile,transform.position,Quaternion.identity);
			newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.up*projectilethrust+Vector2.up*offset);
		}

		else if (dir==4)
		{
			GameObject newProjectile = Instantiate (projectile,transform.position,Quaternion.identity);
			newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right*projectilethrust+Vector2.right* offset);
		}
	}


	void Movement()
	{
		if (dir==1)
		{transform.Translate(0,-speed*Time.deltaTime,0); anim.SetInteger("dir",dir);}
		else if (dir ==2)
		{ transform.Translate(-speed*Time.deltaTime,0,0); anim.SetInteger("dir",dir);}
		else if (dir==3)
		{transform.Translate(0,+speed*Time.deltaTime,0); anim.SetInteger("dir",dir);}
		else if (dir==4)
		{transform.Translate(speed*Time.deltaTime,0,0) ; anim.SetInteger("dir",dir)    ; }




	}

	void OnTriggerEnter2D ( Collider2D col ){
	if (col.gameObject.tag == "Sword")
	{

	 	health--;
	 	col.gameObject.GetComponent<Sword>().CreateParticle(); Destroy(col.gameObject);
	 	GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanAttack=true;
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanMove=true;

	}
												}

	void OnCollisionEnter2D (Collision2D col)
 	{
 		if (col.gameObject.tag == "Player")
 		{	
	 		if (!col.gameObject.GetComponent<Player>().iniFrames)
	 			{
	 				col.gameObject.GetComponent<Player>().currentHealth--;
	 				col.gameObject.GetComponent<Player>().iniFrames = true;
	 			}

 			 AudioSource.PlayClipAtPoint(damage,this.transform.position);
			destroydragon();
 		}

 		if (col.gameObject.tag == "Wall")
 		{ if(ShouldChange){return;}
		if(moveawayAI)	
			{ startdiryes=false;
			if (dir==1){dir=3;}
	 		else if (dir==2) {dir=4;}
	 		else if (dir==3) {dir=1;}
	 		else if (dir==4) {dir=2;}
	 		} 
 			ShouldChange=true;
 		}
 	}

 	void SpecialAttack()
 	{
 		GameObject newprojectile = Instantiate (projectile,transform.position,transform.rotation); 
 		int randomDir = Random.Range (1,5);
 		switch (randomDir) {
		 
			

				case 2: newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right*projectilethrust) ;
					break;
			case 3: newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left*projectilethrust)  ;
					break;
			case 4: newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.up*projectilethrust) ;
					break;
		case 1: newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.down*projectilethrust) ;
					break;
			}	 specialtimer-=Time.deltaTime; if(specialtimer<=0){}
					
			
 	
 		}
	#region destroydragonwitheffects

	void destroydragon()
	{
	if (health<=0)
				{Spawnercanvas(); 				


																																												}
	}
	void Spawnercanvas () { spawnreward2=true; GameObject.FindGameObjectWithTag("Text").GetComponent<BOSSUITEXT>().spawnreward=true;}

	#endregion


 		public void die (){ 	Destroy(gameObject) 	; Instantiate(deathparticle,transform.position,transform.rotation);}
}
