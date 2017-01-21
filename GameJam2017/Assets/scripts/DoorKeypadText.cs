using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorKeypadText : MonoBehaviour
{
    private DoorKeypadController keypadController;
    private string currentText;
    private GameObject player;
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        keypadController = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<DoorKeypadController>();
        Debug.Log(keypadController);
        currentText = keypadController.defaultText;
        this.GetComponent<TextMesh>().text = currentText;
    }

    // Update is called once per frame
    void Update()
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
            // open door
            keypadController.door.transform.position = keypadController.doorOpenedPosition;
            // door.open()
        } else {
            // play failure sound
        }

    }

    public void cancel() {
        currentText = keypadController.defaultText;
    }
}
