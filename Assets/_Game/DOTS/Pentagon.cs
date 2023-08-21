using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagon : Dot
{
    List<Dot> listDots = new List<Dot>();
    public Dot dot;
    int dotID;
    Color col ;
    Color fade;
    public void OnInit()
    {
        path = Pentagon();
        col = sprite.color;
        fade = new Color(col.r / 2, col.g / 2, col.b / 2);
        
        DrawLine();
        onStepComplete += OnComplete;
        for(int i = 0;i<5;i++)
        {          
            listDots.Add( Instantiate(dot, path[i], Quaternion.identity));
            listDots[i].sprite.color = sprite.color;           
        }
        listDots[0].gameObject.SetActive(false);
        StartCoroutine(IEChangeState());

    }
    public override void MovePoint(float dur)
    {
        
        base.MovePoint(dur);
       
    }
    void DrawLine()
    {
        line.transform.position = Vector3.zero;
        line.transform.SetParent(null);
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.startColor = Color.gray;
        line.endColor = Color.gray;
        line.positionCount = 6;
        for(int i = 0;i<6;i++)
        {
            line.SetPosition(i, path[i]);
        }      
    }
    void OnComplete()
    {
        

        sprite.DOBlendableColor(Color.black , 24f / speed);
        StopCoroutine(IEChangeState());
        StartCoroutine(IEChangeState());
        
    }
    void ChangeState(Dot d)
    {
        d.gameObject.SetActive(!d.gameObject.activeSelf); 
    }
    IEnumerator IEChangeState()
    {
        for(int i = 0;i<5 ;i++ )
        { 
            
            sprite.DOBlendableColor(fade, 24 / speed);
            audioS.Play();
            yield return new WaitForSeconds(24/speed);
            sprite.color = col;
            
            dotID = ++dotID % 5;
            ChangeState(listDots[dotID]);
            
        }
        

    }
}
