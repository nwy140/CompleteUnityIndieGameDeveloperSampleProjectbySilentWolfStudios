using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDrag()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed = "left";
    }

    void OnMouseEnter()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed = "left";
    }
    void OnMouseOver()
    {
    }
    void OnMouseExit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CurrentButtonMovementPressed = "lewdwft";
    }
    
}

