using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeFromWaves : MonoBehaviour {

	//transform of camera
	public Transform camTransform;

	//how long camera should shake for
	public float shakeDuration = 3.0f;

	//Amplitude of shake. A larger value shakes the camera harder.
	public float shakeAmount = 55.0f;
	public float decreateFactor = 1.0f;
	public int delayBetweenShakes = 0;
	public float timeSinceLastShake = 0.0f;

    public bool triggered = false;

    public CrateScript[] crates;

    //enables the script. traditional script enabling just straight up wasn't working
    public bool enabledScript=false;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null) 
		{
			camTransform = GetComponent (typeof(Transform)) as Transform;
		}
	}

	public void onEnable(int delayBetweenShakes){

		this.delayBetweenShakes = delayBetweenShakes;
		originalPos = camTransform.localPosition;
		enabledScript = true;
	}

	// Use this for initialization
	void Start () {
        //CameraShakeFromWaves cameraShakeFromWaves = GetComponent<CameraShakeFromWaves> ();
        //cameraShakeFromWaves.enabledScript= false;

         crates = FindObjectsOfType<CrateScript>();
    }
	 
	// Update is called once per frame
	void Update () {
		if (enabledScript == true) {
			if (shakeDuration > 0 && Mathf.RoundToInt (timeSinceLastShake) > delayBetweenShakes) {

				Debug.Log ("shake triggered");
                if (!triggered)
                {
                    foreach(CrateScript crate in crates)
                    {
                        crate.triggerme();
                    }
                    triggered = true;
                }
                camTransform.localPosition = originalPos + new Vector3(UnityEngine.Random.insideUnitCircle.x, originalPos.y, originalPos.z) * shakeAmount;

                shakeDuration -= Time.deltaTime * decreateFactor;
			} else if (shakeDuration <= 0 && Mathf.RoundToInt (timeSinceLastShake) > delayBetweenShakes) {
				shakeDuration = 0.0f;
                camTransform.localPosition = originalPos;
                triggered = false;
				timeSinceLastShake = 0.0f;
			} else {
				shakeDuration = 3.0f;
                triggered = false;
                timeSinceLastShake += Time.deltaTime;
			}
		}
	}
}
