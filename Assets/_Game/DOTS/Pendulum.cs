using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Dot
{
   
   public void OnInit()
    {
        path = SemiCircle();

    }
    public override void LoopCubic(float dur)
    {
        base.LoopCubic(dur);

    }
}
