using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour {

    public float range = 100;
    public Transform target;
    public Transform sight;

    private bool canSee;
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        sight.transform.LookAt(new Vector3(target.position.x, sight.position.y, target.position.z));
        Debug.Log(sight.transform.rotation);

        RaycastHit hit;
        if (Physics.Raycast(sight.transform.position, sight.transform.forward, out hit, range))
        {
            if (hit.collider.tag == "Player")
            {
                canSee = true;
                Debug.Log(canSee);
            }
            else
            {

                canSee = false;
                Debug.Log(canSee);
            }
        }
	}
}
