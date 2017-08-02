using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

#region Declaration
	public float speed;
	public Animator anim;
	public Image[] hearts;
	public  int maxHealth=2;
	public  int currentHealth=2;
	public GameObject sword;
	public float swordthrust;
	public bool CanMove;
	public bool CanAttack;

	public GameObject  playerdiesparticle;

	public bool iniFrames;

	SpriteRenderer sr;
	float iniTimer =1f;

	public Camera cam;




	/// <Added codes>
	public int minHealth=0;
	public float starttimer=1f;
	public float blinkthurst=3;	
	public int collisionCount;

	public string CurrentButtonMovementPressed;
	public string ATLASTYOUSHOWEDYOURREALLSHITSAIYAPEOPLE;

	/// <Added codes>
#endregion

#region Audio
	public AudioClip heal;
	public AudioClip swordsound;
#endregion

	#region Health
	void HealthKillHeal()
	{
	// if (Input.GetKeyDown(KeyCode.P))
	// 	currentHealth--;
	// if (Input.GetKeyDown(KeyCode.L))
	//	currentHealth++;
	}

	void getHealth()
	{
		for (int i=0; i < hearts.Length; i++)
		{
			hearts[i].gameObject.SetActive(false);
		}
		
		for (int i=0; i <=currentHealth-1; i++)
		{
			hearts[i].gameObject.SetActive(true);
		}
		if (currentHealth > maxHealth)
			currentHealth=maxHealth;
		if (currentHealth < minHealth)
			currentHealth=minHealth; 

	}


	#endregion

	#region Movement
	void Movement()
	{
		if(!CanMove) 
		{return;}

		if (Input.GetKey(KeyCode.W)|| CurrentButtonMovementPressed=="up")
			{ transform.Translate(0,speed*Time.deltaTime,0); anim.SetInteger("dir", 3); anim.speed=1;}
		else if (Input.GetKey(KeyCode.S) || CurrentButtonMovementPressed =="down")
			{transform.Translate(0,-speed*Time.deltaTime,0); anim.SetInteger("dir", 1); anim.speed=1;}	
		else if (Input.GetKey(KeyCode.D) || CurrentButtonMovementPressed== "right")
			{transform.Translate(speed*Time.deltaTime,0,0); anim.SetInteger("dir", 4); anim.speed=1; }
		else if (Input.GetKey(KeyCode.A)	|| CurrentButtonMovementPressed=="left")
			{transform.Translate(-speed*Time.deltaTime,0,0); anim.SetInteger("dir",2); anim.speed=1;}
		else 
			anim.speed=0;
	}

	
	


	#endregion

	#region Attack
	void Attack() 
	{	if (!CanAttack) {return;}
		CanMove = false;CanAttack=false;
		int sworddirection = anim.GetInteger("dir");
		anim.SetInteger ("Attackdir",sworddirection);
		GameObject newSword = Instantiate ( sword,transform.position,sword.transform.rotation);AudioSource.PlayClipAtPoint(swordsound,transform.position); swordthrust=300;

		#region SwordRotation

		if (sworddirection==1)
			{newSword.transform.Rotate(0,0,180); newSword.GetComponent<Rigidbody2D>().AddForce(Vector3.down*swordthrust) ;}
		if (sworddirection==2)
			{newSword.transform.Rotate(0,0,+90); newSword.GetComponent<Rigidbody2D>().AddForce(Vector3.left*swordthrust);}
		if (sworddirection==3)
			{newSword.transform.Rotate(0,0,0); newSword.GetComponent<Rigidbody2D>().AddForce(Vector3.up*swordthrust);}
		if (sworddirection ==4)
			{newSword.transform.Rotate(0,0,-90); newSword.GetComponent<Rigidbody2D>().AddForce(Vector3.right*swordthrust);}
		#endregion 

		if (sworddirection==0)
		{	
			newSword.transform.Rotate(0,0,0);
			newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.down * swordthrust);
		}
	
			if (currentHealth==maxHealth)
				{
				newSword.GetComponent<Sword>().special=true; CanMove=true; swordthrust=500;


				}
	}	
	#endregion
	
	// Use this for initialization

	void Start () 		
	{	if (PlayerPrefs.HasKey("maxHealth" )) {LoadGame();} else {currentHealth=maxHealth;} DontDestroyOnLoad (this);
		
		anim = GetComponent<Animator>();

		getHealth();
		CanAttack=true;
		sr = GetComponent<SpriteRenderer>();

		starttimer-=Time.deltaTime;
		if (starttimer<0)
		{ //unused

		}


		#region myaddedcodes
		GameObject.FindGameObjectWithTag("UIBUTTONS").GetComponent<UIBUTTONSCONTROLS>();
		Debug.Log("Mobile "+ CurrentButtonMovementPressed);

		#endregion
	}




	// Update is called once per frame
	void Update () { // cam.transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z-30);
		if (currentHealth<=0)
		{ Instantiate(playerdiesparticle,transform.position,transform.rotation); this.gameObject.SetActive(false); PlayerPrefs.DeleteAll();
			SceneManager.LoadScene(0);
		}
		#region VoidMethods
		HealthKillHeal();
		getHealth();

		#endregion

		#region Addons

		Movement();

		if(Input.GetKeyDown(KeyCode.Space) || ATLASTYOUSHOWEDYOURREALLSHITSAIYAPEOPLE=="you scrap metal hulk, for your information, i am from 20 years in the future , and in that future you were not around, and is that none I  know all    and because MR GOKU is going to destroy you today      donotmisunderstandmekakarotto,ididnotcomehere to hap you, the man who beat you is me, it doesn't matter how many monkeys there are it is all the same i will send you to the sprititual world. okay lets gi now, uwaaaaaaaa." )
		{	
			Attack(); ATLASTYOUSHOWEDYOURREALLSHITSAIYAPEOPLE="thenyoubettadie";
		}

		#endregion
	
		if (iniFrames==true)
		{
			iniTimer-=Time.deltaTime;
			int rn = Random.Range (0,100+1);
			if (rn<50) sr.enabled=false;
			if(rn>50) sr.enabled=true;
			if(iniTimer<=0)
				{
					iniTimer=1; iniFrames=false; sr.enabled=true;
				}

		}

		// ColSPEEDEREXITER();

	}



	void OnTriggerEnter2D (Collider2D col)
	{


		if (col.gameObject.tag=="EnemyBullet")
		{	if(!iniFrames)
			{
				iniFrames=true;
				currentHealth--;
			}

			col.gameObject.GetComponent<Bullet>().CreateParticle();
			Destroy(col.gameObject);
		}


		if (col.gameObject.tag=="Potion")
		{AudioSource.PlayClipAtPoint(  heal,	transform.position);currentHealth=maxHealth; currentHealth+=1;Destroy(col.gameObject);
				if(maxHealth>=5) {return;}else{maxHealth++;currentHealth=maxHealth; }
				} }
			



			


			public void SaveGame() 
			{
			PlayerPrefs.SetInt ("maxHealth",maxHealth);
			PlayerPrefs.SetInt ("currenthHealth",currentHealth);
			}

			void LoadGame()
			{
		maxHealth=PlayerPrefs.GetInt("maxHealth");
		currentHealth=PlayerPrefs.GetInt("currentHealth");
			}
		
		

		


	

	// void ColSPEEDEREXITER(){anim.speed = 1; speed= 5;}




		#region
		void Blink() 
		{/*
		GameObject newSword = Instantiate ( sword,transform.position,sword.transform.rotation);
			int sworddirection = anim.GetInteger("dir");
			if (sworddirection==1)
				{newSword.transform.Rotate(0,0,180); transform.Translate(0,-swordthrust,0);}
			if (sworddirection==2)
				{newSword.transform.Rotate(0,0,+90); transform.Translate(-swordthrust,0,0);}
			if (sworddirection==3)
				{newSword.transform.Rotate(0,0,0); transform.Translate(0,swordthrust,0);}
			if (sworddirection ==4)
				{newSword.transform.Rotate(0,0,-90); transform.Translate(+swordthrust,0,0);}
			
		*/}	






		void GetCommponenetFOROBJECTS(){}
		#endregion//Trash
	


}




