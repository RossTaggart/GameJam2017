using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

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
    public Camera mainCam;
    public DepthOfField depthScript;
    public float aperture = 0.5f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        keypadController = this.GetComponent<DoorKeypadController>();
        mainCam = Camera.main;
        depthScript = mainCam.GetComponent<DepthOfField>();
        depthScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use()
    {
        Debug.Log("Using DoorKeypad");
        Cursor.visible = true;
        // take prefab and instantiate it in center of screen, unblurred

        GameObject prefab = Instantiate(keypadController.useableKeypadPrefab);
        // blur screen 
        depthScript.focalTransform = prefab.transform;
        depthScript.aperture = aperture;
        depthScript.enabled = true;

        playerConfig.setCanUse(false);
        Instantiate(keypadController.useableKeypadPrefab, player.transform.forward * keypadController.distanceFromPlayerToUseableKeypad*5, transform.rotation, this.transform);

        // disable player movement
        playerFPC.enabled = false;
    }

    void OnGUI()
    {


    }
}
