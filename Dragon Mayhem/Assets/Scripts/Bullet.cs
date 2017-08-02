using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

public GameObject particleEffect;
float timer=2f;


#region Addons
	public AudioClip fireball;
	public bool FireDragonWallDestroy=true;
#endregion

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(fireball,transform.position);
		
	}
	
	// Update is called once per frame
	void Update () {
		timer-=Time.deltaTime;
		if(timer<=0)
		{
			CreateParticle();
			Destroy(gameObject);
		}
		
	}

	public void CreateParticle()
	{
		Instantiate(particleEffect,transform.position,transform.rotation); 
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.GetComponent<Environment_Destroy>().CanDestroy && FireDragonWallDestroy ) { Destroy(col.gameObject);  CreateParticle();Destroy(gameObject);}
		else if (col.gameObject.tag=="Wall") {   CreateParticle() ;Destroy(this.gameObject)   ;}


	}
}
