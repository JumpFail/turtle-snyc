using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polemovementonY : MonoBehaviour
{
    [SerializeField]
    float poleRotationY =2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,poleRotationY,0);
    }
}
