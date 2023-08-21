using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonController : DotController
{
    [SerializeField] LineRenderer circle;
    void Start()
    {
        numDot = 20;
        speed = 1f;
        OnInit();
    }
    private void LateUpdate()
    {
        DrawLine();
    }
    void OnInit()
    {
        DOTween.Clear();
        float angle = Mathf.PI / (numDot);
        for (int i = 0; i < numDot; i++)
        {            
            Polygon d = Instantiate(dot) as Polygon;
            d.dist = 20;
            d.angle = i * angle;            
            dots.Add(d);
            d.speed = (80 + i) * speed;
            d.ChangeAudio(GetAudio(i * 1f / numDot,10000));
            d.OnInit();
            d.LoopPoint(250 / d.speed);
        }
        DrawCircle();
    }
    void DrawCircle()
    {
        circle.positionCount = 361;
        Vector3[] linePath = new Vector3[361];

        float radius = 20f;

        for (int i = 0; i < 361; i++)
        {
            float angle = i / 360f * 2 * Mathf.PI;
            linePath[i] = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
        }
        circle.SetPositions(linePath);

    }






}
