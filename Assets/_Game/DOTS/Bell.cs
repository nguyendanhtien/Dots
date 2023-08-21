using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : Round
{
    private void LateUpdate()
    {
        DrawLine();
    }
    public override void OnInit()
    {
        transform.position = Vector3.zero;
        line.startColor = sprite.color;
        line.endColor = sprite.color;
        line.transform.position = Vector3.zero;
        line.transform.SetParent(null);
        onStepComplete += Fade;
        dot.transform.localPosition = Vector3.up * dist;

    }
    public override void Rotate(float dur)
    {
        transform.DORotate(Vector3.forward * 360, dur, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Yoyo).OnStepComplete(() => onStepComplete?.Invoke()).SetEase(Ease.Linear);
    }
    void DrawLine()
    {       
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, dot.transform.position);
    }
    void Fade()
    {
        audioS.Play();

        sprite.color = line.startColor;

        sprite.DOBlendableColor(Color.black, 1800/speed);
        
    }
}
