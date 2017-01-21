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
    public float aperture = 0.4f;
    private DoorKeypadController keypadController;
    private GameObject player;
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;
    public GameObject spotlightObj;

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

            GameObject prefab = Instantiate(
                keypadController.useableKeypadPrefab,
                 player.transform.position + player.transform.forward,
                player.transform.rotation, 
                this.transform);

            Vector3 rot = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            Vector3 scale = prefab.gameObject.transform.localScale;
            Vector3 pos = prefab.gameObject.transform.localPosition;

            Vector3 playerfor = player.transform.forward;
            playerfor *= 1;


            pos.y += 0.5f;

            scale = scale / 3;

            //prefab.gameObject.transform.localEulerAngles = rot;
            prefab.gameObject.transform.localScale = scale;
            prefab.gameObject.transform.localPosition = pos;
            prefab.gameObject.transform.right = playerfor;

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
