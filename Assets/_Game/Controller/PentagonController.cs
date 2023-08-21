using DG.Tweening;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonController : DotController
{
   
    void Start()
    {
        numDot = 20;
        speed = 1f;
        OnInit();
    }
    // Update is called once per frame
    void OnInit()
    {
        DOTween.Clear();
        for (int i = 0; i < numDot; i++)
        {
            Color col = GetColor(i);
            Pentagon d = Instantiate(dot) as Pentagon;
            d.dist = (4f + i*1.2f);
            d.ChangeColor(col);
            d.ChangeAudio(GetAudio(i*1f/numDot,40000));
            dots.Add(d);
            
            d.speed = (6 + 2 * i / 5f) * speed;
            d.OnInit();
            d.MovePoint(120/d.speed);
        }

    }
    

}
