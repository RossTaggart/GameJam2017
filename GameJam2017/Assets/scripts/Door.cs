using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Vector3 openPosition;
    bool doorOpened;

	// Use this for initialization
	void Start () {
        doorOpened = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isOpen() {
        return this.doorOpened;
    }

    public void open() {
        if (openPosition != null) {
            this.transform.position = openPosition;
        } else {
            Debug.LogError("the openPosition of the door is null");
        }
    }
}
