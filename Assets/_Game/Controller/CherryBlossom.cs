using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBlossom : DotController
{
    public SpriteRenderer sprite;
    void Start()
    {
        numDot = 40;
        speed = 1f;
        OnInit();
   
    }

    void OnInit()
    {
        DOTween.Clear();
        float angle = 2 * Mathf.PI / numDot;
        for (int i = 0; i < numDot; i++)
        {
            Cherry d = Instantiate(dot) as Cherry;            
            dots.Add(d);
            d.dist = 5;
            if (i % 2 == 0)
            {
                d.angle = -i / 2 * angle - Mathf.PI / 2;
                d.ChangeColor(GetColor((numDot-i)));
            }
            else
            {
                d.angle = (i / 2 + 1) * angle - Mathf.PI / 2;
                d.ChangeColor(GetColor(i));
            }
            d.color = d.sprite.color;
            d.ChangeAudio(GetAudio(i * 1f / numDot,10000));
            d.OnInit();
            d.speed = (25 + i) * speed;
            d.MovePoint(300 / d.speed);

        }

    }
    

}
