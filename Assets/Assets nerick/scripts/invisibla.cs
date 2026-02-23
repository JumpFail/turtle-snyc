using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case"see":
                lumps();
                break;
            case"unsee":
                Debug.Log("Teleport");
                break;

        }
    }

    void lumps()
    {
        if(Time.time > 3)
        {
            Debug.Log("lllllllllllllll");
        }
    }
}
