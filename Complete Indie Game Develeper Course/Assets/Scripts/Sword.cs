using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
#region Declared
	public float timer=0.1f;
	public float special_timer=1f;
	public bool special;
	public GameObject swordParticle;



#endregion


	// Use this for initialization
	void Start () {	
			
	}
	
	// Update is called once per frame
	void Update () {



		timer-=Time.deltaTime;
		if (timer<=0) 
			{
			GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("Attackdir", 5);

			}

		if (!special)
		if (timer<=0)
			{
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanMove=true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanAttack=true;
			Destroy(gameObject);
			}
		special_timer-=Time.deltaTime;
		if (special_timer<=0)
			{
			CreateParticle();
			Destroy(gameObject); 

			}
	}

	public void CreateParticle()
	{	GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CanAttack=true;
		Instantiate (swordParticle,transform.position,transform.rotation);
	}
}
