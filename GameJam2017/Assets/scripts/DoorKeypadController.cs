using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeypadController : MonoBehaviour
{
    public GameObject useableKeypadPrefab;
    public Door door;
    public string defaultText = "";
    public string solution = "12345";
    public float distanceFromPlayerToUseableKeypad = 2.0f;
    private bool doorOpen;

    public bool isDoorOpen() {
        return door.isOpen();
    }
}
