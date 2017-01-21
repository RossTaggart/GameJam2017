﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorKeypad : MonoBehaviour, Useable
{

    private GameObject player;
    public string legend = "1";
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;
    private DoorKeypad keypad;

    // Use this for initialization
    void Start()
    {
        player = player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use() {
        Debug.Log("Using DoorKeypad");
        // blur screen 
        // take prefab and instantiate it in center of screen, unblurred
        // disable player movement
    }

    void OnGUI()
    {


    }
}
