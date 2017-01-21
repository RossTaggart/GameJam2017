using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneScript : MonoBehaviour
{
    // Use this for initialization
    void Start ()
    {
        string[] devices = Microphone.devices;
        AudioSource aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start(devices[0], true, 10, 44100);
        aud.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
