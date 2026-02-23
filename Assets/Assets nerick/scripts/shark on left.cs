using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkonleft : MonoBehaviour
{
    float sharkleft = -0.07f;

    void Start()
    {

    }
    void Update()
    {
        SharkmovementLeft();
    }

          void SharkmovementLeft()
    {
        if ( Time.time >4)
        transform.Translate(sharkleft,0,0);
    }
}
