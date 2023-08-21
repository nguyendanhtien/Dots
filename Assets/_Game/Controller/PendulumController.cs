using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController :DotController
{
    // Start is called before the first frame update
    void Start()
    {
        numDot = 25;
        speed = 1f;
        OnInit();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DrawLine();
    }
    void OnInit()
    {
        DOTween.Clear();
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.startColor = Color.black;
        line.endColor = Color.black;
        line.transform.position = Vector3.zero;
        for (int i = 0; i < numDot; i++)
        {
            Color col = GetColor(i);
            Pendulum d = Instantiate(dot) as Pendulum;
            d.dist = (8f + i * 0.5f);
            d.ChangeColor(col);
            dots.Add(d);
            d.ChangeAudio(GetAudio(i * 1f / numDot,10000));
            d.OnInit();
            d.speed = (45 + i) * speed;
            d.LoopCubic(60 / d.speed);


        }
    }
}
