using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneScript : MonoBehaviour
{
    public AudioSource aud;
    public AudioSource staticsource;
    public AudioClip staticclip;
    public float sensitivity = 100;
    public float loudness = 0;
    public float threshold = 1.0f;

    // Use this for initialization
    void Start ()
    {
        //gets the audio from the default mic and leaves a 1 second buffer (cannot get this any lower at the minute)
        aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start(null, true, 1, 44100);
        aud.loop = true;
        aud.Play();
    }

    // Update is called once per frame
    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;

        if (loudness > threshold)
        {
            Debug.Log("Playing static now");
            if (staticsource.isPlaying == false)
            {
                staticsource.Play();
            }
        }
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        aud.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
