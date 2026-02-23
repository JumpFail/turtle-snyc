using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkontop : MonoBehaviour
{
 float sharkright = 0.07f;

    void Start()
    {

    }
    void Update()
    {
        SharkmovementRight();
    }

          void SharkmovementRight()
    {
        if ( Time.time >6)
        transform.Translate(0,sharkright,0);
    }
}
