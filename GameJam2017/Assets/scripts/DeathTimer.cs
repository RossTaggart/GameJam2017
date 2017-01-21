using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathTimer : MonoBehaviour
{

    public float timeLeft = 10f;
    public FirstPersonController playerScript;

	// Use this for initialization
	void Start ()
    {
        playerScript = this.gameObject.GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
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
