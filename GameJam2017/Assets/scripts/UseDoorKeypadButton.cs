using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UseDoorKeypadButton : MonoBehaviour, Useable
{
    private GameObject player;
    public string legend = "1";
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;
    private Regex zeroToNine;
    private DoorKeypadText keypadText;
    private TextMesh keypadTextMesh;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        zeroToNine = new Regex("^[0-9]+$");
        keypadText = transform.parent.GetComponentInChildren<DoorKeypadText>();
        keypadTextMesh = keypadText.gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void use()
    {
        Debug.Log("Using DoorKeypad key " + legend);
        if(zeroToNine.IsMatch(legend)) {
            Debug.Log("Which is a number");
            keypadText.setCurrentText(keypadText.getCurrentText() + legend);
        }
        else if (string.Equals("X", legend, System.StringComparison.OrdinalIgnoreCase)) {
            Debug.Log("Which is X");
            keypadText.setCurrentText(keypadText.getCurrentText() + legend);
            playerFPC.enabled = true;
        }
        else if (string.Equals("Y", legend, System.StringComparison.OrdinalIgnoreCase)) {
            Debug.Log("Which is Y");
            keypadText.setCurrentText(keypadText.getCurrentText() + legend);
            playerFPC.enabled = true;
        }


    }

    void OnGUI()
    {


    }
}
