using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundController : DotController
{
   [SerializeField] LineRenderer envi;
    List<Round> list = new List<Round>();
    void Start()
    {
        numDot = 100;
        speed = 1f;
        OnInit();
    }
    private void LateUpdate()
    {
        Draw();
    }   
    void Draw()
    {
        line.positionCount = list.Count;

        for (int i = 0; i < list.Count; i++)
        {
            line.SetPosition(i, list[i].dot.transform.position);
        }
    }
    void OnInit()
    {
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.startColor = Color.black;
        line.endColor = Color.black;
        line.transform.position = Vector3.zero;
        DOTween.Clear();
        for (int i = 0; i < numDot; i++)
        {
            Color col = GetColor(10f* (i%10));
            Round d = Instantiate(dot) as Round;
            d.dist =  i/4f;
            d.ChangeColor(col);
            d.ChangeAudio(GetAudio(i%10 * 0.1f,10000));
            list.Add(d);
            d.OnInit();
            d.speed = (150 - i) * speed;
            d.Rotate(1080 / d.speed);
        }
        DrawEnvi();

    }
    void DrawEnvi()
    {
        envi.positionCount = 362;
        Vector3[] linePath = new Vector3[362];
        linePath[361] = list[0].transform.position;
        float radius = list.Count / 4f+0.2f;
        
        for (int i = 0; i< 361;i++)
        {
            float angle = i / 360f*2*Mathf.PI;
            linePath[i] = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
        }
        envi.SetPositions(linePath);
        envi.startColor = Color.black;
        envi.endColor = Color.black;
    }

}
