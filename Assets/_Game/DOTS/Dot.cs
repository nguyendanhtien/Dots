using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;


public class Dot : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sprite;
    public AudioSource audioS;
    public  float speed = 50f;    
    public float dist = 3f;   
    public float angle;
    public Vector3[] path;
    public LineRenderer line;
    public Tween doPath;
    public Vector3[] pathLine;
    public Action onStepComplete;
    void Start()
    {
        
        
    }  
    public virtual void ChangeColor(Color color)
    {
        sprite.color = color;      
    }
    public void ChangeAudio(AudioClip audio)
    {
        audioS.clip = audio;
    }
    public virtual void MoveCubic(float dur)
    {
        StopAllCoroutines();
        doPath = transform.DOPath(path, dur, PathType.CubicBezier,PathMode.Full3D, 20).SetLoops(-1).SetEase(Ease.Linear).OnStepComplete(()=> onStepComplete?.Invoke()).OnStart(() => { 
            pathLine = doPath.PathGetDrawPoints(20);
        });
    }
    public virtual void MovePoint(float dur)
    {
        transform.DOPath(path, dur, PathType.Linear).SetLoops(-1).SetEase(Ease.Linear).OnStepComplete(() => onStepComplete?.Invoke()).OnStart(() =>
        {
            pathLine = doPath.PathGetDrawPoints(20);
        });

    }
    public virtual void LoopCubic(float dur)
    {
        StopAllCoroutines();
        doPath = transform.DOPath(path, dur, PathType.CubicBezier, PathMode.Full3D, 20).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear).OnStepComplete(() => onStepComplete?.Invoke()).OnStart(() => {
            pathLine = doPath.PathGetDrawPoints(20);
        });

    }
    public virtual void LoopPoint(float dur)
    {
        StopAllCoroutines();
        transform.DOPath(path, dur, PathType.Linear).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear).OnStepComplete(() => onStepComplete?.Invoke()).OnStart(() =>
        {
            pathLine = doPath.PathGetDrawPoints(20);
        });
    }
    public IEnumerator ISound(float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);

        for (; ; )
        {
            yield return wait;
            audioS.Play();           
        }

    }
    public Vector3[] QuarterCircle()
    {
        
        transform.position = dist * new Vector3(1 / Mathf.Sqrt(2), 1 / Mathf.Sqrt(2), 0);
        float opt = 4f *(Mathf.Sqrt(2) - 1) / (3*Mathf.Sqrt(2)) ;
        Vector3[] vec =  new Vector3[] { 
           dist *  new  Vector3(-1 / Mathf.Sqrt(2), 1 / Mathf.Sqrt(2), 0),
           dist *  new  Vector3(1 /  Mathf.Sqrt(2)-opt,  1 /  Mathf.Sqrt(2)+opt, 0), 
           dist *  new  Vector3(-1 /  Mathf.Sqrt(2)+opt,  1/  Mathf.Sqrt(2)+opt, 0),
           
         
        };
        return vec;

    }
    public Vector3[] SemiCircle()
    {
        float t = dist / Mathf.Sqrt(2);
        transform.position = t * new Vector3(1 , 1 , 0);
        Vector3[] vec = new Vector3[] {
        new Vector3(-1 , 1 , 0) * t,
        new Vector3(1 ,7 /3,0) * t,
        new Vector3(-1 ,7 /3,0) * t,

       
        };
        return vec;
    }
    public Vector3[] Pentagon()
    {
        transform.position = new Vector3(0, dist, 0);
        Vector3[] vec = new Vector3[]
        {
            new Vector3(0, 1, 0)*dist,
            new Vector3(-Mathf.Cos(Mathf.PI/10),Mathf.Sin(Mathf.PI/10),0)*dist,
            new Vector3(-Mathf.Sin(Mathf.PI/5),-Mathf.Cos(Mathf.PI/5),0)*dist,

            new Vector3(Mathf.Sin(Mathf.PI/5),-Mathf.Cos(Mathf.PI/5),0)*dist,
            new Vector3(Mathf.Cos(Mathf.PI/10),Mathf.Sin(Mathf.PI/10),0)*dist,
            new Vector3(0, 1, 0)*dist

    };


        return vec;

    }
    public Vector3[] Infinity()
    {
        transform.position = Vector3.zero;
        Vector3[] vec = new Vector3[]
        {
           
            new Vector3(0,0,-0.001f),
            new Vector3(-1,1,0)*dist,
            new Vector3(1,1,0)*dist,

            new Vector3(0,0,0.001f),
            new Vector3(-1,-1,0)*dist,
            new Vector3(1,-1,0)*dist


        };


        return vec;

    }
    public Vector3[] Polygon()
    {
       
        transform.position = new Vector3(-Mathf.Cos(angle), Mathf.Sin(angle), 0) * dist;
        Vector3[] vec = new Vector3[]
        {
            new Vector3(-Mathf.Cos(angle),Mathf.Sin(angle),0)*dist,

            new Vector3(Mathf.Cos(angle),-Mathf.Sin(angle),0)*dist,

           

        };


        return vec;

    }
    public Vector3[] CherryBlossom()
    {
        transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * dist;
        Vector3[] vec = new Vector3[]
        {
            new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0)*dist,
            new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0)*dist*4,
            
        };
        return vec;

    }
    public Vector3[] StraightLine(float length)
    {
        int height = 25;
        transform.position = new Vector3( 5 / 4f * dist-height, -length, 0);
        Vector3[] vec = new Vector3[]
        {
            new Vector3(5/4f* dist-height,-length,0),
            new Vector3(5/4f* dist-height,length,0)           
        };


        return vec;

    }   

    public void MoveMath(float rad = Mathf.PI/2)
    {
        Vector3 offset;
        float angle = 0;
        float direct = 1;
        float eps = 0;
        angle += direct*0.003f * speed/10;
       
        offset = new Vector3(dist * (Mathf.Cos(angle)), dist * (Mathf.Sin(angle)), 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, offset, speed *0.02f);
        
        if (rad-angle <=eps  || angle <=eps )
        {
            direct = -direct;
            angle +=  direct * Time.deltaTime ;
            audioS.Play();
        }
        /*
        List<Vector3> list = new List<Vector3>();
         float time=0;
        do        
        {
            time += 0.3f;
            offset = new Vector3(dist * Mathf.Abs(Mathf.Cos(Mathf.PI / 30 * time)), dist * Mathf.Abs(Mathf.Sin(Mathf.PI / 30 * time)), 0);          
            list.Add(offset);

        }
        while (time <= 15);
        list.Add(new Vector3(dist * Mathf.Abs(Mathf.Cos(Mathf.PI / 2)), dist * Mathf.Abs(Mathf.Sin(Mathf.PI / 2)), 0));
        Vector3[] vec = new Vector3[list.Count * 2 - 2];
        for (int i = 0; i < list.Count; i++)
        {
            vec[i] = list[i];
        }
        for (int i = 1; i < list.Count - 1; i++)
        {
            int t = i - list.Count;
            vec[-2 - i + list.Count * 2] = list[i];
        }

        // transform.DOPath(vec, 30/speed).SetLoops(-1).SetEase(Ease.Linear);
        */
    }
}
