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
    public float aperture = 0.6f;
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
        keypadController = this.gameObject.GetComponent<DoorKeypadController>();
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
            player.GetComponentInChildren<Canvas>().enabled = false;

            GameObject prefab = Instantiate(keypadController.useableKeypadPrefab, Camera.main.transform.position + Camera.main.transform.forward * 0.4f , Camera.main.transform.rotation, this.transform);

            Vector3 playerfor = Camera.main.transform.forward;
            prefab.gameObject.transform.right = playerfor;

            Vector3 playerright = Camera.main.transform.right;
            playerright *= -1;
            prefab.gameObject.transform.forward = playerright;

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
