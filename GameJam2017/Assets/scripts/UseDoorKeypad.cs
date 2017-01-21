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
    public Camera mainCam;
    public DepthOfField depthScript;
    public float aperture = 0.5f;
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
        if(!playerConfig.isIsolatedView()) {
            playerConfig.setIsolatedView(true);
            Debug.Log("Using DoorKeypad");
            Cursor.visible = true;

            GameObject prefab = Instantiate(
                keypadController.useableKeypadPrefab, 
                player.transform.forward * keypadController.distanceFromPlayerToUseableKeypad,
                player.transform.rotation, 
                this.transform);

            // blur screen 
            depthScript.focalTransform = prefab.transform;
            depthScript.aperture = aperture;
            depthScript.enabled = true;

            // disable player movement
            playerFPC.enabled = false;
        }
    }

    void OnGUI()
    {


    }
}
