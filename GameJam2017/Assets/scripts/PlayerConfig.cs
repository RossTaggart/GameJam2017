﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour {

    public float useMaxDistance = 5;
    public string useKeyBinding = "e";

	// Use this for initialization
	void Start () {

	}

    void Update() {
        // Player 'Use' input
        if (Input.GetKeyDown(useKeyBinding))
        {
            Ray playerForward = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(playerForward, out hit, useMaxDistance))
            {
                foreach (Component component in hit.collider.gameObject.GetComponents(typeof(Component)))
                {
                    if (component is Useable)
                    {
                        (component as Useable).use();
                    }
                }
            }
        }
    }
	
	void OnGUI () {
        
    }
}