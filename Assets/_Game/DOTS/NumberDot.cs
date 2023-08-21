using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberDot : Dot
{
    [SerializeField] TMP_Text text;
    public int number;

    public void OnInit()
    {
        path = QuarterCircle();
        onStepComplete += () => ChangeNumber(++number);
    }
    
    public override void ChangeColor(Color color)
    {
        text.color = color;

    }
    public void ChangeNumber(int number)
    {
        text.text = number.ToString();
        audioS.Play();
    }
    public override void LoopCubic( float dur)
    {
        base.LoopCubic(dur);   
    }  
    
}
