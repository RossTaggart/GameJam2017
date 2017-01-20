using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour {
    public GameObject startingWaypoint;
    public GameObject endingWaypoint;
    public float timer = 5;
    public float speed = 10;

    private bool moveCompleted = false;
	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(startingWaypoint.transform.position.x,this.transform.position.y, startingWaypoint.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(moveCompleted == false)
        {
            timer -= (1 * Time.deltaTime);
            float movespeed = (speed * Time.deltaTime);
            if(timer <=0)
            {
                Debug.Log("Entered");
                timer = 0;
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(endingWaypoint.transform.position.x, this.transform.position.y, endingWaypoint.transform.position.z), movespeed);
            }

        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "EndPoint")
        {
            moveCompleted = true;
        }
    }
}
