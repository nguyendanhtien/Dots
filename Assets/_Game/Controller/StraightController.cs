using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightController : DotController
{
    void Start()
    {
        numDot = 40;
        speed = 1f;
        OnInit();
    }


    void OnInit()
    {
        DOTween.Clear();
        for (int i = 0; i < numDot; i++)
        {
            Color col = GetColor(numDot-i-1);
            Straight  d = Instantiate(dot) as Straight;
            d.ChangeColor(col);
            d.dist = numDot-i-1;
            dots.Add(d);
            d.speed = (91 + i) * speed;
            d.ChangeAudio(GetAudio(i * 1f / numDot,10000));
            d.OnInit();                    
           
            d.LoopPoint(600 / d.speed);
            
        }

    }
}

