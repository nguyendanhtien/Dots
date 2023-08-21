using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Music", menuName = "ScriptableObjects/Music", order = 1)]
public class Music : ScriptableObject
{
    [SerializeField]public  AudioClip audio;
    
    public float[] DataMusic()
    {
        float[] data = new float[audio.samples * audio.channels];
        audio.GetData(data,0);

        return data;
    }



}
