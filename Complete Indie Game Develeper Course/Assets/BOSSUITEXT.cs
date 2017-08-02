using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSUITEXT : MonoBehaviour {

	public Text text;
	public bool spawnreward=false;

	public GameObject potion;
    public GameObject ReturnMenu;

	// Use this for initialization
	void Start ()
    {
    
        text.text="You must  be the one who ate his friend, I'm gonna burn you to death";
    
    }
	
	/// Update is called once per frame
	void Update () { spawnreward = GameObject.FindGameObjectWithTag("BOSS").GetComponent<Wizard>().spawnreward2 ;    
		if ( spawnreward==true){ text.text = "Congratulations, You Finished the game, stay tune for more new levels and updates"; GameObject.FindGameObjectWithTag("BOSS").GetComponent<Wizard>().die(); Instantiate (potion,transform.position,transform.rotation);
            ReturnMenu.SetActive(true);
        }
        else { ReturnMenu.SetActive(false); }
		
	}
}
