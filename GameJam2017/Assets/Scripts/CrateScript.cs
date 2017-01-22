using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    public GameObject startingWaypoint;
    public GameObject endingWaypoint;
    public float speed = 10;
    public bool towardsEnd = true;
    public bool triggered = false;
    public bool moveCompleted = false;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = new Vector3(startingWaypoint.transform.position.x,this.transform.position.y, startingWaypoint.transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!moveCompleted)
        {
            if (triggered)
            {
                if (towardsEnd)
                {
                    float movespeed = (speed * Time.deltaTime);
                    Debug.Log("Entered");
                    this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(endingWaypoint.transform.position.x, this.transform.position.y, endingWaypoint.transform.position.z), movespeed);
                }
                else
                {
                    float movespeed = (speed * Time.deltaTime);
                    Debug.Log("Entered");
                    this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(startingWaypoint.transform.position.x, this.transform.position.y, startingWaypoint.transform.position.z), movespeed);
                }
            }
        }
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (towardsEnd)
        {
            if (collision.gameObject.tag == "EndPoint")
            {
                moveCompleted = true;
                triggered = false;
                towardsEnd = false;
            }
        }
        else
        {
            if (collision.gameObject.tag == "StartPoint")
            {
                moveCompleted = true;
                triggered = false;
                towardsEnd = true;
            }
        }
    }

    public void triggerme()
    {
        triggered = true;
        moveCompleted = false;
        Debug.Log("setting triggered true");
    }
}
