using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrianScript : MonoBehaviour
{
    public float speed = 5000f;
    public Camera brianCam, mainCam;
    public bool rotating = false;
    public bool endingActive = false;
    public float timer1 = 1;
    public float timer2 = 3;
    public bool timer2active = false;

    public GameObject spotlight;



	// Use this for initialization
	void Start ()
    {
        mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (endingActive)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
            {
                timer2active = true;
            }

            if (timer2active)
            {
                timer2 -= Time.deltaTime;
                transform.Rotate(Vector3.up, speed * Time.deltaTime);

                if (timer2 <= 0)
                {
                    this.gameObject.GetComponent<Renderer>().enabled = false;

                    //trigger ui
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    Canvas canv = player.GetComponentInChildren<Canvas>();

                    foreach (Transform child in canv.gameObject.transform)
                    {
                        if (child.tag == "endpanel")
                        {
                            child.gameObject.SetActive(true);
                            Cursor.visible = true;
                        }
                    }

                    endingActive = false;
                }
            }
        }
    }

    public void switchCams()
    {
        mainCam.enabled = !mainCam.enabled;
        brianCam.enabled = !brianCam.enabled;
    }

    public void switchToEndGame()
    {
        endingActive = true;
        spotlight.SetActive(true);
        switchCams();
    }
}
