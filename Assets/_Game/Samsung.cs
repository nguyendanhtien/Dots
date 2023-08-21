using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samsung : MonoBehaviour
{
    [SerializeField] Music music;
    AudioClip audio;
    public AudioSource audioSource;
    float[] array= new float[41];
    void Start()
    {
        audio = AudioClip.Create("samsung", 2000000, music.audio.channels, music.audio.frequency,true,false);
        
        
        float[] temp = music.DataMusic();
        Debug.Log(temp.Length);
        float[] temp2 = new float[2000000];
      for (int i =0; i<2000000;i++)
        {
            temp2[i] = i%2==0?temp[i]*2:temp[i]/2;
        }
        audio.SetData(temp2, 0);
        audioSource.clip = audio;
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
