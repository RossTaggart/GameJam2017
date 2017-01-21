using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UseDoorKeypadButton : MonoBehaviour, Useable
{
    private GameObject player;
    public string legend = "1";
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
        if (keypad == null) {
            Debug.Log("Keypad object is not configured correctly, the keypad containing the 'UseDoorKeypad' component must be the direct parent of all objects containing 'UseDoorKeypadButton' components");
        }
    }

    public void use()
    {
        Debug.Log("Using DoorKeypad");

    }

    void OnGUI()
    {


    }
}
