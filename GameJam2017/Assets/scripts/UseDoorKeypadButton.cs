﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class UseDoorKeypadButton : MonoBehaviour, Useable
{
    private GameObject player;
    public string legend = "1";
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;
    //private Regex zeroToNine;
    private DoorKeypadText keypadText;
    private TextMesh keypadTextMesh;
    public Camera mainCam;
    public DepthOfField depthScript;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        //zeroToNine = new Regex("^[0-9]+$");
        keypadText = transform.parent.GetComponentInChildren<DoorKeypadText>();
        keypadTextMesh = keypadText.gameObject.GetComponent<TextMesh>();
        mainCam = Camera.main;
        depthScript = mainCam.GetComponent<DepthOfField>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use()
    {
        int i;
        Debug.Log("Using DoorKeypad key " + legend);
        if (string.Equals("X", legend, System.StringComparison.OrdinalIgnoreCase)) {
            Debug.Log("Which is X");
            keypadText.setCurrentText(keypadText.getCurrentText() + legend);
            playerFPC.enabled = true;
            //when you want to disable the depth of field, use this line
            depthScript.enabled = false;
            Destroy(transform.parent.gameObject);
            playerConfig.setIsolatedView(false);
            player.GetComponentInChildren<Canvas>().enabled = true;
            keypadText.cancel();
            Destroy(this.gameObject.transform.parent);
        }
        else if (string.Equals("Y", legend, System.StringComparison.OrdinalIgnoreCase)) {
            Debug.Log("Which is Y");
            Debug.Log("And new text is " + keypadText.getCurrentText() + legend);
            keypadText.setCurrentText(keypadText.getCurrentText() + legend);
            // destroy prefab if key is correct
            playerFPC.enabled = true;
            playerConfig.setIsolatedView(true);
            keypadText.confirm();
            Destroy(this.gameObject.transform.parent);
        }
        else if (int.TryParse(legend, out i))
        {
            if (i >= 0 && 9 >= i) { 
                Debug.Log("Which is a number");
                keypadText.setCurrentText(keypadText.getCurrentText() + legend);
            } else {
                Debug.Log(i);
                Debug.LogError("invalid keypad number");
            }
        }

    }

    void OnGUI()
    {


    }
}
