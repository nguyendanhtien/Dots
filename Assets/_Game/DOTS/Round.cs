using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : Dot
{
    // Start is called before the first frame update
    public GameObject dot;
    
    public virtual void OnInit()
    {
        
        transform.position = Vector3.zero;
        onStepComplete += Blink;
        dot.transform.localPosition = Vector3.up * dist;
    }
    public virtual void Rotate(float dur)
    {
        transform.DORotate(Vector3.forward*360, dur, RotateMode.FastBeyond360).SetLoops(-1).OnStepComplete(() => onStepComplete?.Invoke()).SetEase(Ease.Linear);
    }
    void Blink()
    {
        Color col = sprite.color;
        sprite.color = Color.black;
        sprite.DOBlendableColor(col, 1f);
        audioS.Play();
    }
}
