using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Dot
{
    public CherryBlossom cherryBlossom;
    public Color color ;
    bool back = true;
    void LateUpdate()
    {
        DrawLine();
    }
   public void OnInit()
    {
        path = CherryBlossom();
        line.startColor = Color.white;
        line.endColor = Color.white;
        line.transform.position = Vector3.zero;
        line.transform.SetParent(null);
        cherryBlossom = FindFirstObjectByType<CherryBlossom>();
        onStepComplete += ChangeParentColor;
    }
    public override void MovePoint(float dur)
    {
        base.LoopPoint(dur);
        
    }
    void DrawLine()
    {

        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, transform.position);
    }

    void ChangeParentColor()
    {
        sprite.color = Color.black;
        sprite.DOBlendableColor(color, 0.5f);
        audioS.Play();
        back = !back;
        if (back)
        { cherryBlossom.sprite.color = color; }
        
    }

}
