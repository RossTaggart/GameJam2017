using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class DoorKeypadText : MonoBehaviour
{
    private DoorKeypadController keypadController;
    private string currentText;
    private GameObject player;
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;
    private DepthOfField depthScript;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        keypadController = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<DoorKeypadController>();
        currentText = keypadController.defaultText;
        this.GetComponent<TextMesh>().text = currentText;
        depthScript = Camera.main.GetComponent<DepthOfField>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<TextMesh>().text = currentText;
    }

    public string getCurrentText() {
        return currentText;
    }

    public void setCurrentText(string newText) {
        currentText = newText;
    }

    public void confirm() {
        if(currentText == keypadController.solution) {
            // play success sound
            keypadController.door.open();
            currentText = keypadController.defaultText;
            playerFPC.enabled = true;
            Destroy(transform.parent.gameObject);
            playerConfig.setIsolatedView(false);
            player.GetComponentInChildren<Canvas>().enabled = true;
            Cursor.visible = false;
            depthScript.enabled = false;
            Destroy(this.gameObject.transform.parent);
        } else {
            // play failure sound
            currentText = "";
        }

    }

    public void cancel() {
        currentText = keypadController.defaultText;
        playerFPC.enabled = true;
        Destroy(transform.parent.gameObject);
        playerConfig.setIsolatedView(false);
        player.GetComponentInChildren<Canvas>().enabled = true;
        Cursor.visible = false;
        Destroy(this.gameObject.transform.parent);
    }
}
