using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnplayer : MonoBehaviour {
	public GameObject spawnplayerpos;
	// Use this for initialization
	void Start () {

		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().transform.position= new Vector3 (-3,0,20);


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
