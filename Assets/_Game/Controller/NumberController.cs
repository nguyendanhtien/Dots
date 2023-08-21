using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : DotController
{
    // Start is called before the first frame update
    void Start()
    {
        numDot = 20;
        speed = 1f;
        OnInit();   
    }


    void OnInit()
    {
        DOTween.Clear();
        for (int i = 0; i < numDot; i++)
        {
            Color col = GetColor(i);
            NumberDot d = Instantiate(dot) as NumberDot;
            d.dist = (8f + i);
            d.ChangeColor(col);
            d.number = 1;
            d.ChangeNumber(1);
            dots.Add(d);
            d.ChangeAudio(GetAudio(i * 1f / numDot,10000));
            d.OnInit();
            d.speed = (30 - i) * speed;
            d.LoopCubic(30 / d.speed);
        }

    }
}
