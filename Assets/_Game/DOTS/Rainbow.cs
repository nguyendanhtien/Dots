using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : Round
{
   public override void OnInit()
    {
        transform.position = Vector3.left*20;
        dot.transform.localPosition = Vector3.up * dist;
        onStepComplete += Blink;
        DrawLine();
    }

    public override void Rotate(float dur)
    {
        transform.DOLocalRotate(Vector3.forward * -180, dur, RotateMode.Fast).SetLoops(-1,LoopType.Yoyo).OnStepComplete(() => onStepComplete?.Invoke()).SetEase(Ease.Linear);

    }
    void Blink()
    {
        Color col = sprite.color;
        sprite.color = Color.white;
        sprite.DOBlendableColor(col, 1f);
        audioS.Play();
    }
    void DrawLine()
    {
        line.startColor = sprite.color;
        line.endColor = sprite.color;
        line.positionCount = 181;
        line.transform.SetParent(null);
        Vector3[] linePath = new Vector3[181];

        float radius = dist;

        for (int i = 0; i < 181; i++)
        {
            float angle = i / 360f * 2 * Mathf.PI-Mathf.PI/2;
            linePath[i] = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        }
        line.SetPositions(linePath);
       
    }
}
