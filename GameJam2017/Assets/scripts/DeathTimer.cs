using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathTimer : MonoBehaviour
{
    public GameObject water;
    public float timeLeft = 10f;
    public FirstPersonController playerScript;
    float waterHeight = -0.4f;
    float startPos=-0.4f;
    float endPos;
    public Vector3 waterPos;

	// Use this for initialization
	void Start ()
    {
        playerScript = this.gameObject.GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        waterPos = water.GetComponent<Transform>().position;

        
            water.gameObject.transform.position = waterPos + new Vector3(0, 0.001f, 0);
       

        timeLeft = timeLeft - Time.deltaTime;
        if(timeLeft<=5f && playerScript.m_WalkSpeed>0)
        {
            playerScript.m_WalkSpeed = playerScript.m_WalkSpeed - 1;
            timeLeft = 10f;

        }
        if (playerScript.m_WalkSpeed<=0)
        {
            Debug.Log("game over screen");
        }
	}
}
