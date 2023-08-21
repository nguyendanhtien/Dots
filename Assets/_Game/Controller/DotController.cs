using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DotController : MonoBehaviour
{
    public Dot dot;
    public LineRenderer line;
    // [SerializeField] TMP_Text textClock;
    public AudioSource audioSource;
    public List<Dot> dots = new List<Dot>();
    public int numDot;   
    public float speed;
    public void SetTime()
    {

        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);

       // textClock.text = hour + ":" + minute + ":" + second;
    }  
    public Color GetColor(float i)
    {
        int num = numDot / 2;
        if(i<=num)
        {
            return Color.Lerp(Color.blue, Color.green, (i /num));
        }
        else
            
        {
            return Color.Lerp(Color.green, Color.red, (i-num) / num);
        }

    }


    public AudioClip GetAudio(float rate,int baseFr)
    {
        AudioClip audio = AudioClip.Create("name" + rate.ToString(), audioSource.clip.samples * audioSource.clip.channels, audioSource.clip.channels,(int)( baseFr+4000*rate), true, false);
        float[] samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);
        /*
        for(int i = 0;i<samples.Length;i++)
        {
            samples[i] = samples[i] * rate;
        }
        */
        audio.SetData(samples, 0);

        return audio;
    }
    public void DrawLine()
    {
        line.positionCount = dots.Count ;
        
        for (int i =0; i<dots.Count;i++)
        {           
            line.SetPosition(i,dots[i].transform.position);
        }
        
    }   
    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
   

}
