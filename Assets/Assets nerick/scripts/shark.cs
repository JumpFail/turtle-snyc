using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark : MonoBehaviour
{
    float sharkspeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sharkmovement();
    }

          void Sharkmovement()
    {
        if ( Time.time >3)
        transform.Translate(sharkspeed,0,0);
    }
}
