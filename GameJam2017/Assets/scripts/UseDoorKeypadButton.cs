using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class UseDoorKeypadButton : MonoBehaviour, Useable
{
    private GameObject player;
    public string legend = "1";
    private PlayerConfig playerConfig;
    private FirstPersonController playerFPC;
    //private Regex zeroToNine;
    private DoorKeypadText keypadText;
    private TextMesh keypadTextMesh;
    public Camera mainCam;
    private DepthOfField depthScript;
    public DoorKeypadController keypadController;
    public AudioClip win, failure, press;
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerFPC = player.GetComponent<FirstPersonController>();
        playerConfig = player.GetComponent<PlayerConfig>();
        keypadText = transform.parent.GetComponentInChildren<DoorKeypadText>();
        keypadTextMesh = keypadText.gameObject.GetComponent<TextMesh>();
        mainCam = Camera.main;
        depthScript = mainCam.GetComponent<DepthOfField>();
        keypadController = this.gameObject.transform.parent.parent.GetComponent<DoorKeypadController>();
        source = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!keypadController.isDoorOpen()) {
            checkKey();
            checkKeyValidity();
        }
    }

    public void leaveIsolatedView(bool success) {
        playerFPC.enabled = true;
        depthScript.enabled = false;
        Destroy(transform.parent.gameObject);
        playerConfig.setIsolatedView(false);
        player.GetComponentInChildren<Canvas>().enabled = true;
        Cursor.visible = false;
        if (success) {
            source.clip = win;
            source.loop = false;
            source.Play();
            keypadText.confirm();

        } else {
            source.clip = failure;
            source.loop = false;
            source.Play();
            keypadText.cancel();
        }
        Destroy(this.gameObject.transform.parent);
    }

    public void use()
    {
        int i;
        Debug.Log("Using DoorKeypad key " + legend);
        if (string.Equals("X", legend, System.StringComparison.OrdinalIgnoreCase)) {
            Debug.Log("Which is X");
            leaveIsolatedView(false);
        }
        else if (string.Equals("Y", legend, System.StringComparison.OrdinalIgnoreCase)) {
            keypadText.setCurrentText(keypadText.getCurrentText() + legend);
            // destroy prefab if key is correct
            leaveIsolatedView(true);
        }
        else if (int.TryParse(legend, out i))
        {
            if (i >= 0 && 9 >= i) { 
                Debug.Log("Which is a number");
                keypadText.setCurrentText(keypadText.getCurrentText() + legend);
                source.clip = press;
                source.loop = false;
                source.Play();
            } else {
                Debug.Log(i);
                Debug.LogError("invalid keypad number");
            }
        }

    }

    private void checkKeyValidity() {
        if (keypadText.getCurrentText() == keypadController.solution) {
            keypadText.confirm();
            DoorKeypadText[] useableKeypads = keypadController.gameObject.GetComponentsInChildren<DoorKeypadText>();
            if (useableKeypads.Length > 0)
            {
                foreach (DoorKeypadText keypadText in useableKeypads)
                {
                    Destroy(keypadText.transform.parent.gameObject);
                }
            }
        }
    }

    private void checkKey() {
        checkKeyValidity();
        Debug.Log("keypadText.getCurrentText().Length = " + keypadText.getCurrentText().Length);
        Debug.Log("keypadController.solution.Length = " + keypadController.solution.Length);
        if (keypadText.getCurrentText().Length > keypadController.solution.Length) {
            keypadText.cancel();
            depthScript.enabled = false;
        }
    }
}
