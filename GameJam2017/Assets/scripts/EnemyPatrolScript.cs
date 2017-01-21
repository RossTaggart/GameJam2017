using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{
    public GameObject[] waypoints;
    public float patrolSpeed = 5;
    public float waitTimer = 5.0f;

    public GameObject currentWaypoint;
    public int currentIndex;
    public bool isWaiting = false;
    // Use this for initialization
    void Start()
    {
        currentIndex = 0;
        currentWaypoint = waypoints[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting == false)
        {
            
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(currentWaypoint.transform.position.x,
                this.transform.position.y, currentWaypoint.transform.position.z), (patrolSpeed*Time.deltaTime));
        }

        if(isWaiting==true)
        {


            waitTimer = waitTimer - (1 * Time.deltaTime);
            if (waitTimer <= 0.0f)
            {
                isWaiting = false;
                waitTimer = 5.0f;
            }
        }

    }

   
   void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.tag=="EnemyWaypoint")
        {
            currentIndex++;
            if((currentIndex-1) >= waypoints.Length -1)
            {
                currentIndex = 0;
            }
            isWaiting = true;
           
           
            currentWaypoint = waypoints[currentIndex];
            SightScript sight = this.GetComponentInChildren<SightScript>();
            sight.target = currentWaypoint.transform;
        }
    }
}