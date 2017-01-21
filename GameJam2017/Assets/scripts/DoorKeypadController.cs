using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeypadController : MonoBehaviour
{
    public GameObject useableKeypadPrefab;
    public GameObject door;
    public Vector3 doorOpenedPosition;
    public string defaultText = "";
    public string solution = "12345";
    public float distanceFromPlayerToUseableKeypad = 2.0f;
    private bool doorOpen;

    // Use this for initialization
    void Start()
    {
        doorOpen = false;
    }

    public void setDoorOpen(bool doorOpen) {
        this.doorOpen = doorOpen;
    }

    public bool isDoorOpen() {
        return this.doorOpen;
    }
}
