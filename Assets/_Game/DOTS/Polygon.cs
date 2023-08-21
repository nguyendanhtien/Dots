using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : Dot
{
    // Start is called before the first frame update
    public void OnInit()
    {
        path = Polygon();
        DrawLine();
        onStepComplete += Blink;
    }
    public override void LoopPoint(float dur)
    {
        
        transform.DOPath(path, dur, PathType.Linear).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine).OnStepComplete(() => onStepComplete?.Invoke()).OnStart(() =>
        {
            pathLine = doPath.PathGetDrawPoints(20);
        }
        );
    }
    void DrawLine()
    {
        line.transform.SetParent(null);
        line.transform.position = Vector3.zero;
        
        Color color = Color.white;
        color.a = 0.3f;
        line.startColor = color;
        line.endColor = color;

        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.SetPosition(0, path[0]);
        line.SetPosition(1, path[1]);
    }
    void Blink()
    {

        audioS.Play();
    }
   
}
