using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public interface Useable
{
    void use();
}

public class UseDoorKeypad : MonoBehaviour, Useable
{
    private DoorKeypadController keypadController;
    private GameObject player;
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        keypadController = this.GetComponent<DoorKeypadController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use()
    {
        Debug.Log("Using DoorKeypad");
        // blur screen 
        // take prefab and instantiate it in center of screen, unblurred
        Instantiate(keypadController.useableKeypadPrefab);
        // disable player movement
        playerFPC.enabled = false;
    }

    void OnGUI()
    {


    }
}
