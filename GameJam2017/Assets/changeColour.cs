using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColour : MonoBehaviour
{

    public Material green, red;
    private Renderer rend;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.gameObject.transform.parent.gameObject.GetComponent<DoorKeypadController>().isDoorOpen())
        {
            rend.material = green;
        }
        else
        {
            rend.material = red;
        }

	}
}
