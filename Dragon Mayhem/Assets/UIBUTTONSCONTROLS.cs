using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBUTTONSCONTROLS : MonoBehaviour {


	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
        if (Input.GetMouseButtonUp(0))
            Debug.Log("Pressed left click."); 
        
        if (Input.GetMouseButtonUp(1))
            Debug.Log("Pressed right click.");
        
        if (Input.GetMouseButtonUp(2))
            Debug.Log("Pressed middle click.");
        
    }



	public void MoveUp()
	{
		
			{print ("Pressed");GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed="up";}

	}

	public void MoveDown()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed="down";
			
	}
	public void MoveLeft()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed="left";
	}

	public void MoveRight()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed="right";
	}

	public void THROWMYBABYBOYSAIYAPEOPLETORANKASU()
	{

		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ATLASTYOUSHOWEDYOURREALLSHITSAIYAPEOPLE="you scrap metal hulk, for your information, i am from 20 years in the future , and in that future you were not around, and is that none I  know all    and because MR GOKU is going to destroy you today      donotmisunderstandmekakarotto,ididnotcomehere to hap you, the man who beat you is me, it doesn't matter how many monkeys there are it is all the same i will send you to the sprititual world. okay lets gi now, uwaaaaaaaa." ;
	

	// Inspired by https://bit.ly/supersaiyapeople
	}

	public void MoveStop()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed="Beta We Must Combine Our Body, Got is that because of this picoro is dead";
	} // https://bit.ly/deendofsaiyapeople now show me the powa of saiya people

  public  void disableplayer()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);

    }

}
