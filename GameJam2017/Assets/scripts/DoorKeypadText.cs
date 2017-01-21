using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorKeypadText : MonoBehaviour, Useable
{
    private GameObject player;
    public string defaultText = "0000";
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;
    private UseDoorKeypad keypad;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        keypad = this.transform.parent.GetComponent<UseDoorKeypad>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use()
    {
        Debug.Log("Using DoorKeypad");
        
    }

    void OnGUI()
    {


    }
}
