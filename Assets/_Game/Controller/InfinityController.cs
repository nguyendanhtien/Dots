using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityController : DotController
{
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
            Infinity  d = Instantiate(dot) as Infinity;
            d.ChangeColor(col);
            dots.Add(d);            
            d.dist = 30;
            d.ChangeAudio(GetAudio(i * 1f / numDot,10000));
            d.speed = (8 + i) * speed;
            d.OnInit();
            d.MoveCubic(480 / d.speed);
            StartCoroutine(IEWaitForPathStart(d));
        }
        Draw();

    }

    IEnumerator IEWaitForPathStart(Infinity d)
    {
        yield return new WaitUntil(() => d.pathLine != null);
        line.positionCount = d.pathLine.Length;
        line.SetPositions(d.pathLine);
    }
    void Draw()
    {
        line.startColor = Color.black;
        line.endColor = Color.black;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        Instantiate(dot, Vector3.zero, Quaternion.identity).ChangeColor(Color.black);
       
    }

}
