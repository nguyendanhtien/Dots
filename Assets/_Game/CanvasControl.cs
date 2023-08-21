using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    public List<DotController> dotControllers = new List<DotController>();
    DotController current;
    int currentID = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Next()
    {
        if(currentID == dotControllers.Count-1)
        {
            currentID = 0;
        }
        else
        {
            currentID++;
        }
        Load();
    }
    public void Prev()
    {
        if (currentID == 0)
        {
            currentID = dotControllers.Count - 1;
        }
        else
        {
            currentID--;

        }
        Load();
    }
    void Load()
    {
        if (current != null)
        {           
            Destroy(current.gameObject);
        }
        var lines = GameObject.FindObjectsOfType<LineRenderer>(true);
        foreach (LineRenderer line in lines)
        {
            Destroy(line.gameObject);
            Destroy(line);
        }
        var dots = GameObject.FindObjectsOfType<Dot>(true);
        foreach (Dot dot in dots)
        {
            Destroy(dot.gameObject);
            Destroy(dot);
        }
        current = Instantiate(dotControllers[currentID]);
        
    }
}
