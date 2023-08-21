using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Music", menuName = "ScriptableObjects/Music", order = 1)]
public class Music : ScriptableObject
{
    [SerializeField] AudioClip[] audio;
    public AudioClip GetMusic(int i)
    {

        return audio[i];


    }    



}
