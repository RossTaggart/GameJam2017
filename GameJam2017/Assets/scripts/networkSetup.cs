using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class networkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start ()
    {
		if(isLocalPlayer)
        {
            GetComponent<networkScript>().enabled = true;
        }
	}

}
