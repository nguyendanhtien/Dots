using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int position = 0;
    public int samplerate = 44100;
    public float frequency = 440;

    void Start()
    {
        AudioClip myClip = AudioClip.Create("Sound", samplerate * 2, 1, samplerate, true, OnAudioRead, OnAudioSetPosition);
        
        AudioSource aud = GetComponent<AudioSource>();
        aud.clip = myClip;
        aud.Play();
    }

    void OnAudioRead(float[] data)
    {
        int count = 0;
        while (count < data.Length)
        {
            data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
            position++;
            count++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        position = newPosition;
    }
}
