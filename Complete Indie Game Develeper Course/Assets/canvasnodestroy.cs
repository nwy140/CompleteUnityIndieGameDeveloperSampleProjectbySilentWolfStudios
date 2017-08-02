using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasnodestroy : MonoBehaviour {
	public bool spawner;
	
	public GameObject potion;
	// Use this for initialization
	void Start () {DontDestroyOnLoad( this.gameObject);
	spawner = GameObject.FindGameObjectWithTag("BOSS").GetComponent<Wizard>().spawnreward2=true;

	}
	
	// Update is called once per frame
	void Update () { if (spawner) {GameObject.FindGameObjectWithTag("Canvas").SetActive(true); Instantiate(potion,transform.position,Quaternion.identity);}
		SETERACITVe();
	}

	void SETERACITVe()
	{
		gameObject.SetActive(true);
	}
}
