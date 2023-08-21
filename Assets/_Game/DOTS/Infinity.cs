using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinity : Dot
{
    bool fade = false;
    Color color = new Color(0.7421f, 0.55f, 0.55f);
    void LateUpdate()
    {
        DrawLine();
        if(Vector3.SqrMagnitude(transform.position)<0.02f&& fade)
        {
            fade = false;
            FadeColor();
        }
    }
    public void OnInit()
    {
        path = Infinity();
        line.startColor = sprite.color;
        line.endColor = sprite.color;
        line.transform.position = Vector3.zero;
        line.transform.SetParent(null);
        Invoke(nameof(ChangeFade), 120 / speed);
        Camera.main.backgroundColor = color;
        

    }
    void FadeColor()
    {
        Color col = sprite.color;
        sprite.color = color;
        sprite.DOBlendableColor(col, 1.5f).OnComplete(()=> ChangeFade());
        audioS.Play();
    }
    void ChangeFade()
    {
        fade = true;
    }
    public override void MoveCubic(float dur)
    {
        base.MoveCubic(dur);
       
    }
    void DrawLine()
    {
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, transform.position);
    }

}
