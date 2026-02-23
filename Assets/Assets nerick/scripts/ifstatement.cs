using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifstatement : MonoBehaviour
{

    // Update is called once per frame
    void OncollisionEnter(Collision other)
    {
        touch();
    }
    void touch()
    {
        if(gameObject.tag=="player")
        {
            Debug.Log("nigger");
        }
    }

}
