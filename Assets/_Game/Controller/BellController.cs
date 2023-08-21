using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : DotController
{
    // Start is called before the first frame update
    void Start()
    {
        numDot = 20;
        speed = 1f;
        OnInit();
        Debug.Log(audioSource.clip.frequency);
    }

    void OnInit()
    {
        DOTween.Clear();
        for (int i = 0; i < numDot; i++)
        {
            Color col = GetColor(i);
           Bell d = Instantiate(dot) as Bell;
            d.dist = (8f + i);
            d.ChangeColor(col);
            d.ChangeAudio(GetAudio(1-i * 1f / numDot,10000));
            dots.Add(d);
            d.OnInit();
            d.speed = (127 - i) * speed;
            d.Rotate(1200 / d.speed);
        }
        Draw();
    }
    void Draw()
    {
        line.positionCount = 362;
        Vector3[] linePath = new Vector3[362];
        linePath[361] = dots[0].transform.position;
        float radius = dots.Count  + 8.25f;

        for (int i = 0; i < 361; i++)
        {
            float angle = i / 360f * 2 * Mathf.PI;
            linePath[i] = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
        }
        line.SetPositions(linePath);
        line.startColor = Color.black;
        line.endColor = Color.black;

    }
}
