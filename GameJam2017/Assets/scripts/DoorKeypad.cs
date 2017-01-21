using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public interface Useable {
    void use();
}

public class DoorKeypad : MonoBehaviour, Useable
{

    public GameObject player;
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;

    // Use this for initialization
    void Start()
    {
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use() {
        Debug.Log("Using DoorKeypad");
    }

    void OnGUI()
    {


    }
}
