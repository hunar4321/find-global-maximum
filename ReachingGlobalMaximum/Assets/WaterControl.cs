using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{
    float speed = 0.1f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            transform.Translate(new Vector3(0,speed,0));
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            transform.Translate(new Vector3(0, -speed, 0));

        }
    }
}
