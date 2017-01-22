using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerending : MonoBehaviour
{

    public AudioSource aud;

	// Use this for initialization
	void Start ()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponentInChildren<BrianScript>().switchToEndGame();
            aud.Play();
        }
    }
}
