using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowController : DotController
{
    // Start is called before the first frame update
    void Start()
    {
        numDot = 25;
        speed = 1f;
        OnInit();
    }
    void OnInit()
    {
        transform.position = Vector3.left * 20;
        DOTween.Clear();
        for (int i = 0; i < numDot; i++)
        {
            Color col = GetColor(i);
            Rainbow d = Instantiate(dot) as Rainbow;
            d.dist = (8f + i);
            d.ChangeColor(col);            
            dots.Add(d);
            d.ChangeAudio(GetAudio(1-i * 1f / numDot,10000));
            d.OnInit();
            d.speed = (127 - i) * speed;
            d.Rotate(900 / d.speed);       
        }
        Draw();
    }
    void Draw()
    {
        line.startColor = Color.white;
        line.endColor = Color.white;
        line.startWidth = 0.3f;
        line.endWidth = 0.3f;
        line.SetPosition(0, Vector3.up*(8 + dots.Count));
        line.SetPosition(1, Vector3.down * (8 + dots.Count));

    }
}
