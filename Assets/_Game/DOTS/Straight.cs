using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : Dot
{
    Color2 startColor;
    Color2 endColor;
    Color color;
    public void OnInit()
    {
        path = StraightLine(30);
        onStepComplete += Blink;
        color = sprite.color;
        endColor = new Color2(Color.gray, Color.gray);
        startColor = new Color2(sprite.color, sprite.color);

        DrawLine();
        
    }
    public override void MovePoint(float dur)
    {
        base.MovePoint(dur);         
        
       
    }
    public void DrawLine()
    {
        line.transform.position = Vector3.zero;
        line.transform.SetParent(null);
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.startColor = color;
        line.endColor = color;
        line.SetPosition(0, path[0]);
        line.SetPosition(1, path[1]);
        line.DOColor(startColor, endColor, 600 / speed);

    }
    void Blink()
    {
        
        sprite.color = Color.white;
        sprite.DOBlendableColor(color, 0.75f);
        
        line.DOColor(startColor, endColor, 600/speed);
        audioS.Play();
    }



}
